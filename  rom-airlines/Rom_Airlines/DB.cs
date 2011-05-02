using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Mysql.

namespace Rom_Airlines
{
    public class DB
    {
        public static string login()
        {
            string connection = "Server=139.179.11.31;Database=r_duran;Uid=r_duran;Pwd=9rh4vxo;";//ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            SqlConnection thisConnection = new SqlConnection(connection);
            SqlCommand thisCommand = thisConnection.CreateCommand();
            DataSet thisDataset = new DataSet();
            string select = "select * from customer";
            thisConnection.Open();
            thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = select;
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            thisReader.Read();
            string username = thisReader["name"].ToString();
            thisReader.Close();
            thisConnection.Close();
            return username;


            
           
        }
    }
}
