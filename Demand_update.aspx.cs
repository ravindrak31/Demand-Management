using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Text;
using System.IO;


public partial class Demand_New : System.Web.UI.Page
{
   // int Client_ID;
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
                selectcmd.CommandText = "select distinct Client_Name from tb_ClientDetails";
                // insertcmd.Parameters.AddWithValue("@var", name);
                // con.Open();
                OleDbDataReader dr;
                dr = selectcmd.ExecuteReader();
                txt_Client_Name.Items.Add("----Select----");
                while (dr.Read())
                {
                    txt_Client_Name.Items.Add(dr[0].ToString());
                }
            }
            con.Close();
          }
        }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
            con.Open();
            using (OleDbCommand selectcmd = new OleDbCommand("getProjectName_byClientName",con))
            {

                selectcmd.CommandType = System.Data.CommandType.StoredProcedure;
                selectcmd.Parameters.AddWithValue("?", txt_Client_Name.Text);
                // con.Open();
                OleDbDataReader dr;
                dr = selectcmd.ExecuteReader();
                txt_Project_Name.Items.Clear();
                txt_Project_Name.Items.Add("----Select----");
                while (dr.Read())
                {
                    string s = dr[0].ToString() + "|" + dr[1].ToString();
                    txt_Project_Name.Items.Add(s);
                    
                }
            }
            con.Close();
        }
    }
    protected void txt_Project_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_demand_id.Text = txt_Project_Name.Text.Split('|')[0];
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
        con.Open();
        using (OleDbCommand selectcmd = new OleDbCommand("GetDemandDetails_byID", con))
        {

            selectcmd.CommandType = System.Data.CommandType.StoredProcedure;
            selectcmd.Parameters.AddWithValue("?", lbl_demand_id.Text);
            // con.Open();
            OleDbDataReader dr;
            dr = selectcmd.ExecuteReader();
            txt_Practice.Items.Clear();
            txt_destination.Items.Clear();
            txt_status.Items.Clear();
            txt_Practice.Items.Clear();
            txt_destination.Items.Clear();
            //txt_Project_Name.Items.Add("----Select----");
            while (dr.Read())
            {
                txt_status.Items.Add(dr[0].ToString());
                DateTime s=DateTime.Parse(dr[1].ToString());
               // date1.TextMode=TextBoxMode.SingleLine;
                date1.Text = s.ToString("yyyy-MM-dd");
              //  date1.TextMode = TextBoxMode.Date;
                txt_vertical.Text = dr[2].ToString();
                txt_Skillset.Text = dr[4].ToString();
                txt_Practice.Items.Add(dr[5].ToString());
                txt_number_of_resources.Text=dr[6].ToString();
                txt_probability.Text=dr[7].ToString();
                txt_designation.Text=dr[8].ToString();
                txt_destination.Items.Add(dr[9].ToString());
                txt_Location.Text=dr[10].ToString();
                txt_Resource_Identified.Text = dr[11].ToString();
                txt_Number_of_ClosedPositions.Text = dr[12].ToString();
                txt_DO_PL.Text = dr[13].ToString();
                txt_Supply_Owner.Text = dr[14].ToString();
                txt_Account_manager.Text = dr[15].ToString();
                Label18.Text = dr[16].ToString();

            }
            txt_status.Items.Add("Closed");
            txt_status.Items.Add("Cancelled");
            if (txt_Practice.Text == "QE&A")
            {
                txt_Practice.Items.Add("EAS");
            }
            else
            {
                txt_Practice.Items.Add("QE&A");
            }
            if (txt_destination.Text == "Onshore")
            {

                txt_destination.Items.Add("Offshore");
            }
            else
            {
                txt_destination.Items.Add("Onshore");
            }
        }
        con.Close();
    }
    protected void txt_Resource_Identified_TextChanged(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string source = txt_Resource_Identified.Text;
            int count = 0;
            foreach (char c in source)
            {
                if (c == ',') count++;
            }
            txt_Number_of_ClosedPositions.Text = count.ToString();
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //try
        //{
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb");
            con.Open();
            using (OleDbCommand insertcmd = new OleDbCommand())
            {
                insertcmd.CommandType = CommandType.Text;
                int i = Convert.ToInt32(Convert.ToInt16(txt_number_of_resources.Text) - Convert.ToInt16(txt_Number_of_ClosedPositions.Text));
                string query = "UPDATE tb_demand_details SET Demand_status ='" + txt_status.Text + "', Demand_Expected_startDate = '" + Convert.ToDateTime(date1.Text).ToShortDateString() + "', Demand_vertical = '" + txt_vertical.Text + "', Demand_Skillset = '" + txt_Skillset.Text + "', Demand_Practice = '" + txt_Practice.Text + "', Demand_total_Number_resources = '" + Convert.ToInt16(txt_number_of_resources.Text) + "', Demand_Probability = '" + Convert.ToInt16(txt_probability.Text) + "', Demand_Resource_Designation = '" + txt_designation.Text + "', Demand_Destination = '" + txt_destination.Text + "', Demand_Location = '" + txt_Location.Text + "', Demand_Number_Closed_Req = '" + Convert.ToInt16(txt_Number_of_ClosedPositions.Text) + "', Demand_Number_Open_Req = '" + i + "', Demand_Demand_Owner ='" + txt_DO_PL.Text + "', Demand_Supply_Owner = '" + txt_Supply_Owner.Text + "', Demand_Account_Manager = '" + txt_Account_manager.Text + "', demand_resources_identified='"+txt_Resource_Identified.Text+"' WHERE demand_id=" + Convert.ToInt16(lbl_demand_id.Text) + "";
                insertcmd.Connection = con;
                insertcmd.CommandText = query;

                insertcmd.ExecuteNonQuery();
                string display = "Demand modified successfully, Demand ID : " + lbl_demand_id.Text;
                //  Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Success Alert", "alert('" + display + "');window.location.replace=;", true);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('" + display + "');window.location.href = 'Demand_update.aspx';", true);
                // MessageBox.MessageBox m = new MessageBox.MessageBox("This is M box", "Ravi", MessageBox.MessageBox.MessageBoxIcons.System, MessageBox.MessageBox.MessageBoxButtons.Ok, MessageBox.MessageBox.MessageBoxStyle.StyleA);
                //m.SuccessEvent.Add(
                // Literal1.Text=m.Show(this);
            }
            con.Close();
        //}
        //catch
        //{
        //    Label19.Text = "Please complete the form carefully";
        //    Label19.Visible = true;
        //    Label1.Attributes.Add("style", "text-decoration:blink");
        //}
    }
}