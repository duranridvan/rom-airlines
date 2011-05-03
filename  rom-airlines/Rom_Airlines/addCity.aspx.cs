using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
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
    public partial class addCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogged = (bool)Session["loggedIn"];
            int userId = Convert.ToInt32(Session["loggedId"]);
            if (!isLogged)
                Response.Redirect("~/Default.aspx");
        }

        protected void addButton_Click1(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();

            MySqlCommand insert = thisConnection.CreateCommand();
            insert.CommandText = String.Format("INSERT INTO city(name) VALUES('{0}')",name);
            insert.ExecuteNonQuery();
            int id = Convert.ToInt32(insert.LastInsertedId);
            thisConnection.Close();
            string message = "alert('The city is added. ID: " + id + " ');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);

        }
    }
}

