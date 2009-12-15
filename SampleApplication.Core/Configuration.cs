using System.Configuration;

namespace SampleApplication.Core
{
    public class Configuration
    {
        public string Xml
        {
            get { return ConfigurationManager.AppSettings["XmlFile"]; }
        }
    }
}
