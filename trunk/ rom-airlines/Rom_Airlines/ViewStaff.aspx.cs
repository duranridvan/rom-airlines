using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Rom_Airlines
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        string selectQuery=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            bool loggedIn = Session["loggedIn"];

            
            StaffView.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string input = TextBox1.Text;
            select = "SELECT * FROM SystemUser SU,Staff ST WHERE SU.id=ST.id AND (SU.TcIdNo= ' " + input + "' OR SU.name= '" + input + "' OR Su.email= '" + input + "')";
        }
    }
}
