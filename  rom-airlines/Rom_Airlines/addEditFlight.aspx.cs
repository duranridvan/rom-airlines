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
    public partial class addEditFlight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            string select = "select name,id from plane;";

            MySqlDataAdapter planeAdapter = new MySqlDataAdapter(select, connection);
            string select = "select name,id from airpot;";
            MySqlDataAdapter airportAdepter = new MySqlDataAdapter(select, connection);
            
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "city");
            cityList.DataSource = myDataSet;
            cityList.DataTextField = "name";
            cityList.DataValueField = "id";
            if (!IsPostBack)
                cityList.DataBind();

            if (!IsPostBack && (!((Request.QueryString.Count) < 1)))
            {
                addButton.Text = "Edit";
                int aId = Convert.ToInt32(Request.QueryString.Get("aId"));
                //int loggedId = (int)Session["loggedId"];
                //bool loggedIn = (bool)Session["loggedIn"];
                //bool isAdmin = dbOps.IsAdmin(loggedId);
                //if (!loggedIn)
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oturum açmadınız.');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'", true);
                //else if (!isAdmin && (userId != loggedId))
                //{
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bu kullanıcı için yetkili değilsiniz');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'", true);
                //}
                //else
                //{

                MySqlConnection thisConnection = new MySqlConnection(connection);
                DataSet thisDataset = new DataSet();
                select = string.Format("SELECT c.name as cname,a.name as aname,c.id as cid FROM airport a, city c WHERE a.id={0} AND c.id=a.cityid", aId);
                thisConnection.Open();
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader = thisCommand.ExecuteReader();

                thisReader.Read();
                nameBox.Text = thisReader["aname"].ToString();
                cityList.SelectedValue = thisReader["cid"].ToString();
                thisReader.Close();
                thisConnection.Close();
                //}
            }
        }

    }
}
