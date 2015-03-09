using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Drawing;

public partial class Demand_update2 : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
            con.Open();
            using (OleDbCommand selectcmd = new OleDbCommand())
            {
                selectcmd.Connection = con;
                selectcmd.CommandType = System.Data.CommandType.Text;
                selectcmd.CommandText = "SELECT distinct d.demand_supply_owner FROM tb_Demand_details d union SELECT distinct d1.demand_demand_owner FROM tb_Demand_details d1 union select distinct o.owner_name from tb_Owner_Details o;";
                // insertcmd.Parameters.AddWithValue("@var", name);
                // con.Open();
                OleDbDataReader dr;
                dr = selectcmd.ExecuteReader();
                txt_owner.Items.Add("----Select----");
                while (dr.Read())
                {
                    txt_owner.Items.Add(dr[0].ToString());
                }
            }
            con.Close();
        }
    }
    protected void txt_owner_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadgriddata();
    }
    private void loadgriddata()
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
        con.Open();
        using (OleDbCommand selectcmd = new OleDbCommand("Demand_details_byOwner", con))
        {
            selectcmd.CommandType = CommandType.StoredProcedure;
            selectcmd.Parameters.AddWithValue("?", txt_owner.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(selectcmd);
          
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
           
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count != 0)
        {
            try
            {

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Demands.xlsx"));
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                GridView1.AllowPaging = true;
                //Change the Header Row back to white color
                GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
                //Applying stlye to gridview header cells
                for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
                {
                    GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
                }
                int j = 1;
                //Set alternate row color
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    gvrow.BackColor = System.Drawing.Color.White;
                    if (j <= GridView1.Rows.Count)
                    {
                        if (j % 2 != 0)
                        {
                            for (int k = 0; k < gvrow.Cells.Count; k++)
                            {
                                gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                            }
                        }
                    }
                    j++;
                }
                GridView1.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();

            }
            catch
            {
                string display = " No Data to export !";

                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('" + display + "');", true);
            }
        }
        else
        {
            string display = " No Data to export !";

            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('" + display + "');", true);
        }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loadgriddata();
    }
  
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    protected void gridSelectedIndexChanged(Object sender, EventArgs e)
    {
        
        var row = ((GridView)sender).SelectedRow;
        txt_Client_Name.Items.Clear();
        lbl_demand_id.Text = row.Cells[1].Text.Replace("&nbsp;", "");
        txt_Client_Name.Items.Add(row.Cells[3].Text.Replace("&nbsp;", ""));
        loadclient();
        txt_status.Items.Clear();
        txt_status.Items.Add(row.Cells[2].Text.Replace("&nbsp;", ""));         
        txt_status.Items.Add("Closed");
        txt_status.Items.Add("Cancelled");
        txt_Project_Name.Items.Add(row.Cells[5].Text.Replace("&nbsp;", ""));
       
        //storedRecordsGrid.Visible = false;
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
    }

   
    private void loadclient()
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
        con.Open();
        using (OleDbCommand selectcmd = new OleDbCommand())
        {
            selectcmd.Connection = con;
            selectcmd.CommandType = System.Data.CommandType.Text;
            selectcmd.CommandText = "select distinct Client_Name from tb_ClientDetails";
            // insertcmd.Parameters.AddWithValue("@var", name);
            // con.Open();
            OleDbDataReader dr;
            dr = selectcmd.ExecuteReader();
           // txt_Client_Name.Items.Add("----Select----");
            while (dr.Read())
            {
                if (txt_Client_Name.Items[0].Text == dr[0].ToString())
                {

                }
                else
                {
                    txt_Client_Name.Items.Add(dr[0].ToString());
                }
            }
        }
        con.Close();
    }
}