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
    public partial class ManageFlight : System.Web.UI.Page
    {
        string input;
        string connectionString;
        MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            //string input = TextBox1.Text;
            string selectQuery = String.Format("SELECT F.id as 'Flight No', F.fdate as 'Date', DA.name as 'Departure Airport', LA.name as 'Landing Airport', F.departureTime as 'Departure Time', F.landingTime as 'Landing Time', P.name as 'Plane' FROM Flight F, Airport DA, Airport LA, Plane P WHERE F.departureAirport=DA.id and F.landingAirport=LA.id and P.id = F.planeId");
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            GridFlights.DataSource = myDataTable;
            GridFlights.DataBind();

        }

        protected string parseDate(string date)
        {
            return date.Substring(6, 4) + "-" + date.Substring(3, 2) + "-" + date.Substring(0, 2);
        }

        protected void GridFlights_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(GridFlights.Rows[e.NewEditIndex].Cells[1].Text);
            string date = parseDate(GridFlights.Rows[e.NewEditIndex].Cells[2].Text);
            Response.Redirect("~/AddEditFlight.aspx?fId=" + id + "&date=" + date);
        }

        protected void GridFlights_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridFlights.Rows[e.RowIndex].Cells[1].Text);
            string date = parseDate(GridFlights.Rows[e.RowIndex].Cells[2].Text);
            connection = new MySqlConnection(connectionString);
            connection.Open();
            string deleteQuery = String.Format("delete from flight where id='{0}' fdate = '{1}'", id, date);
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);
            command.ExecuteNonQuery();
            GridFlights.DataBind();
            connection.Close();
            Page_Load(sender, e);
        }

    }
}