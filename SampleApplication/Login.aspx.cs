using System;
using System.Web.Security;
using SampleApplication.Core;

namespace SampleApplication
{
    public partial class _Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtUser.Text;
            var password = txtPassword.Text;

            if (Factory.GetGateway().IsExists(userName, password))
            {
                FormsAuthentication.SetAuthCookie(userName, false);    

                Response.Redirect("~/Home.aspx");
            }
            else
            {
                lblMessage.Text = "Username and password do not match.";
            }
        }
    }
}
