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
    public partial class ManageLicences : System.Web.UI.Page
    {
       
        string input;
        string connectionString;
        MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
                Response.Redirect("~/Default.aspx");
            bool isLogged = (bool)Session["loggedIn"];
            int userId = Convert.ToInt32(Session["loggedId"]);
            if (!isLogged)
                Response.Redirect("~/Default.aspx");
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            string selectQuery = String.Format("SELECT id as ID, name as 'Licence Name' FROM licence");
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            GridLicences.DataSource = myDataTable;
            GridLicences.DataBind();
        }
        protected void GridLicences_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(GridLicences.Rows[e.NewEditIndex].Cells[1].Text);
            Response.Redirect("~/EditLicence.aspx?modelId=" + id);
        }

        protected void GridLicences_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridLicences.Rows[e.RowIndex].Cells[1].Text);
            connection = new MySqlConnection(connectionString);
            connection.Open();
            string deleteQuery = String.Format("delete from licence where id='{0}'", id);
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);
            command.ExecuteNonQuery();
            GridLicences.DataBind();
            connection.Close();
            Page_Load(sender, e);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            connection.Open();
            string query = String.Format("INSERT INTO Licence(name) VALUES ('{0}') ", name);
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            GridLicences.DataBind();
            connection.Close();
            Page_Load(sender, e);
           
        }

       
    }
}
