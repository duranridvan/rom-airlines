using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rom_Airlines
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text,
            phone = phoneBox.Text,
            email = emailBox.Text,
            birthday = birthdayBox.Text,
            emailC = emailCBox.Text, 
            passwordC = passwordCBox.Text,
            password = passwordBox.Text;
            if ((!password.Equals(passwordC)) || !emailC.Equals(email)) Page_Load(sender, e);
            else {
                
                int id = DB.addUser(name, password, phone, email, birthday);
                string message;
                if (id < 0)
                    message = "alert('This e-mail is already signed up!');";
                else
                    message = "alert('The user is added. ID: " + id + " ');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
            }

        }

    }
}
