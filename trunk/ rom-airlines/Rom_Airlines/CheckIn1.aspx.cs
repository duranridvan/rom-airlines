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
using MySql.Data;
using MySql.Data.MySqlClient; 

namespace Rom_Airlines
{
    public partial class CheckIn1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rId = Convert.ToInt32(TextBox1.Text);
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            MySqlCommand thisCommand = thisConnection.CreateCommand();
            string select = String.Format("SELECT (SELECT COUNT(*) FROM Reservation WHERE id ={0}) AS uTrue", rId);
            thisConnection.Open();
            thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = select;
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            thisReader.Read();
            int uTrue = Convert.ToInt16(thisReader["uTrue"]);
            if (uTrue == 0)
            {
                string message = "alert('There is no reservation with id = " + rId + "');window.location='" + ResolveUrl("~/CheckIn1.aspx") + "'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                return;
            }
            else {
                Response.Redirect("~/CheckIn2.aspx?rId=" + rId);
            }
            thisReader.Close();
            thisConnection.Close();
        }
    }
}
