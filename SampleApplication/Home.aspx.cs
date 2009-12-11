using System;
using System.Web.Security;

namespace SampleApplication
{
    public partial class Home : System.Web.UI.Page
    {
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}
