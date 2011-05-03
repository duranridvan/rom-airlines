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
            bool isLogged = (bool)Session["loggedIn"];
            int userId = Convert.ToInt32(Session["loggedId"]);
            if (!isLogged)
                Response.Redirect("~/Default.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int noOfPass=3;
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
                newId1 = Convert.ToInt16(insert.LastInsertedId);
            }
            else if (noOfPass == 2)
            {
                name1 = NameBox1.Text;
                date1 = DBox1.Text;
                name2 = NameBox1.Text;
                date2 = DBox1.Text;
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name1, date1);
                newId1 = Convert.ToInt16(insert.LastInsertedId);
                insert.ExecuteNonQuery();
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name2, date2);
                newId2 = Convert.ToInt16(insert.LastInsertedId);
            }
            else {
                name1 = NameBox1.Text;
                date1 = DBox1.Text;
                name2 = NameBox2.Text;
                date2 = DBox2.Text;
                name3 = NameBox3.Text;
                date3 = DBox3.Text;
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name1, date1);
                newId1 = Convert.ToInt16(insert.LastInsertedId);
                insert.ExecuteNonQuery();
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name2, date2);
                newId2 = Convert.ToInt16(insert.LastInsertedId);
                insert.ExecuteNonQuery();
                insert.CommandText = String.Format("INSERT INTO Passenger(name,birthday) VALUES('{0}','{1}')", name3, date3);
                newId3 = Convert.ToInt16(insert.LastInsertedId);            
            }
            insert.ExecuteNonQuery();
            thisConnection.Close();
        }
    }
}
