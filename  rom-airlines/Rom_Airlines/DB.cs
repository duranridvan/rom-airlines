using System;
using System.Data;
using System.Configuration;
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
    public class DB
    {

        public static int LoginCheck(string username, string password, out int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            MySqlCommand thisCommand = thisConnection.CreateCommand();
            DataSet thisDataset = new DataSet();
            int uTrue = 0, uPass = 0;
            string select = string.Format("SELECT (SELECT COUNT(email) FROM SystemUser WHERE email='{0}') AS uTrue, (SELECT COUNT(email) FROM SystemUser WHERE email='{0}' AND password='{1}') AS uPass, id AS UserId, email FROM SystemUser WHERE email='{0}'", username, password);
            thisConnection.Open();
            thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = select;
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            id = -1;
            while (thisReader.Read())
            {
                uTrue = Convert.ToInt16(thisReader["uTrue"]);
                uPass = Convert.ToInt16(thisReader["uPass"]);
                if (uTrue == 1)
                    if (uPass == 1)
                    {
                        id = (int)thisReader["UserId"];
                        thisReader.Close();
                        thisConnection.Close();
                        return 1;
                    }
            }
            thisReader.Close();
            thisConnection.Close();

            if (uTrue == 1 && (!(uPass == 1)))
                return 0;
            else
                return -1;
        }

        public static int addUser(string name, string password, string phone, string email, string birthday)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbConD"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            int uTrue = 0;
            string select = string.Format("SELECT (SELECT COUNT(email) FROM members WHERE email='{0}') AS uTrue", email);
            thisConnection.Open();
            MySqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = select;
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            
            while (thisReader.Read())
            {
                uTrue = (int)thisReader["uTrue"];
            }
            thisReader.Close();
            thisConnection.Close();
            if (uTrue > 0)
            {
                return -1;
            }
            else
            {
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5");
                MySqlCommand insert = thisConnection.CreateCommand();
                insert.CommandText = "INSERT INTO SystemUser(name,password,phone,email,birthday) VALUES(@NAME,@PASSWORD,@PHONE,@EMAIL,@DATE,@ISADMIN,@ISACTIVE); SET @ID = SCOPE_IDENTITY()";
                insert.Parameters.Add("@NAME", MySqlDbType.VarChar, 50).Value = name;
                insert.Parameters.Add("@PASSWORD", MySqlDbType.VarChar, 50).Value = password;
                insert.Parameters.Add("@PHONE", MySqlDbType.VarChar, 15).Value = phone;
                insert.Parameters.Add("@EMAIL", MySqlDbType.VarChar, 50).Value = email;
                insert.Parameters.Add("@DATE", MySqlDbType.DateTime).Value = birthday;
                insert.Parameters.Add("@ID", MySqlDbType.Int16).Direction = ParameterDirection.Output;
                thisConnection.Open();
                insert.ExecuteNonQuery();
                int newId = Convert.ToInt32(insert.Parameters["@ID"].Value);
                insert.CommandText = "INSERT INTO Customer(id) VALUES(@ID)";
                insert.Parameters.Add("@ID", MySqlDbType.Int16).Value = newId ;
                insert.ExecuteNonQuery();
                thisConnection.Close();
                return newId;
            }
        
        }
    }
}

// nabion la yarragim :P :P
