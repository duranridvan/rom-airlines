using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace Rom_Airlines
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            
        }

        
        protected void loginAut(object sender, EventArgs e)
        {

            string username = usernameBox.Text;
            string password = passwordBox.Text;

            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5");
            int id;
            int result = DB.LoginCheck(username, password, out id);

            Session["loggedIn"] = false;
            Session["loggedId"] = id;
            switch (result)
            {
                case 1:
                    Session["loggedIn"] = true;
                    Response.Redirect("~/menu.aspx");
                    break;
                case 0:
                    errorLabel.Text = "Password is wrong";
                    break;
                case -1:
                    errorLabel.Text = "Email is wrong";
                    break;
                default:
                    errorLabel.Text = "Unexpected situation happened";
                    break;
            }
        }

        protected void signUpButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/signup.aspx");
        }


    }
}
