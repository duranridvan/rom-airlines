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








    }
}
