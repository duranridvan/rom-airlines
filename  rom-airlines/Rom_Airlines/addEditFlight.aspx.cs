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
    public partial class addEditFlight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            string select = "select name,id from plane;";

            MySqlDataAdapter planeAdapter = new MySqlDataAdapter(select, connection);
            string select2 = "select name,id from airport;";
            MySqlDataAdapter airportAdepter = new MySqlDataAdapter(select2, connection);
            
            DataSet planeDataSet = new DataSet();
            planeAdapter.Fill(planeDataSet, "plane");
            planeList.DataSource = planeDataSet;
            planeList.DataTextField = "name";
            planeList.DataValueField = "id";

            DataSet airportDataSet = new DataSet();
            airportAdepter.Fill(airportDataSet, "airport");
            departureList.DataSource = airportDataSet;
            departureList.DataTextField = "name";
            departureList.DataValueField = "id";

            landingList.DataSource = airportDataSet;
            landingList.DataTextField = "name";
            landingList.DataValueField = "id";




            if (!IsPostBack)
            {
                planeList.DataBind();
                departureList.DataBind();
                landingList.DataBind();
            }
            
            if (!IsPostBack && (!((Request.QueryString.Count) < 2)))
            {
                addeditbutton.Text = "Edit";
                int flightId = Convert.ToInt32(Request.QueryString.Get("fId"));
                string fdate = Request.QueryString.Get("date");
                //int loggedId = (int)Session["loggedId"];
                //bool loggedIn = (bool)Session["loggedIn"];
                //bool isAdmin = dbOps.IsAdmin(loggedId);
                //if (!loggedIn)
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oturum açmadınız.');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'", true);
                //else if (!isAdmin && (userId != loggedId))
                //{
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bu kullanıcı için yetkili değilsiniz');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'", true);
                //}
                //else
                //{

                MySqlConnection thisConnection = new MySqlConnection(connection);
                DataSet thisDataset = new DataSet();
                select = string.Format("SELECT 	f.id as fid, f.fdate, f.planeid, f.departureairport, f.landingairport, f.landingtime, f.departuretime, departureA.name as daparturename, p.name as pname, landingA.name as landingname FROM airport departureA, plane p, flight f, airport landingA WHERE f.id={0} AND f.planeid=p.id AND landingA.id = f.departureairport AND departureA.id=f.landingairport", flightId);
                thisConnection.Open();
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader = thisCommand.ExecuteReader();

                thisReader.Read();
                flightidBox.Text = thisReader["fid"].ToString();
                dateBox.Text = thisReader["fdate"].ToString();
                planeList.SelectedValue = thisReader["planeid"].ToString();
                departureList.SelectedValue = thisReader["departureairport"].ToString();
                landingList.SelectedValue = thisReader["landingairport"].ToString();
                deptTimeBox.Text = thisReader["departuretime"].ToString();
                landTimeBox.Text = thisReader["landingtime"].ToString();
                thisReader.Close();
                thisConnection.Close();
                flightidBox.Enabled = false;
                dateBox.Enabled = false;
                //}
            }
        }

        protected void addeditbutton_Click(object sender, EventArgs e)
        {

            int planeid = Convert.ToInt32(planeList.SelectedValue);
            int deptAir = Convert.ToInt32(departureList.SelectedValue);
            int landAir = Convert.ToInt32(landingList.SelectedValue);
            string deptTime = deptTimeBox.Text,
               landTime = landTimeBox.Text;





            if (!((Request.QueryString.Count) < 1))
            {
                int flightId = Convert.ToInt32(Request.QueryString.Get("fId"));
                string fdate = Request.QueryString.Get("date");


                string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
                MySqlConnection thisConnection = new MySqlConnection(connection);
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                DataSet thisDataset = new DataSet();
                MySqlCommand update = thisConnection.CreateCommand();

                //int userId = Convert.ToInt32(Request.QueryString.Get("userId"));
                //int loggedId = (int)Session["loggedId"];
                //bool isAdmin = dbOps.IsAdmin(loggedId);

                //if (isAdmin || (userId == loggedId))
                //{

                update.CommandText = string.Format("UPDATE flight SET planeid={0}, departureairport={1}, landingairport={2}, landingtime='{3}', departuretime='{4}' WHERE id={5} AND fdate='{6}'",planeid,deptAir,landAir,landTime,deptTime, flightId,fdate);
                /*update.Parameters.Add("@PID", MySqlDbType.Int32).Value = planeid;
                update.Parameters.Add("@DEA", MySqlDbType.Int32).Value = deptAir;
                update.Parameters.Add("@LAA", MySqlDbType.Int32).Value = landAir;
                update.Parameters.Add("@DET", MySqlDbType.Time).Value = deptTime;
                update.Parameters.Add("@LAT", MySqlDbType.Time).Value = landTime;
                */

                //}

                thisConnection.Open();
                update.ExecuteNonQuery();

                string message = "alert('Airport editted. ID: " + flightId + " Date " + fdate + " ');window.location='" + ResolveUrl("~/manageflight.aspx") + "'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                //}
                //else
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bu kullanıcı için yetkili değilsiniz');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'", true);
            }
            else
            {
                int fid = Convert.ToInt32(flightidBox.Text);
                string date = dateBox.Text;


                string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
                MySqlConnection thisConnection = new MySqlConnection(connection);
                thisConnection.Open();

                MySqlCommand insert = thisConnection.CreateCommand();
                insert.CommandText = String.Format("INSERT INTO flight(id,fdate,planeid,departureairport,landingairport,landingtime,departuretime) VALUES({0},'{1}',{2},{3},{4},'{5}','{6}')", fid,date,planeid,deptAir,landAir,landTime,deptTime);
                insert.ExecuteNonQuery();
                //int id = Convert.ToInt32(insert.LastInsertedId);
                thisConnection.Close();
                string message = "alert('The flight is added. ID: " + fid + " ');window.location='" + ResolveUrl("~/manageflight.aspx") + "'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
            }
        }

    }
}
