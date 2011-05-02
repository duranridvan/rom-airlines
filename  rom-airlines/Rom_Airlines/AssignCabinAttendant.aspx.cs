using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
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
    public partial class AssignCabinAttendant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            string select = string.Format("select s.name from SystemUser s, CabinAttendant c where s.id = c.id;");
            
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(select, connection);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet,"SystemUser");
            DropDownList1.DataSource = myDataSet;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataBind();
            myDataAdapter = new MySqlDataAdapter("select id from Flight", connection);
            myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "Flight");
            DropDownList2.DataSource = myDataSet;
            DropDownList2.DataTextField = "id";
            DropDownList2.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string date =DateBox.Text;
            //INSERT INTO Assigned VALUES ($staffId,$flighId,$date)
        }
    }
}
