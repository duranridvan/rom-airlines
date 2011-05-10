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
    public partial class Payment : System.Web.UI.Page
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
           
            int resId = Convert.ToInt32(Request.QueryString.Get("rId"));
            string selectQuery = String.Format("SELECT F.id as 'Flight No', F.fdate as 'Date', DA.name as 'Departure Airport', LA.name as 'Landing Airport', F.departureTime as 'Departure Time', F.landingTime as 'Landing Time'  FROM Flight F, Airport DA, Airport LA, ReservationFlight RF WHERE F.departureAirport=DA.id and F.landingAirport=LA.id and RF.reserveId={0} and RF.flightId=F.id and RF.flightDate=F.fdate", resId);
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            FlightGrid.DataSource = myDataTable;
            FlightGrid.DataBind();

            selectQuery = String.Format("SELECT P.name as 'Name', P.birthday as 'Birthday' FROM passenger P, reservationpassenger RP WHERE RP.reservationId={0} and RP.passengerId = P.id", resId);
            command = new MySqlCommand(selectQuery, connection);
            myDataAdapter = new MySqlDataAdapter(command);
            myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            PassengerGrid.DataSource = myDataTable;
            PassengerGrid.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            //string input = TextBox1.Text;
            int resId = Convert.ToInt32(Request.QueryString.Get("rId"));
            string query = String.Format("UPDATE reservation SET paymentStatus=true WHERE id={0}", resId);
            string message = String.Format("alert('Payment Done. Reservation ID: {0}. You can check in online by using your reservation id')" +
                ";window.location='" + ResolveUrl("~/") + "'", resId);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
            //Response.Redirect("~/");
        }
    }
}
    