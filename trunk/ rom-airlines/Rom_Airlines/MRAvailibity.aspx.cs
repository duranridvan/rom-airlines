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
    public partial class MRAvailibity : System.Web.UI.Page
    {
        string connectionString;
        MySqlConnection connection;
        int noPass;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
                Response.Redirect("~/Default.aspx");
            bool isLogged = (bool)Session["loggedIn"];
            int userId = Convert.ToInt32(Session["loggedId"]);
            if (!isLogged)
                Response.Redirect("~/Default.aspx");

            string dDate = Request.QueryString.Get("dDate");
            string rDate = Request.QueryString.Get("rDate");
            int from = Convert.ToInt32(Request.QueryString.Get("from"));
            int to = Convert.ToInt32(Request.QueryString.Get("to"));
            noPass = Convert.ToInt32(Request.QueryString.Get("noPass"));
            int type = Convert.ToInt32(Request.QueryString.Get("type"));

            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            string selectQuery = String.Format(
                "SELECT F.id as 'Flight No', F.fdate as 'Date', CONCAT(DAC.name,' ',DA.name) as 'Dep. Airport', CONCAT(LAC.name,' ',LA.name) as 'Lan. Airport', F.departuretime as 'Dep. Time', F.landingtime as 'Lan. Time'"+
                " FROM Flight F, Airport DA, Airport LA, City DAC, City LAC" + 
                " WHERE F.fDate = '{0}' and F.departureAirport = '{1}' and  F.landingAirport= '{2}' and "+
                " F.departureAirport=DA.id and DA.cityId = DAC.id and F.landingAirport=LA.id and LA.cityId=LAC.id"
                ,dDate,from,to);
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            Flights1Grid.DataSource = myDataTable;
            Flights1Grid.DataBind();

            selectQuery = String.Format(
                "SELECT F.id as 'Flight No', F.fdate as 'Date', CONCAT(DAC.name,' ',DA.name) as 'Dep. Airport', CONCAT(LAC.name,' ',LA.name) as 'Lan. Airport', F.departuretime as 'Dep. Time', F.landingtime as 'Lan. Time'" +
                " FROM Flight F, Airport DA, Airport LA, City DAC, City LAC" +
                " WHERE F.fDate = '{0}' and F.departureAirport = '{1}' and  F.landingAirport= '{2}' and " +
                " F.departureAirport=DA.id and DA.cityId = DAC.id and F.landingAirport=LA.id and LA.cityId=LAC.id"
                , rDate, to, from);
            command = new MySqlCommand(selectQuery, connection);
            myDataAdapter = new MySqlDataAdapter(command);
            myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            Flights2Grid.DataSource = myDataTable;
            Flights2Grid.DataBind();
            try { Flights2Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow"); }
            catch (Exception ex) { }
            try { Flights1Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow"); }
            catch (Exception ex) { }

        }

        protected void Flights1Grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flights1Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow");
            try { Flights2Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow"); }
            catch (Exception ex) { }
        }

        protected void Flights2Grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flights2Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow");
            try { Flights1Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow"); }
            catch (Exception ex) { }
        }
        
        protected string parseDate(string date)
        {
            return date.Substring(6, 4) + "-" + date.Substring(3, 2) + "-" + date.Substring(0, 2);
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            string did, rid, ddate, rdate;
            try
            {
                did = Flights1Grid.SelectedRow.Cells[1].Text;
                rid = Flights2Grid.SelectedRow.Cells[1].Text;
                ddate = parseDate(Flights1Grid.SelectedRow.Cells[2].Text);
                rdate = parseDate(Flights2Grid.SelectedRow.Cells[2].Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Fligh isn't selected", true);
                return;
            }

            connection = new MySqlConnection(connectionString);
            connection.Open();
            string insertQuery = "insert into reservation() values()";
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();
            int resid = (int)command.LastInsertedId;

            insertQuery = String.Format("insert into reservationflight(flightId,flightDate,reserveId)"+
                                        " values('{0}','{1}','{2}')",did,ddate,resid );
            command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            insertQuery = String.Format("insert into reservationflight(flightId,flightDate,reserveId)" +
                                        " values('{0}','{1}','{2}')", rid, rdate, resid);
            command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            Response.Redirect("~/AddPassenger.aspx?rId=" + resid + "&noPass=" + noPass);


        }
    }
}
