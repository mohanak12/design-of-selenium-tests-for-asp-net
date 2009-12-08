using System;
using System.Web.Security;

namespace SampleApplication
{
    public partial class _Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUser.Text;
            string password = txtPassword.Text;

            if (userId == "admin" && password == "god")
            {
                FormsAuthentication.SetAuthCookie(userId, false);    

                Response.Redirect("~/Home.aspx");
            }
            else
            {
                lblMessage.Text = "Username and password do not match.";
            }
        }
    }
}
