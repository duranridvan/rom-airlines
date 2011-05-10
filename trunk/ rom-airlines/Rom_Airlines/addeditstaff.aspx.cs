using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;

namespace Rom_Airlines
{
    public partial class addeditstaff : System.Web.UI.Page
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
            if (!IsPostBack && (!((Request.QueryString.Count) < 1)))
            {
                addEditButton.Text = "Edit";
                int staffId = Convert.ToInt32(Request.QueryString.Get("staffId"));
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
                string select = string.Format("SELECT u.name,u.email,u.phonenumber,u.birthday,s.tcidno,s.job,s.salary FROM systemuser u, staff s WHERE u.id={0} AND u.id=s.id", staffId);
                thisConnection.Open();
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = select;
                MySqlDataReader thisReader = thisCommand.ExecuteReader();

                thisReader.Read();
                nameBox.Text = thisReader["name"].ToString();
                emailBox.Text = thisReader["email"].ToString();
                emailCBox.Text = thisReader["email"].ToString();
                phoneBox.Text = thisReader["phonenumber"].ToString();
                tcidBox.Text = thisReader["tcidno"].ToString();
                staffTypeSelection.SelectedItem.Text = thisReader["job"].ToString();
                birthdayBox.Text = thisReader["birthday"].ToString();
                salaryBox.Text = thisReader["salary"].ToString();
                staffTypeSelection.Enabled = false;
                thisReader.Close();
                thisConnection.Close();
                //}
            }
        }

        protected void addEditButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text,
            phone = phoneBox.Text,
            email = emailBox.Text,
            birthday = birthdayBox.Text,
            emailC = emailCBox.Text,
            passwordC = passwordCBox.Text,
            password = passwordBox.Text,
            tc = tcidBox.Text,
            
            staffS = staffTypeSelection.SelectedItem.Text;
            int staff = Convert.ToInt16(staffTypeSelection.SelectedValue);
            int salary = Convert.ToInt32(salaryBox.Text);

            if (!((Request.QueryString.Count) < 1))
            {
                if (!emailC.Equals(email)) Page_Load(sender, e);
                int staffId = Convert.ToInt32(Request.QueryString.Get("staffId"));

                string connection = ConfigurationManager.ConnectionStrings["projectdbConnection"].ToString();
                MySqlConnection thisConnection = new MySqlConnection(connection);
                MySqlCommand thisCommand = thisConnection.CreateCommand();
                DataSet thisDataset = new DataSet();
                MySqlCommand update = thisConnection.CreateCommand();

                //int userId = Convert.ToInt32(Request.QueryString.Get("userId"));
                //int loggedId = (int)Session["loggedId"];
                //bool isAdmin = dbOps.IsAdmin(loggedId);

                //if (isAdmin || (userId == loggedId))
                //{
                 //   bool isActive = isActiveCheckBox.Checked;
                    if (!passwordBox.Text.Equals(""))
                    {
                        if (!password.Equals(passwordC) ) Page_Load(sender, e);
                        else
                        {
                            string password2 = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5");
                            //int id = DB.addStaff(name, password, phone, email, birthday, tc, staff, staffS, salary);

                            update.CommandText = string.Format("UPDATE systemuser SET name=@NAME, password=@PASSWORD, phonenumber=@PHONE, email=@EMAIL, birthdate=@DATE WHERE id='{0}'", staffId);
                            update.Parameters.Add("@NAME", MySqlDbType.VarChar, 30).Value = name;
                            update.Parameters.Add("@PASSWORD", MySqlDbType.VarChar, 64).V230).Value = name;
                            update.Parameters.Add("@PHONE", MySqlDbType.VarChar, 15).Value = phone;
                            update.Parameters.Add("@EMAIL", MySqlDbType.VarChar, 30).Value = email;
                            update.Parameters.Add("@DATE", MySqlDbType.Date).Vale = birthday;
                        }
                    }
                    else{
                        update.CommandText = string.Format("UPDATE systemuser SET name=@NAME, phonenumber=@PHONE, email=@EMAIL, birthdate=@DATE WHERE id='{0}'", staffId);
                            update.Parameters.Add("@NAME", MySqlDbType.VarChar, 30).Value = name;
                            update.Parameters.Add("@PHONE", MySqlDbType.VarChar, 15).Value = phone;
                            update.Parameters.Add("@EMAIL", MySqlDbType.VarChar, 30).Value = email;
                            update.Parameters.Add("@DATE", MySqlDbType.Date).Value = birthday;

                    }

                    thisConnection.Open();
                    update.ExecuteNonQuery();

                update.CommandText = string.Format("UPDATE staff SET salary=@SAL, tcidno=@TC WHERE id='{0}'", staffId);
                            update.Parameters.Add("@SAL", MySqlDbType.Int32, 30).Value =salary;
                            update.Parameters.Add("@TC", MySqlDbType.VarChar, 50).Value = tc;


                            update.ExecuteNonQuery();
                            
                            thisConnect







                    string message = "alert('Staff editted. ID: " + staffId + " ');window.location='" + Resolve.aspxUrl("~/show.aspx?pageId=1") + "'";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                //}
                //else
                  //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bu kullanıcı için yetkili değilsiniz');window.location='" + ResolveUrl("~/show.aspx?pageId=3") + "'", true);
            }
            else
            {
                if ((!password.Equals(passwordC)) || !emailC.Equals(email)) Page_Load(sender, e);
                else
                {

                    int id = DB.addStaff(name, password, phone, email, birthday, tc, staff, staffS, salary);
                    string message;
                    if (id < 0)
                        message = "alert('This e-mail is already signed up!');";
                    else
                        message = "alert('The user is added. ID: " + id + " ');window.locviewstaff.aspxUrl("~/show.aspx?pageId=3") + "'";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", message, true);
                   }

        protected void clearDeleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/addeditstaff.aspx");




            


        }
