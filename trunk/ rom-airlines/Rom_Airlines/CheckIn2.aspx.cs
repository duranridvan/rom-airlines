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
            MySqlDataReader reader;
            rId = Convert.ToInt32(Request.QueryString.Get("rId"));
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            MySqlConnection connection2 = new MySqlConnection(connectionString);
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

            bool round = true;
            fid1 = Convert.ToInt32(myDataTable.Rows[0][0].ToString());
            fd1 = parseDate(myDataTable.Rows[0][1].ToString());
            try
            {
                fid2 = Convert.ToInt32(myDataTable.Rows[1][0].ToString());
                fd2 = parseDate(myDataTable.Rows[1][1].ToString());
            }
            catch (Exception ex)
            {
                round = false;
            }
            int x=1;
           
            while(true)
            {
                connection.Close();
                connection.Open();
                DataTable table = new DataTable();
                selectQuery = String.Format("SELECT * FROM Seat WHERE flightId={0} and flightDate='{1}' and seatNo={2}",
                    fid1, fd1, x);
                command = new MySqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();
                if (!reader.Read())
                    break;
                x++;
            }

            int y = 1;
            while (round)
            {
                connection.Close();
                connection.Open();
                DataTable table = new DataTable();
                selectQuery = String.Format("SELECT * FROM Seat WHERE flightId={0} and flightDate='{1}' and seatNo={2}",
                    fid2, fd2, y);
                command = new MySqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();
                if (!reader.Read())
                    break;
                y++;
            }

            connection.Close();
            connection.Open();
            selectQuery = String.Format("SELECT P.id" +
                " FROM Passenger P,ReservationPassenger RP" +
                " WHERE P.id = RP.passengerId and RP.reservationId={0}", rId);
            command = new MySqlCommand(selectQuery, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string insertquery = String.Format("INSERT INTO SEAT(passengerId,flightId,flightDate,seatNo)" +
                    " VALUES({0},{1},'{2}',{3})" + (round?"({0},{4},'{5}',{6})":""),id,fid1,fd1,x++,fid2,fd2,y++);
                connection2.Close();
                connection2.Open();
                command = new MySqlCommand(insertquery, connection2);
                command.ExecuteNonQuery();
            }
            connection.Close(); connection.Open();
            selectQuery = String.Format("SELECT P.name as 'Passenger Name',S.seatNo as 'Seat No'" +
                " FROM Passenger P,ReservationPassenger RP, Seat S" +
                " WHERE P.id = RP.passengerId and RP.reservationId={0} and S.flightId={1} and S.flightDate='{2}'"+
                " and S.passengerId=P.id",rId,fid1,fd1);
            command = new MySqlCommand(selectQuery, connection);
            myDataAdapter = new MySqlDataAdapter(command);
            myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            Passengers1Grid.DataSource = myDataTable;
            Passengers1Grid.DataBind();
            if (round)
            {
                connection.Close(); connection.Open();
                selectQuery = String.Format("SELECT P.name as 'Passenger Name',S.seatNo as 'Seat No'" +
                    " FROM Passenger P,ReservationPassenger RP, Seat S" +
                    " WHERE P.id = RP.passengerId and RP.reservationId={0} and S.flightId={1} and S.flightDate='{2}'" +
                    " and S.passengerId=P.id", rId, fid2, fd2);
                command = new MySqlCommand(selectQuery, connection);
                myDataAdapter = new MySqlDataAdapter(command);
                myDataTable = new DataTable();
                myDataAdapter.Fill(myDataTable);
                Passengers2Grid.DataSource = myDataTable;
                Passengers2Grid.DataBind();
            }

           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
        
    }
}
