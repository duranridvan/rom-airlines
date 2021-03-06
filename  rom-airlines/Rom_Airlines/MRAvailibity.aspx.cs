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
    public partial class MRAvailibity : System.Web.UI.Page
    {
        string connectionString;
        MySqlConnection connection;
        int noPass;
        int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string dDate = Request.QueryString.Get("dDate");
            string rDate = Request.QueryString.Get("rDate");
            int from = Convert.ToInt32(Request.QueryString.Get("from"));
            int to = Convert.ToInt32(Request.QueryString.Get("to"));
            noPass = Convert.ToInt32(Request.QueryString.Get("noPass"));
            type = Convert.ToInt32(Request.QueryString.Get("type"));

            connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ToString();
            DataSet thisDataset = new DataSet();
            connection = new MySqlConnection(connectionString);
            string selectQuery = String.Format(
                "SELECT F.id as 'Flight No', F.fdate as 'Date', CONCAT(DAC.name,' ',DA.name) as 'Dep. Airport', CONCAT(LAC.name,' ',LA.name) as 'Lan. Airport', F.departuretime as 'Dep. Time', F.landingtime as 'Lan. Time'"+
                " FROM Flight F, Airport DA, Airport LA, City DAC, City LAC" + 
                " WHERE F.fDate = '{0}' and F.departureAirport = '{1}' and  F.landingAirport= '{2}' and "+
                " F.departureAirport=DA.id and DA.cityId = DAC.id and F.landingAirport=LA.id and LA.cityId=LAC.id"
                ,dDate,from,to);
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(command);
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            Flights1Grid.DataSource = myDataTable;
            Flights1Grid.DataBind();

            if (type == 2)
            {
                selectQuery = String.Format(
                    "SELECT F.id as 'Flight No', F.fdate as 'Date', CONCAT(DAC.name,' ',DA.name) as 'Dep. Airport', CONCAT(LAC.name,' ',LA.name) as 'Lan. Airport', F.departuretime as 'Dep. Time', F.landingtime as 'Lan. Time'" +
                    " FROM Flight F, Airport DA, Airport LA, City DAC, City LAC" +
                    " WHERE F.fDate = '{0}' and F.departureAirport = '{1}' and  F.landingAirport= '{2}' and " +
                    " F.departureAirport=DA.id and DA.cityId = DAC.id and F.landingAirport=LA.id and LA.cityId=LAC.id"
                    , rDate, to, from);
                command = new MySqlCommand(selectQuery, connection);
                myDataAdapter = new MySqlDataAdapter(command);
                myDataTable = new DataTable();
                myDataAdapter.Fill(myDataTable);
                Flights2Grid.DataSource = myDataTable;
                Flights2Grid.DataBind();
            }
            if (type == 1)
            {
                Button2.Visible = false;
                Button4.Visible = false;
                returnRow.Visible = false;
            }
            try { Flights2Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow"); }
            catch (Exception ex) { }
            try { Flights1Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow"); }
            catch (Exception ex) { }

        }

        protected void Flights1Grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flights1Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow");
            try { Flights2Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow"); }
            catch (Exception ex) { }
        }

        protected void Flights2Grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flights2Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow");
            try { Flights1Grid.SelectedRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "yellow"); }
            catch (Exception ex) { }
        }
        
        protected string parseDate(string date)
        {
            return date.Substring(6, 4) + "-" + date.Substring(3, 2) + "-" + date.Substring(0, 2);
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            string did, rid="", ddate, rdate="";
            try
            {
                did = Flights1Grid.SelectedRow.Cells[1].Text;
                if(type==2)
                    rid = Flights2Grid.SelectedRow.Cells[1].Text;
                ddate = parseDate(Flights1Grid.SelectedRow.Cells[2].Text);
                if(type==2)
                    rdate = parseDate(Flights2Grid.SelectedRow.Cells[2].Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Fligh is not selected')", true);
                return;
            }

            connection = new MySqlConnection(connectionString);
            connection.Open();
            string insertQuery = "insert into reservation() values()";
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();
            int resid = (int)command.LastInsertedId;

            insertQuery = String.Format("insert into reservationflight(flightId,flightDate,reserveId)"+
                                        " values('{0}','{1}','{2}')",did,ddate,resid );
            command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            if (type == 2)
            {
                insertQuery = String.Format("insert into reservationflight(flightId,flightDate,reserveId)" +
                                            " values('{0}','{1}','{2}')", rid, rdate, resid);
                command = new MySqlCommand(insertQuery, connection);
                command.ExecuteNonQuery();
            }

            Response.Redirect("~/AddPassenger.aspx?rId=" + resid + "&noPass=" + noPass);


        }
    }
}
