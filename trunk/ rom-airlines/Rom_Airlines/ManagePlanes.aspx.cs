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
    public partial class ManagePlanes : System.Web.UI.Page
    {
        string input;
        string connectionString;
        MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            string selectQuery = String.Format("SELECT id as ID, name as 'Airport Name', bussCapacity as 'Bussiness Class Capacity', firstCapacity as 'First Class Capacity', econCapacity as 'Economy Class Capacity' FROM PlaneModel");
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            GridPlanes.DataSource = myDataTable;
            GridPlanes.DataBind();
        }
        protected void GridPlanes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(GridPlanes.Rows[e.NewEditIndex].Cells[1].Text);
            Response.Redirect("~/AddEditPlane.aspx?palaneId=" + id);
        }
        protected void GridPlanes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridPlanes.Rows[e.RowIndex].Cells[1].Text);
            connection = new MySqlConnection(connectionString);
            connection.Open();
            string deleteQuery = String.Format("delete from planemodel where id='{0}'", id);
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);
            command.ExecuteNonQuery();
            GridPlanes.DataBind();
            connection.Close();
            Page_Load(sender, e);
        }
    }
}
