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
    public partial class CheckIn2 : System.Web.UI.Page
    {
        string connectionString;
        MySqlConnection connection;
        int rId;
        int fid1, fid2;
        string fd1, fd2;
        protected string parseDate(string date)
        {
            return date.Substring(6, 4) + "-" + date.Substring(3, 2) + "-" + date.Substring(0, 2);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            rId = Convert.ToInt32(Request.QueryString.Get("rId"));
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            string selectQuery = String.Format("SELECT F.id as 'Flight No', F.fdate 'Date', concat(DC.name,' ',DA.name) as 'Dep. Airport',concat(LC.name,' ',LA.name) as 'Land. Airport',F.departureTime as 'Dep. Time', F.landingTime as 'Land. Time'"+
                " FROM ReservationFlight RF,Flight F,Airport DA,Airport LA,City DC,City LC"+
                " WHERE RF.flightId = F.id and RF.flightDate = F.fdate and "+
                " F.departureAirport=DA.id and F.landingAirport=LA.id and "+
                " DA.cityId=DC.id and LA.cityId=LC.id and RF.reserveId = {0}",rId);
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            Flight1Grid.DataSource = myDataTable;
            Flight1Grid.DataBind();
            fid1 = Convert.ToInt32(Flight1Grid.Rows[0].Cells[0].Text);
            fd1 = parseDate(Flight1Grid.Rows[0].Cells[1].Text);
            fid2 = Convert.ToInt32(Flight1Grid.Rows[1].Cells[0].Text);
            fd2 = parseDate(Flight1Grid.Rows[0].Cells[1].Text);

            selectQuery = String.Format("SELECT P.name as'Passenger Name'" +
                " FROM Passenger P,ReservationPassenger RP" +
                " WHERE P.id = RP.passengerId and RP.reservationId={0}", rId);
            command = new MySqlCommand(selectQuery, connection);
            myDataAdapter = new MySqlDataAdapter(command);
            myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            Passengers1Grid.DataSource = myDataTable;
            Passengers2Grid.DataSource = myDataTable;
            Passengers1Grid.DataBind();
            Passengers2Grid.DataBind();

        }
    }
}
