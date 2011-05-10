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
    public partial class addEditPlane : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
                Response.Redirect("~/Default.aspx");
            bool isLogged = (bool)Session["loggedIn"];
            int userId = Convert.ToInt32(Session["loggedId"]);
            if (!isLogged)
                Response.Redirect("~/Default.aspx");

            string job = Session["job"].ToString();
            if (!job.Equals("System Admin"))
                Response.Redirect("~/Default.aspx");
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            string select = "select name,id from planemodel;";

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(select, connection);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "planemodel");
            planeModelList.DataSource = myDataSet;
            planeModelList.DataTextField = "name";
            planeModelList.DataValueField = "id";
            if (!IsPostBack)
                planeModelList.DataBind();

            if (!IsPostBack && (!((Request.QueryString.Count) < 1)))
            {
                addeditbutton.Text = "Edit";
                int planeId = Convert.ToInt32(Request.QueryString.Get("planeId"));
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
                select = string.Format("SELECT m.name as mname,p.name as pname,m.id as mid, p.id as pid FROM plane p, planemodel m WHERE p.id={0} AND m.id=p.modelid", planeId);
                thisConnection.Open();
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader = thisCommand.ExecuteReader();

                thisReader.Read();
                nameBox.Text = thisReader["pname"].ToString();
                //planeModelList.SelectedItem.Text = thisReader["mname"].ToString();
                planeModelList.SelectedValue = thisReader["mid"].ToString();
                thisReader.Close();
                thisConnection.Close();
                //}
            }
        }

        protected void addeditbutton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            int model = Convert.ToInt16(planeModelList.SelectedValue);

            if (!((Request.QueryString.Count) < 1))
            {
                int planeId = Convert.ToInt32(Request.QueryString.Get("planeId"));

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

                update.CommandText = string.Format("UPDATE plane SET name=@NAME, modelId=@MID WHERE id='{0}'", planeId);
                update.Parameters.Add("@NAME", MySqlDbType.VarChar, 30).Value = name;
                update.Parameters.Add("@MID", MySqlDbType.Int32).Value = model;
                //}

                thisConnection.Open();
                update.ExecuteNonQuery();

                string message = "alert('Plane editted. ID: " + planeId + " ');window.location='" + ResolveUrl("~/manageplane.aspx") + "'";
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
            insert.CommandText = String.Format("INSERT INTO plane(name,modelid) VALUES('{0}',{1})",name,model);
            insert.ExecuteNonQuery();
            int id = Convert.ToInt32(insert.LastInsertedId);
            thisConnection.Close();
            string message = "alert('The plane is added. ID: " + id + " ');window.location='" + ResolveUrl("~/manageplane.aspx") + "'";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                }

        

        }
    }
}
