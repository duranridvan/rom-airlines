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

            if (!((Request.QueryString.Count) < 1))
            {
                int logout = Convert.ToInt32(Request.QueryString.Get("logout"));
                if (logout == 1)
                    Session["loggedIn"] = false;
            }

            bool isLogged=false;
            try
            {
                isLogged = (bool)Session["loggedIn"];
            }
            catch (Exception exc)
            {
                isLogged = false;
            }


                
            if (isLogged)
            {

                string staffT = Session["job"].ToString();
                if(staffT.Equals("Customer") || staffT.Equals("Sales Officer"))
                    Response.Redirect("~/makereservation.aspx");
                if(staffT.Equals("Check In Officer"))
                    Response.Redirect("~/checkin1.aspx");
                if(staffT.Equals("Pilot")|| staffT.Equals("Cabin Attendant"))
                    Response.Redirect("~/seeassignment.aspx");

                    Response.Redirect("~/menu.aspx");
            }








        }

        
        protected void loginAut(object sender, EventArgs e)
        {

            string username = usernameBox.Text;
            string password = passwordBox.Text;

            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5");
            int id;
            string staffT;
            int result = DB.LoginCheck(username, password, out id,out staffT);






            Session["loggedIn"] = false;
            Session["loggedId"] = id;
            Session["job"] = staffT;
            switch (result)
            {
                case 1:
                    Session["loggedIn"] = true;
                    if(staffT.Equals("Customer") || staffT.Equals("Sales Officer"))
                        Response.Redirect("~/makereservation.aspx");
                    if(staffT.Equals("Check In Officer"))
                        Response.Redirect("~/checkin1.aspx");
                    if(staffT.Equals("Pilot")|| staffT.Equals("Cabin Attendant"))
                        Response.Redirect("~/seeassignment.aspx?staffT="+staffT);

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

        protected void resButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/makereservation.aspx");
        }

        protected void checkinbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/checkin1.aspx");
        }


    }
}
