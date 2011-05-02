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
            surname = surnameBox.Text,
            phone = phoneBox.Text,
            email = emailBox.Text,
            birthday = birthdayBox.Text,
            emailC = emailCBox.Text, 
            passwordC = passwordCBox.Text,
            password = passwordBox.Text;
            if ((!password.Equals(passwordC)) || !emailC.Equals(email)) Page_Load(sender, e);

        }

    }
}
