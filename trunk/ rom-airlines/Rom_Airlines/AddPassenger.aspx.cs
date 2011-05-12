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
    public partial class AddPassenger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int noOfPass = Convert.ToInt16(Request.QueryString.Get("noPass"));
            if (noOfPass == 1)
            {
                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                RegularExpressionValidator2.Enabled = false;
                RegularExpressionValidator3.Enabled = false;
            }
            if (noOfPass == 2)
            {
                RequiredFieldValidator4.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                RegularExpressionValidator3.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int noOfPass=Convert.ToInt16(Request.QueryString.Get("noPass"));
            int rId = Convert.ToInt16(Request.QueryString.Get("rId"));
            string name1, name2, name3, date1, date2, date3;
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();

            MySqlCommand insert = thisConnection.CreateCommand();
            
            //insert.Parameters.Add("@ID", MySqlDbType.Int16).Value = newId;
            int newId1,newId2,newId3;
            if (noOfPass == 1) {
                name1 = NameBox1.Text;
                date1 = DBox1.Text;
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')",name1, date1);
                insert.ExecuteNonQuery();
                newId1 = Convert.ToInt16(insert.LastInsertedId);
                insert.CommandText = String.Format("Insert into ReservationPassenger(reservationId,passengerId) Values({0},{1})", rId,newId1);

            }
            else if (noOfPass == 2)
            {
                name1 = NameBox1.Text;
                date1 = DBox1.Text;
                name2 = NameBox2.Text;
                date2 = DBox2.Text;
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name1, date1);
                insert.ExecuteNonQuery();
                newId1 = Convert.ToInt16(insert.LastInsertedId);
                insert.CommandText = String.Format("Insert into ReservationPassenger(reservationId,passengerId) Values({0},{1})", rId, newId1);
                insert.ExecuteNonQuery();
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name2, date2);
                insert.ExecuteNonQuery();
                newId2 = Convert.ToInt16(insert.LastInsertedId);
                insert.CommandText = String.Format("Insert into ReservationPassenger(reservationId,passengerId) Values({0},{1})", rId, newId2);
            }
            else {
                name1 = NameBox1.Text;
                date1 = DBox1.Text;
                name2 = NameBox2.Text;
                date2 = DBox2.Text;
                name3 = NameBox3.Text;
                date3 = DBox3.Text;
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name1, date1);
                insert.ExecuteNonQuery();
                newId1 = Convert.ToInt16(insert.LastInsertedId);
                insert.CommandText = String.Format("Insert into ReservationPassenger(reservationId,passengerId) Values({0},{1})", rId, newId1);
                insert.ExecuteNonQuery();
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name2, date2);
                insert.ExecuteNonQuery();
                newId2 = Convert.ToInt16(insert.LastInsertedId);
                insert.ExecuteNonQuery();
                insert.CommandText = String.Format("Insert into ReservationPassenger(reservationId,passengerId) Values({0},{1})", rId, newId2);
                insert.ExecuteNonQuery();
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name3, date3);
                insert.ExecuteNonQuery();
                newId3 = Convert.ToInt16(insert.LastInsertedId);
                insert.CommandText = String.Format("Insert into ReservationPassenger(reservationId,passengerId) Values({0},{1})", rId, newId3);
            }
            
            insert.ExecuteNonQuery();
            Response.Redirect("~/Payment.aspx?rId="+rId);
            thisConnection.Close();
        }
    }
}
