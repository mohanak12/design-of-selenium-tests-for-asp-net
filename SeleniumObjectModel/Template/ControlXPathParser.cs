using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SeleniumObjectModel.Template
{
    public class ControlXPathParser
    {
        public static RenderClass Render(ClassInfo mainClass, IList<ClassRowInfo> rowClasses)
        {
            var renderedClass = new RenderClass
            {
                Name = mainClass.ClassName,
                Items = GetItems(mainClass.Elements),
                Collections = new List<RenderCollection>()
            };

            foreach (var rowClass in rowClasses)
            {
                var renderedRowClass = new RenderCollection
                 {
                     Name = rowClass.ClassName,
                     Counter = rowClass.CountXpath,
                     Items = GetItems(rowClass.Elements, rowClass.IteratorPattern),
                 };

                renderedClass.Collections.Add(renderedRowClass);
            }

            return renderedClass;
        }

        public static List<RenderItem> GetItems(string xPathes)
        {
            return GetItems(xPathes, null);
        }

        public static List<RenderItem> GetItems(string xPathes, string counterPattern)
        {
            var elements = xPathes.Split('\n');

            var usedNames = new HashSet<string>();
            var items = new List<RenderItem>();

            foreach (var elementWithEndLine in elements)
            {
                items.Add(GetRenderItem(elementWithEndLine.Trim(), counterPattern, usedNames));
            }

            return items;
        }

        private static RenderItem GetRenderItem(string element, string counterPattern, HashSet<string> usedNames)
        {
            string xpath;
            string name;
            string type;

            var indexOf = element.IndexOf(" ");

            if(indexOf != -1)
            {
                var parameters = element.Substring(indexOf, element.Length - indexOf).Replace("{", "").Replace("}", "").Split('=');
                var code = parameters[1];

                xpath = element.Substring(0, indexOf);
                type = GetTypeByCode(code);
                name = GetNameByCode(code);
            }
            else
            {
                xpath = element;
                type = GetType(xpath);
                name = GetName(xpath, usedNames, type);    
            }

            return new RenderItem
            {
               XPath = GetSeleniumSelector(xpath, counterPattern), 
               Name = name, 
               Type = type
            };
        }

        private static string GetNameByCode(string code)
        {
            return code.Substring(3);
        }

        private static string GetTypeByCode(string code)
        {
            var list = new List<KeyValuePair<string, string>>
            {
               new KeyValuePair<string, string>("lbl", "Label"),
               new KeyValuePair<string, string>("txt", "TextField"),
               new KeyValuePair<string, string>("drp", "Dropdown"),
               new KeyValuePair<string, string>("btn", "Button"),
            };

            foreach (var item in list)
            {
                if (code.Contains(item.Key))
                {
                    return item.Value;
                }
            }

            throw new System.Exception("Unknown type for code:" + code);
        }

        private static string GetSeleniumSelector(string xpath, string counterPattern)
        {
            return "xpath=" + ApplyCounter(xpath, counterPattern);
        }

        private static string GetName(string xpath, HashSet<string> usedNames, string type)
        {
            var name = GetName(xpath);

            if (usedNames.Contains(name))
            {
                name = name + type;
            }

            usedNames.Add(name);
            return name;
        }

        private static string GetName(string element)
        {
            string[] bannedPostfixes = {"txtCurrency", "buttonTextLabel"};

            var match = new Regex(@"/(?<tag>\w+)\[@id='(?<id>[^']+)'\](/span)?$").Match(element);
            string id = match.Groups["id"].Value;

            string bannedPostfix = bannedPostfixes.FirstOrDefault( q => id.EndsWith(q));
            if(bannedPostfix != null )
            {
                if (id.EndsWith(bannedPostfix))
                {
                    id = id.Substring(0, id.Length - bannedPostfix.Length - 1);
                }    
            }
            
            return GetNameFromId(GetControlId(id));
        }

        private static string ApplyCounter(string element, string counterPattern)
        {
            if (!string.IsNullOrEmpty(counterPattern))
            {
                var re = new Regex(String.Format(counterPattern.Replace("[", @"\["), "(?<num>.*)"));
                var number = re.Match(element).Groups["num"].Value;


                return element.Replace(String.Format(counterPattern, number), counterPattern);
            }

            return element;
        }

        private static string GetType(string xPath)
        {
            var list = new List<KeyValuePair<Regex, string>>
            {
               new KeyValuePair<Regex, string>(new Regex(@"/a\[@id='[\w\d_]*btn\w+']/span"), "Button"),
               new KeyValuePair<Regex, string>(new Regex(@"/input\[@id='[\w\d_]*chk\w+']"), "Checkbox"),
               new KeyValuePair<Regex, string>(new Regex(@"/input\[@id='[\w\d_]*btn\w+']"), "Button"),
               new KeyValuePair<Regex, string>(new Regex(@"/select\[@id='[\w\d_]*']"), "Dropdown"),
               new KeyValuePair<Regex, string>(new Regex(@"/input\[@id='[\w\d_]*']"), "TextField"),
               new KeyValuePair<Regex, string>(new Regex(@"/textarea\[@id='[\w\d_]*']"), "TextField"),
               new KeyValuePair<Regex, string>(new Regex(@"/span\[@id='[\w\d_]*lbl\w+']"), "Label")
            };

            foreach (var item in list)
            {
                Regex re = item.Key;
                if (re.IsMatch(xPath))
                {
                    return item.Value;
                }
            }

            throw new System.Exception("Unknown type for xpath:" + xPath);
        }

        private static string GetControlId(string id)
        {
            if(!id.Contains("_"))
            {
                return id;
            }

            var re = new Regex(@"_(?<id>[^_]+)(/span)?$");
            return re.Match(id).Groups["id"].Value;
        }

        private static string GetNameFromId(string id)
        {
            var re = new Regex(@"(txt|ddl|btn|lbl|chk)?(?<id>.*)");
            var strippedName = re.Match(id).Groups["id"].Value;
            return char.ToUpper(strippedName[0]) + strippedName.Substring(1);
        }
    }
}