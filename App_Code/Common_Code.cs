using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for Common_Code
/// </summary>
public class Common_Code
{

    public int save_client(string client_name, string client_vertical, string client_DO, string Client_SO, string client_AM)
    {
        try
        {
            int rowsAffected;
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
            con.Open();
            using (OleDbCommand insertcmd = new OleDbCommand())
            {
                int Client_id;
                using (OleDbCommand selectcmd = new OleDbCommand())
                {
                    selectcmd.CommandType = CommandType.Text;
                    selectcmd.CommandText = "Select max(Client_ID) from tb_ClientDetails";
                    selectcmd.Connection = con;
                    Client_id = Convert.ToInt16(selectcmd.ExecuteScalar().ToString()) + 1;

                }


                insertcmd.Connection = con;
                insertcmd.CommandType = System.Data.CommandType.Text;
                insertcmd.CommandText = "INSERT INTO tb_ClientDetails ( Client_ID, Client_Name, Client_Vertical, Client_Demand_Owner, Client_Supply_Owner, Client_Account_Manager ) values ('"+Client_id+"','" + client_name + "','" + client_vertical + "','" + client_DO + "','" + Client_SO + "','" + client_AM + "')";
                // insertcmd.Parameters.AddWithValue("@var", name);
                rowsAffected = insertcmd.ExecuteNonQuery();
                
                
            }
            con.Close();
            return rowsAffected;
        }
        catch
        {
           
            return 0;
        }
    }
    public int save_demand(string client_name, string client_vertical, string client_DO, string Client_SO, string client_AM)
    {
        try
        {
            int rowsAffected;
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB_Req_Mgmt.accdb;Persist Security Info=True");
            con.Open();
            using (OleDbCommand insertcmd = new OleDbCommand())
            {
                insertcmd.Connection = con;
                insertcmd.CommandType = System.Data.CommandType.Text;
                insertcmd.CommandText = "INSERT INTO tb_ClientDetails ( Client_Name, Client_Vertical, Client_Demand_Owner, Client_Supply_Owner, Client_Account_Manager ) values ('" + client_name + "','" + client_vertical + "','" + client_DO + "','" + Client_SO + "','" + client_AM + "')";
                // insertcmd.Parameters.AddWithValue("@var", name);
                rowsAffected = insertcmd.ExecuteNonQuery();


            }
            con.Close();
            return rowsAffected;
        }
        catch
        {

            return 0;
        }
    }
    public class itemval
    {
        public string Name { get; set; }
     
    }
    public List<itemval> getsupplyOwner(string itemname)
    {
        List<itemval> itemarray = new List<itemval>();
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
         
            while (dr.Read())
           {
               itemval data = new itemval();
               data.Name=dr[0].ToString();
               itemarray.Add(data);
           
            }
        }
        con.Close();
        return itemarray;
    }
}