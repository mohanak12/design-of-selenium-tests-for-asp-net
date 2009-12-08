using System;
using System.Web;
using System.Web.Security;

namespace SampleApplication
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserName.Text =  HttpContext.Current.User.Identity.Name;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}
