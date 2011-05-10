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
    public partial class editLicencePilot : System.Web.UI.Page
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
            DataSet thisDataset = new DataSet();
            string select = string.Format("select s.name,s.id from SystemUser s, Pilot p where s.id = p.id;");

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(select, connection);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "SystemUser");
            pilotList.DataSource = myDataSet;
            pilotList.DataTextField = "name";
            pilotList.DataValueField = "id";
            if (!IsPostBack)
                pilotList.DataBind();
        }

        protected void listButton_Click(object sender, EventArgs e)
        {
            int pilotId = Convert.ToInt32( pilotList.SelectedValue);

            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            //DataSet thisDataset1 = new DataSet();
            string select1 = string.Format("select l.name,l.id from pilothaslicence p, licence l where p.pilotid={0} AND p.licenceid = l.id;",pilotId);

            MySqlDataAdapter myDataAdapter1 = new MySqlDataAdapter(select1, connection);
            DataSet myDataSet1 = new DataSet();
            myDataAdapter1.Fill(myDataSet1, "licence");
            hasBox.DataSource = myDataSet1;
            hasBox.DataTextField = "name";
            hasBox.DataValueField = "id";
            //if (!IsPostBack)
                hasBox.DataBind();








                string select2 = string.Format("select l.name,l.id from licence l where l.id not in (select licenceid as id from pilothaslicence where pilotid={0})", pilotId);

                MySqlDataAdapter myDataAdapter2 = new MySqlDataAdapter(select2, connection);
                DataSet myDataSet2 = new DataSet();
                myDataAdapter2.Fill(myDataSet2, "licence");
                otherBox.DataSource = myDataSet2;
                otherBox.DataTextField = "name";
                otherBox.DataValueField = "id";
                //if (!IsPostBack)
                otherBox.DataBind();





        }

        protected void addButton_Click(object sender, EventArgs e)
        {


            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();

            MySqlCommand insert = thisConnection.CreateCommand();
            
            string pilotid = pilotList.SelectedValue;
            foreach( ListItem x in otherBox.Items){
                if(x.Selected==true){
                    
                    insert.CommandText = String.Format("INSERT INTO pilothaslicence(pilotid,licenceid) VALUES({0},{1})",pilotid,x.Value);
                    insert.ExecuteNonQuery();
                }
            }
            thisConnection.Close();
            listButton_Click(sender, e);
            //otherBox.DataBind();
            //hasBox.DataBind();

        }

        protected void removeButton_Click(object sender, EventArgs e)
        {

            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            thisConnection.Open();

            MySqlCommand insert = thisConnection.CreateCommand();

            string pilotid = pilotList.SelectedValue;
            foreach (ListItem x in hasBox.Items)
            {
                if (x.Selected == true)
                {

                    insert.CommandText = String.Format("DELETE FROM pilothaslicence WHERE pilotid={0} AND licenceid={1}", pilotid, x.Value);
                    insert.ExecuteNonQuery();
                }
            }
            thisConnection.Close();
            listButton_Click(sender, e);


        }

    }
}
