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
    public partial class AddEditPlaneModel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && (!((Request.QueryString.Count) < 1)))
            {
                addEditButton.Text = "Edit";
                int modelId = Convert.ToInt32(Request.QueryString.Get("modelId"));
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
                string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
                MySqlConnection thisConnection = new MySqlConnection(connection);
                DataSet thisDataset = new DataSet();
                string select = string.Format("SELECT name, busscapacity,firstcapacity,econcapacity FROM planemodel WHERE id={0} ", modelId);
                thisConnection.Open();
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader = thisCommand.ExecuteReader();

                thisReader.Read();
                nameBox.Text = thisReader["name"].ToString();
                bussBox.Text = thisReader["busscapacity"].ToString();
                firstBox.Text = thisReader["firstcapacity"].ToString();
                econBox.Text = thisReader["econcapacity"].ToString();

                thisReader.Close();
                thisConnection.Close();
                //}
            }

        }

        protected void addEditButton_Click(object sender, EventArgs e)
        {






            string name = nameBox.Text;
            int busscap=Convert.ToInt32(bussBox.Text),
                firstcap=Convert.ToInt32(firstBox.Text),
                econcap=Convert.ToInt32(econBox.Text);



            if (!((Request.QueryString.Count) < 1))
            {
                int modelid = Convert.ToInt32(Request.QueryString.Get("modelId"));

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

                update.CommandText = string.Format("UPDATE planemodel SET name=@NAME, busscapacity=@BCAP , firstcapacity=@FCAP, econcapacity=@ECAP WHERE id='{0}'", modelid);
                update.Parameters.Add("@NAME", MySqlDbType.VarChar, 30).Value = name;
                update.Parameters.Add("@BCAP", MySqlDbType.Int32).Value = busscap;
                update.Parameters.Add("@FCAP", MySqlDbType.Int32).Value = firstcap;
                update.Parameters.Add("@ECAP", MySqlDbType.Int32).Value = econcap;
                //}

                thisConnection.Open();
                update.ExecuteNonQuery();

                string message = "alert('Plane Model editted. ID: " + modelid + " ');window.location='" + ResolveUrl("~/manageplanemodel.aspx") + "'";
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
            insert.CommandText = String.Format("INSERT INTO planemodel(name,busscapacity,firstcapacity,econcapacity) VALUES('{0}',{1},{2},{3})", name, busscap,firstcap,econcap);
            insert.ExecuteNonQuery();
            int id = Convert.ToInt32(insert.LastInsertedId);
            thisConnection.Close();
            string message = "alert('The plane model is added. ID: " + id + " ');window.location='" + ResolveUrl("~/manageplanemodel.aspx") + "'";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                }














































        }

        
    }
}
