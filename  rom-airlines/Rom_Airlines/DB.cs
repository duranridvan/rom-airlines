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
        public static int addStaff(string name, string password, string phone, string email, string birthday, string tc, int staff,string staffS,int salary) {
            int newId = addSystemUser(name, password, password, email, birthday);
            if (newId == -1) return -1;
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();

            MySqlCommand insert = thisConnection.CreateCommand();
            insert.CommandText = String.Format("INSERT INTO Staff(id,salary,job,tcidno) VALUES({0},{1},'{2}','{3}')",newId,salary,staffS,tc);
            //insert.Parameters.Add("@ID", MySqlDbType.Int16).Value = newId;
            insert.ExecuteNonQuery();
            thisConnection.Close();
            switch (staff)
            {
                case 0:
                    insert.CommandText = String.Format("INSERT INTO SystemAdmin(id) VALUES({0})", newId);
                    break;
                case 1:
                    insert.CommandText = String.Format("INSERT INTO SalesOfficer(id) VALUES({0})", newId);
                    break;
                case 2:
                    insert.CommandText = String.Format("INSERT INTO cabinattendant(id) VALUES({0})", newId);
                    break;
                case 3:
                    insert.CommandText = String.Format("INSERT INTO pilot(id) VALUES({0})", newId);
                    break;
                case 4:
                    insert.CommandText = String.Format("INSERT INTO checkinofficer(id) VALUES({0})", newId);
                    break;
                default:
                    return -1;
                    break;
            }
            thisConnection.Open();
            insert.ExecuteNonQuery();
            thisConnection.Close();
            
            return newId; 
        
        }

        public static int addSystemUser(string name, string password, string phone, string email, string birthday)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            int uTrue = 0;
            string select = string.Format("SELECT (SELECT COUNT(email) FROM SystemUser WHERE email='{0}') AS uTrue", email);
            thisConnection.Open();
            MySqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = select;
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            
            while (thisReader.Read())
            {
                uTrue = Convert.ToInt16(thisReader["uTrue"]);
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
                insert.CommandText = "INSERT INTO SystemUser(name,password,phoneNumber,email,birthday) VALUES(@NAME,@PASSWORD,@PHONE,@EMAIL,@DATE); ";
                insert.Parameters.Add("@NAME", MySqlDbType.VarChar, 50).Value = name;
                insert.Parameters.Add("@PASSWORD", MySqlDbType.VarChar, 50).Value = password;
                insert.Parameters.Add("@PHONE", MySqlDbType.VarChar, 15).Value = phone;
                insert.Parameters.Add("@EMAIL", MySqlDbType.VarChar, 50).Value = email;
                insert.Parameters.Add("@DATE", MySqlDbType.Date).Value = birthday;
                //insert.Parameters.Add("@ID", MySqlDbType.Int16).Direction = ParameterDirection.Output;
                thisConnection.Open();
                insert.ExecuteNonQuery();
                select = string.Format("SELECT id AS newId FROM SystemUser WHERE email='{0}'", email);
                thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader2;
                
                thisReader2 = thisCommand.ExecuteReader();
                thisReader2.Read();
                int newId = Convert.ToInt16(thisReader2["newId"]);
                thisReader2.Close();
                thisConnection.Close();
                return newId;
            
            }
        }
        
        public static int addUser(string name, string password, string phone, string email, string birthday)
        {
            int newId = addSystemUser(name,password,phone,email,birthday);
            if(newId==-1) return -1;
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();
            
            MySqlCommand insert = thisConnection.CreateCommand();
            insert.CommandText = "INSERT INTO Customer(id) VALUES("+newId+")";
            insert.Parameters.Add("@ID", MySqlDbType.Int16).Value = newId ;
            insert.ExecuteNonQuery();
            thisConnection.Close();
            return newId;
            }
        
        }
    }

