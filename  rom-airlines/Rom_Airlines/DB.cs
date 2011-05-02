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
                uTrue = (int)thisReader["uTrue"];
                uPass = (int)thisReader["uPass"];
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

        public static int addUser(string name, string surname, string password, string phone, string email, string birthday)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbConD"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            MySqlCommand thisCommand = thisConnection.CreateCommand();
            string select = string.Format("SELECT (SELECT COUNT(email) FROM members WHERE email='{0}') AS uTrue", email);
            thisConnection.Open();
            SqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = select;
            SqlDataReader thisReader = thisCommand.ExecuteReader();
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
                SqlCommand insert = thisConnection.CreateCommand();
                insert.CommandText = "INSERT INTO SystemUser(name,surname,password,phone,email,birthday,isAdmin,isActive) VALUES(@NAME,@SURNAME,@PASSWORD,@PHONE,@EMAIL,@DATE,@ISADMIN,@ISACTIVE); SET @ID = SCOPE_IDENTITY()";

                insert.Parameters.Add("@NAME", SqlDbType.NVarChar, 50).Value = name;
                insert.Parameters.Add("@SURNAME", SqlDbType.NVarChar, 50).Value = surname;
                insert.Parameters.Add("@PASSWORD", SqlDbType.NVarChar, 50).Value = password;
                insert.Parameters.Add("@PHONE", SqlDbType.NVarChar, 15).Value = phone;
                insert.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 50).Value = email;
                insert.Parameters.Add("@DATE", SqlDbType.SmallDateTime).Value = date;
                insert.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                insert.Parameters.Add("@ISADMIN", SqlDbType.Bit).Value = 0;
                insert.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = 1;
                thisConnection.Open();
                insert.ExecuteNonQuery();
                int newId = Convert.ToInt32(insert.Parameters["@ID"].Value);
                thisConnection.Close();
                return newId;
            }
        
        }
    }
}

// nabion la yarragim :P :P
