﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rom_Airlines
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            emailBox.Text = DB.login();
        }

        protected void signinButton_Click(object sender, EventArgs e)
        {
            emailBox.Text = DB.login();
        }


    }
}