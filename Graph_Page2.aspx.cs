using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

using System.Web.UI.DataVisualization.Charting;


public partial class Graph_Page2: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
            con.Open();
            using (OleDbCommand selectcmd = new OleDbCommand("SP_Graph_verticalList", con))
            {
                selectcmd.CommandType = CommandType.StoredProcedure;
                OleDbDataReader dr = selectcmd.ExecuteReader();

                while (dr.Read())
                {
                    RadioButtonList1.Items.Add(dr[0].ToString());
                }
            }


            con.Close();
        }
    }

    public object mmm { get; set; }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Chart1.Visible = true;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
        con.Open();
        using (OleDbCommand selectcmd = new OleDbCommand("SP_Graph_details", con))
        {
            //selectcmd.Connection = con;
            selectcmd.CommandType = System.Data.CommandType.StoredProcedure;
            // string command="SELECT Sum(a.Demand_Number_Closed_Req) AS Number_Closed_Req, Sum(a.Demand_Number_Open_Req) AS Number_Open_Req, Format([Demand_Expected_startDate],"mmm-yyyy") AS Expr1, a.Demand_vertical FROM a WHERE (((a.Demand_vertical)="BFS")) GROUP BY Format([Demand_Expected_startDate],"mmm-yyyy"), a.Demand_vertical";
            selectcmd.Parameters.AddWithValue("?", RadioButtonList1.SelectedItem.ToString());
            OleDbDataReader dr1 = selectcmd.ExecuteReader();

            //Creating Temp data for graph
            DataTable dt = new DataTable();
            DataColumn dc;
            dc = new DataColumn();
            dc.ColumnName = "Status";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Year";
            dt.Columns.Add(dc);


            dt.Columns.Add("Number_of_Positions", typeof(int));

            //Inserting values in temp table

            DataRow dr;
            while (dr1.Read())
            {

                dr = dt.NewRow();
                dr["Status"] = "Open";
                dr["Year"] = dr1[2].ToString();
                dr["Number_of_Positions"] = Convert.ToInt16(dr1[1]);
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Status"] = "Closed";
                dr["Year"] = dr1[2].ToString();
                dr["Number_of_Positions"] = Convert.ToInt16(dr1[0]);
                dt.Rows.Add(dr);
            }

            DataTable dt1 = new DataTable();
            using (OleDbCommand selectcancelledcmd = new OleDbCommand("Get_Cancelled_Graph", con))
            {
                selectcancelledcmd.CommandType = System.Data.CommandType.StoredProcedure;
                selectcancelledcmd.Parameters.AddWithValue("?", RadioButtonList1.SelectedItem.ToString());
                OleDbDataAdapter da = new OleDbDataAdapter(selectcancelledcmd);
                da.Fill(dt1);
                for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                {
                    dr = dt.NewRow();
                    dr["Status"] = "Cancelled";
                    dr["Year"] = dt1.Rows[i][0].ToString();
                    dr["Number_of_Positions"] = Convert.ToInt16(dt1.Rows[i][2].ToString());
                    dt.Rows.Add(dr);
                }
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "Year ASC, Status ASC";
            dt = dv.ToTable();
            DataTable table = new DataTable();
            table.Columns.Add("Year", typeof(string));
            foreach (DataRow dr3 in dt.Rows)
            {
                //Add user Names to DataTable table
                if (!table.Columns.Contains(dr3["Status"].ToString()))
                {
                    table.Columns.Add(dr3["Status"].ToString(), typeof(int));
                }

                //Add empty Question rows to DataTable
                if (table.AsEnumerable().Where(x => x.Field<string>("Year") == dr3["Year"].ToString()).Count() == 0)
                {
                    table.Rows.Add(dr3["Year"].ToString());
                }
            }
            for (int i = 1; i < table.Columns.Count; i++)
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    string Year = table.Rows[j][0].ToString();
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        string status = table.Columns[i].ColumnName;

                        table.Rows[j][i] = dt.AsEnumerable().Where(x => x.Field<string>("Status") == status).Where(y => y.Field<string>("Year") == Year).Sum(r => r.Field<int>("Number_of_Positions"));
                    }
                }
            }
            //Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
            Chart1.Series["Series1"]["DrawingStyle"] = "Emboss";
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            //Chart1.Series["Series1"].IsValueShownAsLabel = true;

            //convert datatable to a IEnumerable form
            var IEtable = (table as System.ComponentModel.IListSource).GetList();

            Chart1.DataBindTable(IEtable, "Year");

            Chart1.Legends.Add(new Legend("Legend1"));

            Chart1.Series["Series1"].Legend = "Legend1";
            // Chart1.Legends["Legend1"].DockedToChartArea="Default";
            //  Chart1.Legends["Legend1"].


        }

        con.Close();
    }

    protected void Chart1_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
    {
        int customItems = ((Chart)sender).Legends[0].CustomItems.Count();
        if (customItems < 0)
        {
            int numberOfAutoItems = e.LegendItems.Count() - customItems;
            for (int i = 0; i < numberOfAutoItems; i++)
            {
                e.LegendItems.RemoveAt(0);
            }
        }
    }
}

