using System.ComponentModel;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace SampleApplication.Services
{
    /// <summary>
    /// Summary description for Guard
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class Guard : WebService
    {
        [WebMethod]
        public string GetCurrentUser()
        {
            Thread.Sleep(500);
            return HttpContext.Current.User.Identity.Name;
        }


    }
}
