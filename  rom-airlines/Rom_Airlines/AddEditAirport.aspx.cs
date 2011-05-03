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
    public partial class AddEditAirport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            string select = "select name,id from city;";

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(select, connection);
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
                select = string.Format("SELECT c.name as cname,a.name as aname,c.id FROM airport a, city c WHERE a.id={0} AND c.id=a.cityid", aId);
                thisConnection.Open();
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader = thisCommand.ExecuteReader();

                thisReader.Read();
                nameBox.Text = thisReader["aname"].ToString();
                cityList.SelectedItem.Text = thisReader["cname"].ToString();
                thisReader.Close();
                thisConnection.Close();
                //}
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            int city = Convert.ToInt16(cityList.SelectedValue);

            if (!((Request.QueryString.Count) < 1))
            {
                int aId = Convert.ToInt32(Request.QueryString.Get("aId"));

                string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
                MySqlConnection thisConnection = new MySqlConnection(connection);
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                DataSet thisDataset = new DataSet();
                MySqlCommand update = thisConnection.CreateCommand();

                //int userId = Convert.ToInt32(Request.QueryString.Get("userId"));
                //int loggedId = (int)Session["loggedId"];
                //bool isAdmin = dbOps.IsAdmin(loggedId);

                //if (isAdmin || (userId == loggedId))
                //{

                update.CommandText = string.Format("UPDATE airport SET name=@NAME, cityId=@CID WHERE id='{0}'", aId);
                update.Parameters.Add("@NAME", MySqlDbType.VarChar, 30).Value = name;
                update.Parameters.Add("@CID", MySqlDbType.Int32).Value = city;
                //}

                thisConnection.Open();
                update.ExecuteNonQuery();

                string message = "alert('Airport editted. ID: " + aId + " ');window.location='" + ResolveUrl("~/ViewStaff.aspx") + "'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                //}
                //else
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bu kullanıcı için yetkili değilsiniz');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'", true);
            }
            else
            {



            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();

            MySqlCommand insert = thisConnection.CreateCommand();
            insert.CommandText = String.Format("INSERT INTO airport(name,cityid) VALUES('{0}',{1})",name,city);
            insert.ExecuteNonQuery();
            int id = Convert.ToInt32(insert.LastInsertedId);
            thisConnection.Close();
            string message = "alert('The airport is added. ID: " + id + " ');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                }

        }
    }
}


