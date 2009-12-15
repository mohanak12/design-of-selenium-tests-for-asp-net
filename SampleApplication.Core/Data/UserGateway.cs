using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SampleApplication.Core.Data
{
    public class UserGateway
    {
        private readonly Configuration config;

        public UserGateway(Configuration config)
        {
            this.config = config;
        }

        public void AddUser(string name, string password)
        {
            var doc = Load();
            AddUser(doc, name, password);
            Save(doc);
        }

        public bool IsExists(string name, string password)
        {
            return GetAll()
                .Where(r => r.Name == name && r.Password == password)
                .Any();
        } 
        
        public bool IsExists(string name)
        {
            return GetAll()
                .Where(r => r.Name == name)
                .Any();
        }

        public IList<UserRow> GetAll()
        {
            IList<UserRow> rows = new List<UserRow>();

            var doc = Load();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                rows.Add(new UserRow()
                             {
                                 Name = node.Attributes["name"].Value,
                                 Password = node.Attributes["password"].Value
                             });
            }

            return rows;
        }

        private static void AddUser(XmlDocument doc, string name, string password)
        {
            var userElement = doc.CreateElement("user");
            var nameAttribute = doc.CreateAttribute("name");
            var passwordAttribute = doc.CreateAttribute("password");
            userElement.Attributes.Append(nameAttribute);
            userElement.Attributes.Append(passwordAttribute);

            doc.DocumentElement.AppendChild(userElement);

            nameAttribute.Value = name;
            passwordAttribute.Value = password;
        }

        private void Save(XmlDocument doc)
        {
            doc.Save(config.Xml);
        }

        private XmlDocument Load()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(config.Xml);
            return doc;
        }
    }
}


