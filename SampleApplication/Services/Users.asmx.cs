using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Web.Script.Services;
using System.Web.Services;
using SampleApplication.Core;
using SampleApplication.Core.Data;
using SampleApplication.Core.View;

namespace SampleApplication.Services
{
    /// <summary>
    /// Summary description for Users
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class Users : WebService
    {

        [WebMethod]
        public AddUserView AddUser(string name, string password)
        {
            Thread.Sleep(500);

            var gateway = Factory.GetGateway();


            var result = new AddUserView() {Success = true};

            if(gateway.IsExists(name))
            {
                result.Success = false;
                result.Message = string.Format("User with name '{0}' already exists", name);
            }
            else
            {
                gateway.AddUser(name, password);
            }

            return result;
        }

        [WebMethod]
        public IList<UserView> GetAll()
        {
            Thread.Sleep(500);

            return Factory.GetGateway().GetAll().Select(
                r => new UserView()
                         {
                             Name = r.Name, 
                             Password = r.Password
                         }).ToList();
        }

       
    }
}
