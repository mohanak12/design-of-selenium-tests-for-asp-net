using System;
using System.Configuration;
using System.Xml;
using Configuration=SampleApplication.Core.Configuration;

namespace StorageAdmin
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void ClearStorage(object sender, EventArgs e)
        {
            const string emptyStorage = @"<users><user name=""admin"" password=""god"" /></users>";
            var doc = new XmlDocument();
            doc.LoadXml(emptyStorage);
            doc.Save(new Configuration().Xml);
        }
    }
}
