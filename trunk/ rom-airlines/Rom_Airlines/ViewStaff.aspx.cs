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
    public partial class ViewStaff : System.Web.UI.Page
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
            string job = Session["job"].ToString();
            if (!job.Equals("System Admin"))
                Response.Redirect("~/Default.aspx");
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            //select = string.Format("select s.name from SystemUser s, CabinAttendant c where s.id = c.id;");

            if (true || !IsPostBack)
            {
                input = TextBox1.Text;
                string selectQuery = String.Format("SELECT SU.id as ID, SU.email as 'e-mail', SU.name as Name, SU.phoneNumber as Phone, ST.TcIdNo as 'TC ID', ST.job as 'Staff Type'   FROM SystemUser SU,Staff ST WHERE SU.id=ST.id AND (ST.TcIdNo like '%{0}%'  OR SU.name like '%{0}%' OR Su.email like '%{0}%')", input);

                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                //command.Parameters.Add("@INPUT", MySqlDbType.VarChar, 50).Value = input;

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);


                DataTable myDataTable = new DataTable();

                myDataAdapter.Fill(myDataTable);
                StaffView.DataSource = myDataTable;
                StaffView.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        { 
            /*input = TextBox1.Text;
            string selectQuery = String.Format("SELECT SU.id as ID, SU.email as 'e-mail', SU.name as Name, SU.phoneNumber as Phone, ST.TcIdNo as 'TC ID', ST.job as 'Staff Type'   FROM SystemUser SU,Staff ST WHERE SU.id=ST.id AND (ST.TcIdNo like '%{0}%'  OR SU.name like '%{0}%' OR Su.email like '%{0}%')", input);
            
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            //command.Parameters.Add("@INPUT", MySqlDbType.VarChar, 50).Value = input;

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);


            DataTable myDataTable = new DataTable();

            myDataAdapter.Fill(myDataTable);
            StaffView.DataSource = myDataTable;
            StaffView.DataBind();*/
        }

        protected void StaffView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(StaffView.Rows[e.NewEditIndex].Cells[1].Text);
            Response.Redirect("~/AddEditStuff.aspx?staffId=" + id);
        }

        protected void StaffView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(StaffView.Rows[e.RowIndex].Cells[1].Text);
            connection = new MySqlConnection(connectionString);
            connection.Open();
            string deleteQuery = String.Format("delete from systemuser where id='{0}'",id);
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);
            command.ExecuteNonQuery();
            StaffView.DataBind();
        }
    }
}
