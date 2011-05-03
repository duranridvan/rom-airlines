﻿using System;
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
    public partial class ManageAirport : System.Web.UI.Page
    {
        string input;
        string connectionString;
        MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            string selectQuery = String.Format("SELECT P.id as ID, P.name as 'Plane Name', M.name as 'Plane Model' FROM PlaneModel M, Plane P WHERE P.modelId = M.id");
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            GridAirports.DataSource = myDataTable;
            GridAirports.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        protected void GridAirports_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(GridAirports.Rows[e.NewEditIndex].Cells[1].Text);
            Response.Redirect("~/AddEditAirport.aspx?aId=" + id);
        }
        protected void GridAirports_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridAirports.Rows[e.RowIndex].Cells[1].Text);
            connection = new MySqlConnection(connectionString);
            connection.Open();
            string deleteQuery = String.Format("delete from airport where id='{0}'", id);
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);
            command.ExecuteNonQuery();
            GridAirports.DataBind();
            connection.Close();
            Page_Load(sender, e);
        }
    }
}