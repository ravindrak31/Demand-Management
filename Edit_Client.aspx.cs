using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class Edit_Client : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_vertical.Enabled=false;
        if (!IsPostBack)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
            con.Open();
            using (OleDbCommand selectcmd = new OleDbCommand())
            {
                selectcmd.Connection = con;
                selectcmd.CommandType = System.Data.CommandType.Text;
                selectcmd.CommandText = "select distinct Client_Name,ID from tb_ClientDetails";
                // insertcmd.Parameters.AddWithValue("@var", name);
                // con.Open();
                OleDbDataReader dr = selectcmd.ExecuteReader();
                txt_Client_Name.Items.Add("Select Client");
                while (dr.Read())
                {
                    txt_Client_Name.Items.Add((dr["Client_Name"]).ToString());

                }
            }
            con.Close();
        }
    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {

    }
    protected void btn_Edit_Click(object sender, EventArgs e)
    {
    
       
    }
    protected void txt_Client_Name_TextChanged(object sender, EventArgs e)
    {

        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
            con.Open();
            using (OleDbCommand selectcmd = new OleDbCommand())
            {
                selectcmd.Connection = con;
                selectcmd.CommandType = System.Data.CommandType.Text;
                selectcmd.CommandText = "select distinct Client_Name, Client_Vertical, Client_Demand_Owner, Client_Supply_Owner, Client_Account_Manager from tb_ClientDetails where Client_Name='" + txt_Client_Name.Text + "'";
                // insertcmd.Parameters.AddWithValue("@var", name);
                // con.Open();
                OleDbDataReader dr;
                dr = selectcmd.ExecuteReader();
                txt_vertical.Items.Clear();
                while (dr.Read())
                {
                    txt_vertical.Enabled = true;
                    txt_vertical.Items.Insert(0, dr[1].ToString());
                    txt_DO_PL.Items.Insert(0, dr[2].ToString());
                    txt_DO_PL.Text = txt_DO_PL.Items[0].Value;
                    
                }
            }
            con.Close();
        }
    }
    protected void txt_vertical_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        {   
            if(txt_vertical.Text!="")
            {
                string[] vertical_List = new string[3] {"BFS", "Comms", "EAS"};
               
                for (int i = 0; i <= vertical_List.Length; i++)
                {
                    if (vertical_List[i].ToString() == txt_vertical.Text)
                    {
                    }
                    else
                    {
                        txt_vertical.Items.Add(vertical_List[i].ToString());
                    }
                }
                

            }
           
        }
    }
}