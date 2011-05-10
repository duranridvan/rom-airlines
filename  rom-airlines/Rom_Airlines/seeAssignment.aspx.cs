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
    public partial class seeAssignment : System.Web.UI.Page
    {
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
            if (!job.Equals("Pilot")&&!job.Equals("Cabin Attendant"))
                Response.Redirect("~/Default.aspx");
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            string staffType =Convert.ToString(Session["job"]);
            int sid = Convert.ToInt32(Session["loggedId"]);
            if (staffType.Equals("Pilot"))
            {
                HeaderLabel.Text = "See Assignment - Pilot";
                string selectQuery = String.Format("SELECT FP.flightId as 'Flight No', FP.flightDate as 'Flight Date' from Flies FP where FP.pilotId={0} ", sid);
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
                DataTable myDataTable = new DataTable();
                myDataAdapter.Fill(myDataTable);
                GridView1.DataSource = myDataTable;
                GridView1.DataBind();
            }
            else if (staffType.Equals("Cabin Attendant"))
            {
                HeaderLabel.Text = "See Assignment - Cabin Attendant";
                string selectQuery = String.Format("SELECT C.flightId as 'Flight No', C.flightDate as 'Flight Date' from assigned C where C.cabinAttendantId={0} ", sid);
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
                DataTable myDataTable = new DataTable();
                myDataAdapter.Fill(myDataTable);
                GridView1.DataSource = myDataTable;
                GridView1.DataBind();
            }


        }
    }
}
