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
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString;
            MySqlConnection connection;
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
            string selectQuery = String.Format("SELECT S.id as 'Pilot Id',S.name as'Pilot Name',COUNT(*) as '# Flights'"+
                " FROM SystemUser S,Flies F"+
                " WHERE S.id = F.pilotId"+
                " GROUP BY S.id");
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            Report1.DataSource = myDataTable;
            Report1.DataBind();
            
            String d1 = TextBox1.Text;
            String d2 = TextBox2.Text;

            selectQuery = String.Format("SELECT C1.name as 'From',C2.name as 'To',COUNT(*) as '# passengers'" + 
                " FROM City C1, City C2,Airport A1,Airport A2, Flight F, ReservationFlight FR, ReservationPassenger RP "+
                " WHERE C1.id=A1.cityId and C2.id=A2.cityId and "+
                    " A1.id=F.departureAirport and A2.id=F.landingAirport and"+
                    " FR.flightId=F.id and FR.flightDate=F.fdate and FR.reserveId=RP.reservationId"+
                    (d1.Equals("") && d2.Equals("")? "" : " and F.fdate >= '{0}' and F.fdate <='{1}'")+
                " GROUP BY C1.id, C2.id", d1, d2);

            command = new MySqlCommand(selectQuery, connection);
            myDataAdapter = new MySqlDataAdapter(command);
            myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            Report2.DataSource = myDataTable;
            Report2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
