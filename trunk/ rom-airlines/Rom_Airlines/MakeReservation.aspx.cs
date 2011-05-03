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
    public partial class MakeReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            string select = "select concat(c.name,'-',a.name) as aname, a.id as id from Airport a, City c where c.id = a.cityId;";

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(select, connection);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "Airport");
            From.DataSource = myDataSet;
            From.DataTextField = "aname";
            From.DataValueField = "id";
            select = "select concat(c.name,'-',a.name) as aname, a.id as id from Airport a, City c where c.id = a.cityId;";
            myDataAdapter = new MySqlDataAdapter(select, connection);
            myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "Airport");
            To.DataSource = myDataSet;
            To.DataTextField = "aname";
            To.DataValueField = "id";
            if (!IsPostBack)
            {
                From.DataBind();
                To.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string dDate, rDate;
            dDate = TextBox2.Text;
            rDate = TextBox3.Text;
            int noOfPassengers = Convert.ToInt16(TextBox1.Text);
            int y = x;
            Response.Redirect("~/MRAvailibity.aspx?dDate=" + dDate +"&rDate="+rDate+"&from="+From.DataValueField+"&to="+To.DataValueField+"&noPass="+noOfPassengers+"&type="+x);

        }
        int x;
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            x = 1;
        }

        protected void RoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            x = 2;
        }
    }
}
