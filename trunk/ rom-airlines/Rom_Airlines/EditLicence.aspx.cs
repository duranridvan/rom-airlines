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
    public partial class EditLicence : System.Web.UI.Page
    {
        int modelId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
                Response.Redirect("~/Default.aspx");
            bool isLogged = (bool)Session["loggedIn"];
            int userId = Convert.ToInt32(Session["loggedId"]);
            if (!isLogged)
                Response.Redirect("~/Default.aspx");



            if (!((Request.QueryString.Count) < 1))
            {
                modelId = Convert.ToInt32(Request.QueryString.Get("modelId"));
            }
            else
                Response.Redirect("~/managelicences.aspx");

            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            DataSet thisDataset = new DataSet();
            string select = string.Format("SELECT name FROM licence WHERE id={0}", modelId);
            thisConnection.Open();
            MySqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = select;
            MySqlDataReader thisReader = thisCommand.ExecuteReader();

            thisReader.Read();
            nameBox.Text = thisReader["name"].ToString();
            thisReader.Close();
            thisConnection.Close();
            



        }

        protected void addButton_Click(object sender, EventArgs e)
        {

        }

        protected void removeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
