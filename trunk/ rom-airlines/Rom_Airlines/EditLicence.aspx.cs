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
    public partial class EditLicence : System.Web.UI.Page
    {
        int licenceId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
                Response.Redirect("~/Default.aspx");
            bool isLogged = (bool)Session["loggedIn"];
            int userId = Convert.ToInt32(Session["loggedId"]);
            if (!isLogged)
                Response.Redirect("~/Default.aspx");



            if (!((Request.QueryString.Count) < 1))
            {
                licenceId = Convert.ToInt32(Request.QueryString.Get("licenceId"));
            }
            else
                Response.Redirect("~/managelicences.aspx");
            if (!IsPostBack)
            {
                string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
                MySqlConnection thisConnection = new MySqlConnection(connection);
                DataSet thisDataset = new DataSet();
                string select = string.Format("SELECT name FROM licence WHERE id={0}", licenceId);
                thisConnection.Open();
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader = thisCommand.ExecuteReader();

                thisReader.Read();
                nameBox.Text = thisReader["name"].ToString();
                thisReader.Close();
                thisConnection.Close();


                string select1 = string.Format("select m.name,m.id from licenceforplane p, planemodel m where p.licenceid={0} AND p.planemodelid = m.id;", licenceId);

                MySqlDataAdapter myDataAdapter1 = new MySqlDataAdapter(select1, connection);
                DataSet myDataSet1 = new DataSet();
                myDataAdapter1.Fill(myDataSet1, "planemodel");
                hasBox.DataSource = myDataSet1;
                hasBox.DataTextField = "name";
                hasBox.DataValueField = "id";
                //if (!IsPostBack)
                hasBox.DataBind();

                string select2 = string.Format("select m.name,m.id from planemodel m where m.id not in (select planemodelid as id from licenceforplane where licenceid={0})", licenceId);

                MySqlDataAdapter myDataAdapter2 = new MySqlDataAdapter(select2, connection);
                DataSet myDataSet2 = new DataSet();
                myDataAdapter2.Fill(myDataSet2, "planemodel");
                otherBox.DataSource = myDataSet2;
                otherBox.DataTextField = "name";
                otherBox.DataValueField = "id";
                //if (!IsPostBack)
                otherBox.DataBind();

            }
            

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();

            MySqlCommand insert = thisConnection.CreateCommand();
            
            foreach (ListItem x in otherBox.Items)
            {
                if (x.Selected == true)
                {

                    insert.CommandText = String.Format("INSERT INTO licenceforplane(licenceid,planemodelid) VALUES({0},{1})", licenceId, x.Value);
                    insert.ExecuteNonQuery();
                }
            }
            thisConnection.Close();
            Page_Load2(sender, e);
        }

        protected void removeButton_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();

            MySqlCommand insert = thisConnection.CreateCommand();

            foreach (ListItem x in hasBox.Items)
            {
                if (x.Selected == true)
                {
                    insert.CommandText = String.Format("DELETE FROM licenceforplane WHERE planemodelid={0} AND licenceid={1}", x.Value,licenceId);
                    insert.ExecuteNonQuery();
                }
            }
            thisConnection.Close();
            Page_Load2(sender, e);
        }

        protected void otherBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = otherBox.SelectedIndex;
        }




        protected void Page_Load2(object sender, EventArgs e)
        {
                string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
                MySqlConnection thisConnection = new MySqlConnection(connection);
                DataSet thisDataset = new DataSet();
                string select = string.Format("SELECT name FROM licence WHERE id={0}", licenceId);
                thisConnection.Open();
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader = thisCommand.ExecuteReader();

                thisReader.Read();
                nameBox.Text = thisReader["name"].ToString();
                thisReader.Close();
                thisConnection.Close();









                /*
                 * 		DELETE FROM Licence WHERE id = $id
    Edit Licence
            INSERT INTO LicenceForPlane(licenceId,planeModelId) 
                    VALUES ($licenceID, $model)
            DELETE FROM LicenceForPlane WHERE licenceId = $licence AND 					planeModelId = $ model
    */





                //DataSet thisDataset1 = new DataSet();
                string select1 = string.Format("select m.name,m.id from licenceforplane p, planemodel m where p.licenceid={0} AND p.planemodelid = m.id;", licenceId);

                MySqlDataAdapter myDataAdapter1 = new MySqlDataAdapter(select1, connection);
                DataSet myDataSet1 = new DataSet();
                myDataAdapter1.Fill(myDataSet1, "planemodel");
                hasBox.DataSource = myDataSet1;
                hasBox.DataTextField = "name";
                hasBox.DataValueField = "id";
                //if (!IsPostBack)
                hasBox.DataBind();








                string select2 = string.Format("select m.name,m.id from planemodel m where m.id not in (select planemodelid as id from licenceforplane where licenceid={0})", licenceId);

                MySqlDataAdapter myDataAdapter2 = new MySqlDataAdapter(select2, connection);
                DataSet myDataSet2 = new DataSet();
                myDataAdapter2.Fill(myDataSet2, "planemodel");
                otherBox.DataSource = myDataSet2;
                otherBox.DataTextField = "name";
                otherBox.DataValueField = "id";
                //if (!IsPostBack)
                otherBox.DataBind();
        }

        protected void changenamebutton_Click(object sender, EventArgs e)
        {


                string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
                MySqlConnection thisConnection = new MySqlConnection(connection);
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                DataSet thisDataset = new DataSet();
                MySqlCommand update = thisConnection.CreateCommand();


                update.CommandText = string.Format("UPDATE licence SET name='{0}' where id={1}", nameBox.Text,licenceId);

                thisConnection.Open();
                update.ExecuteNonQuery();
                thisConnection.Close();
        }




















    }
}
