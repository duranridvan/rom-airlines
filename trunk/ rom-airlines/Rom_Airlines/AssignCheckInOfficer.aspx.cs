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
    public partial class AssignCheckInOfficer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            string select = "select s.name,s.id from SystemUser s,CheckInOfficer c where s.id = c.id;";

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(select, connection);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "SystemUser");
            OfficerList.DataSource = myDataSet;
            OfficerList.DataTextField = "name";
            OfficerList.DataValueField = "id";
            myDataAdapter = new MySqlDataAdapter("select concat(c.name,'-',a.name) as idname, a.id as id from Airport a, City c where c.id = a.cityId", connection);
            myDataSet = new DataSet();
            //DataTable[] dT = new DataTable[2];
            //dT[0].TableName = "Airport";
            //dT[1].TableName ="City";
            myDataAdapter.Fill(myDataSet, "Airport");
            AirportList.DataSource = myDataSet;
            AirportList.DataTextField = "idname";
            AirportList.DataValueField = "id";
            if (!IsPostBack)
            {
                AirportList.DataBind();
                OfficerList.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();
            MySqlCommand insert = thisConnection.CreateCommand();
            string ss = OfficerList.SelectedValue;
            string sss = AirportList.SelectedValue;
            string select = "update CheckInOfficer set AirportId = @AirportId where id  = @id;";
            insert.CommandText = select;
            insert.Parameters.Add("@AirportId", MySqlDbType.Int16).Value = Convert.ToInt16(AirportList.SelectedValue);
            insert.Parameters.Add("@id", MySqlDbType.Int16).Value = Convert.ToInt16(OfficerList.SelectedValue);
            insert.ExecuteNonQuery();
            thisConnection.Close();
            string message2 = "alert('The officer " + OfficerList.SelectedItem.Text + " is assigned to airport:" + (AirportList.SelectedItem.Text) + " ');window.location='" + ResolveUrl("~/AssignCheckInOfficer.aspx") + "'";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message2, true);

        }
    }
}
