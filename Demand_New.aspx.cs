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
using System.Net.Mail;


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
        }
        }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
            con.Open();
            using (OleDbCommand selectcmd = new OleDbCommand())
            {
                selectcmd.Connection = con;
                selectcmd.CommandType = System.Data.CommandType.Text;
                selectcmd.CommandText = "select distinct Client_Name, Client_Vertical, Client_Demand_Owner, Client_Supply_Owner, Client_Account_Manager,Client_ID from tb_ClientDetails where Client_Name='" + txt_Client_Name.Text + "'";
                // insertcmd.Parameters.AddWithValue("@var", name);
                // con.Open();
                OleDbDataReader dr;
                dr = selectcmd.ExecuteReader();            
                while (dr.Read())
                {
                    txt_vertical.Enabled = true;
                    txt_vertical.Text=dr[1].ToString();
                    txt_Supply_Owner.Text = dr[3].ToString();
                    txt_DO_PL.Text = dr[2].ToString();
                    txt_Account_manager.Text = dr[4].ToString();
                                   
                    Label18.Text = dr[5].ToString();
                }
            }
            con.Close();
 
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
                int demand_id;
                //int cli_id = Client_ID;
                using (OleDbCommand selectcmd = new OleDbCommand())
                {
                    selectcmd.CommandType = CommandType.Text;
                    selectcmd.CommandText = "Select max(Demand_ID) from tb_Demand_details";
                    selectcmd.Connection = con;
                    demand_id = Convert.ToInt16(selectcmd.ExecuteScalar().ToString()) + 1;

                }

                insertcmd.CommandType = CommandType.Text;
                int i = Convert.ToInt32(Convert.ToInt16(txt_number_of_resources.Text) - Convert.ToInt16(txt_Number_of_ClosedPositions.Text));
                string status = "Open";
              //  DateTime s = date1.Text;
                string query = "INSERT INTO tb_Demand_details ( Demand_ID , Demand_status, Demand_created, Demand_Expected_startDate, Demand_client_ID, Demand_vertical, Demand_Project_Name, Demand_Skillset, Demand_Practice, Demand_total_Number_resources, Demand_Probability, Demand_Resource_Designation, Demand_Destination, Demand_Location, Demand_Resources_Identified, Demand_Demand_Owner, Demand_Supply_Owner, Demand_Account_Manager, Demand_Number_Closed_Req, Demand_Number_Open_Req )VALUES ('" + demand_id + "','" + status + "','" + DateTime.Now.ToShortDateString() + "','" + Convert.ToDateTime(date1.Text).ToShortDateString() + "','" + Label18.Text + "','" + txt_vertical.Text + "','" + txt_Project_Name.Text + "','" + txt_Skillset.Text + "','" + txt_Practice.Text + "','" + txt_number_of_resources.Text + "','" + txt_probability.Text + "','" + txt_designation.Text + "','" + txt_destination.Text + "','" + txt_Location.Text + "','" + txt_Resource_Identified.Text + "','" + txt_DO_PL.Text + "','" + txt_Supply_Owner.Text + "','" + txt_Account_manager.Text + "','" + txt_Number_of_ClosedPositions.Text + "','" + i + "')";
                insertcmd.Connection = con;
                insertcmd.CommandText = query;

                insertcmd.ExecuteNonQuery();
                string display = "Demand Created successfully, Demand ID : " + demand_id;
                //  Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Success Alert", "alert('" + display + "');window.location.replace=;", true);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('" + display + "');window.location.href = 'Demand_New.aspx';", true);
                // MessageBox.MessageBox m = new MessageBox.MessageBox("This is M box", "Ravi", MessageBox.MessageBox.MessageBoxIcons.System, MessageBox.MessageBox.MessageBoxButtons.Ok, MessageBox.MessageBox.MessageBoxStyle.StyleA);
                //m.SuccessEvent.Add(
                // Literal1.Text=m.Show(this);
                using (OleDbCommand selectcmd = new OleDbCommand())
                {
                    selectcmd.Connection = con;
                    selectcmd.CommandType = System.Data.CommandType.Text;
                    selectcmd.CommandText = "select Owner_Email from tb_Owner_Details where Owner_Name='" + txt_Supply_Owner.Text + "'";
                    //OleDbDataReader dr;
                    string toEmail = selectcmd.ExecuteScalar().ToString();

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    NetworkCredential basicCredential = new NetworkCredential("ravindra.kulkarni1", "donbhai31$");
                    MailMessage message = new MailMessage();
                    MailAddress fromAddress = new MailAddress("Ravindra.kulkarni2@cognizant.com");
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;
                    smtpClient.EnableSsl = true;
                    smtpClient.Timeout = (60 * 5 * 1000);

                    message.From = fromAddress;
                    message.Subject ="New Demand - "+ demand_id.ToString() + " - is Open and asigned to you.";
                    message.IsBodyHtml = true;
                    string body = "Hi <strong>" + txt_Supply_Owner.Text + "</strong><br /> New Demand <strong> " + demand_id.ToString() + "<strong> is created and asigned to you <br /> <br /> <table border=1><tr><td>Demand ID</td><td>" + demand_id.ToString() + "</td></tr><tr><td>Client Name </td><td>" + txt_Client_Name.Text + "</td></tr><tr><td>Start Date</td><td>" + Convert.ToDateTime(date1.Text).ToShortDateString() + "</td></tr><tr><td>Number of resources</td><td>" + txt_number_of_resources.Text+ "</td></tr><tr><td>Skillset </td><td>" + txt_Skillset.Text + "</td></tr></table>";
                    message.Body = body.Replace("\r\n", "<br>");
                    message.To.Add(toEmail);
                    smtpClient.Send(message);
                }
                con.Close();
            }
            
        //}
    //    catch
    //    {
    //        Label19.Text = "Please complete the form carefully";
    //        Label19.Visible = true;
    //        Label1.Attributes.Add("style", "text-decoration:blink");
    //    }
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
}