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
    public partial class reservations : System.Web.UI.Page
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
            if (!job.Equals("System Admin"))
                Response.Redirect("~/Default.aspx");
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);

            string selectQuery = "SELECT Res.id as 'Reservation ID',res.customerId as 'Customer ID', Res.paymentstatus as Payment, RF.flightid as 'Flight ID', RF.flightDate as 'Flight Date', dept.name as 'Departure Airport', F.departureTime as 'Departure Time',land.name as 'Landing Airport', F.landingTime as 'landingtime Time', (SELECT COUNT(*) FROM ReservationPassenger WHERE reservationid=Res.id) as 'Number Of Passengers',(SELECT MIN(p.name) FROM ReservationPassenger RP ,Passenger P WHERE RP.reservationid=Res.id AND P.id=RP.passengerId) AS Passengers FROM Reservation Res, Reservationflight RF, Flight F, airport dept, airport land WHERE Res.id=RF.reserveid AND F.id=RF.flightid AND F.fdate = RF.flightdate AND dept.id=F.departureairport AND land.id=F.landingairport";

            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            //command.Parameters.Add("@INPUT", MySqlDbType.VarChar, 50).Value = input;

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);


            DataTable myDataTable = new DataTable();

            myDataAdapter.Fill(myDataTable);
            resView.DataSource = myDataTable;
            resView.DataBind();
        }

    }
}
