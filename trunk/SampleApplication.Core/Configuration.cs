using System.Configuration;
using System.IO;
using System.Web;

namespace SampleApplication.Core
{
    public class Configuration
    {
        public string Xml
        {
            get { return Path.Combine(HttpContext.Current.Server.MapPath("/"), ConfigurationManager.AppSettings["XmlFile"]); }
        }
    }
}
