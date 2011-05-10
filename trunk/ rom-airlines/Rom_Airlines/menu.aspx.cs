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
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
                Response.Redirect("~/Default.aspx");
            bool isLogged = (bool)Session["loggedIn"];
            int userId = Convert.ToInt32(Session["loggedId"]);
            if (!isLogged) 
                Response.Redirect("~/Default.aspx");

            CreateXmlMenu();
        }

        private void CreateXmlMenu()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/App_Data/MenuData.xml"));

            string strMenu = string.Empty;
            strMenu +=
                "<div id=\"MenuContainer\">";
            strMenu += "<ul id=\"XmlMenu\">";

            for (int i = 0; i < ds.Tables["items"].Rows.Count; i++)
            {
                DataRow dr = ds.Tables["items"].Rows[i];

                    strMenu += "<li>";
                    strMenu += "<a href=\"" +
                    this.ResolveUrl(dr["ItemUrl"].ToString()) + "\" " +
                    "target=\"" +
                    dr["ItemTarget"].ToString() + "\" " +
                    "title=\"\">" +
                    //dr["ItemTitle"].ToString() + "\">" +
                    dr["ItemText"].ToString() + "</a>";
                    strMenu += "</li>";

            }
            strMenu += "</li>";
            strMenu += "</div>";

            Literal1.Text = strMenu;
        }
    }
}
