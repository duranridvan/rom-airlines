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
    public partial class WebForm1 : System.Web.UI.Page
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
            DropDownList1.DataSource = myDataSet;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "id";
            if (!IsPostBack)
                DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string date = TextBox1.Text;
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            MySqlConnection thisConnection = new MySqlConnection(connection);
            MySqlCommand insert = thisConnection.CreateCommand();
            string ss = DropDownList2.SelectedItem.Text;
            string sss = DropDownList1.SelectedValue;
            string select = String.Format("SELECT (SELECT COUNT(*) FROM Flies WHERE flightDate='{0}' and flightId = '{1}'and pilotId = '{2}') AS uTrue", date, ss, sss);
            thisConnection.Open();
            insert = thisConnection.CreateCommand();
            insert.CommandText = select;
            MySqlDataReader thisReader = insert.ExecuteReader();
            int uTrue = 0;
            while (thisReader.Read())
            {
                uTrue = Convert.ToInt16(thisReader["uTrue"]);
            }
            thisReader.Close();

            if (uTrue > 0)
            {
                string message = "alert('The cabin attendant " + DropDownList1.SelectedItem.Text + " is already assigned to flightNo:" + (DropDownList2.SelectedItem.Text) + " ');window.location='" + ResolveUrl("~/AssignPilot.aspx") + "'";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                return;
            }
            select = "INSERT INTO Flies(pilotId,flightId,flightDate) VALUES (@staffId,@flightId,@date);";
            insert.CommandText = select;
            insert.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            insert.Parameters.Add("@staffId", MySqlDbType.Int16).Value = Convert.ToInt16(DropDownList1.SelectedValue);
            insert.Parameters.Add("@flightId", MySqlDbType.Int16).Value = Convert.ToInt16(DropDownList2.SelectedItem.Text);
            insert.ExecuteNonQuery();
            thisConnection.Close();
            string message2 = "alert('The pilot " + DropDownList1.SelectedItem.Text + " is assigned to flightNo:" + (DropDownList2.SelectedItem.Text) + " ');window.location='" + ResolveUrl("~/AssignPilot.aspx") + "'";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message2, true);
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            string s = TextBox1.Text;
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select id from Flight where fdate ='" + s + "'", connection);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "Flight");
            DropDownList2.DataSource = myDataSet;
            DropDownList2.DataTextField = "id";
            DropDownList2.DataBind();
        }
    }
}
