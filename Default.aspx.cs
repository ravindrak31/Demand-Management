using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        Common_Code c=new Common_Code();
        
        int rowsAffected=c.save_client(txt_Client_Name.Text,txt_vertical.Text,txt_DO_PL.Text,txt_Supply_Owner.Text,txt_Account_Manager.Text);
              if (rowsAffected == 1)
                {
                    string display = "Record Saved Successfuly!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
                else
                {
                    Response.Write("Error");
                }
               
            }
        }
       
      
 