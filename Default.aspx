<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableSessionState="True" MasterPageFile="~/MasterPage.master" %>


<asp:Content runat="server" ID="content" ContentPlaceHolderId="ContentPlaceHolder1">
   

    
        <div style="margin-left: 240px" align="Justify">
            <asp:Panel ID="Panel1" runat="server" Height="320px" HorizontalAlign="Justify" ToolTip="Client Details Wizard" BackColor="#D4EBF3" Width="637px" style="margin-top: 0px">
                <fieldset class="formSection" >
                    <legend class="formSectionHeading">Client Entry Wizard</legend>
                    <asp:Label ID="Label2" runat="server" Font-Names="Calibri Light" Text="Client Name : " height="19px" width="219px"></asp:Label>
                    <asp:TextBox ID="txt_Client_Name" runat="server" Font-Names="Arial" Height="22px" Width="280px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" style="margin-left: 80px" ControlToValidate="txt_Client_Name" ErrorMessage="*" Visible="true" ForeColor="#FF0066" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri Light" Text="Vertical : " height="19px" width="219px"></asp:Label>
                    <asp:DropDownList ID="txt_vertical" Font-Names="Arial" runat="server" Height="22px" Width="280px" AutoPostBack="True" TabIndex="1">
                        <asp:ListItem>BFS</asp:ListItem>
                        <asp:ListItem>Comms</asp:ListItem>
                        <asp:ListItem>EAS</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Font-Names="Calibri Light" Text="Demand Owner/Practice Lead : " height="19px" width="218px"></asp:Label>
                    <asp:DropDownList ID="txt_DO_PL" Font-Names="Arial" runat="server" Height="31px" Width="280px" Font-Size="Small" DataSourceID="ClientMgmt_DB" DataTextField="Owner_Name" DataValueField="Owner_Name" TabIndex="2">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="ClientMgmt_DB" runat="server" ConnectionString="<%$ ConnectionStrings:CS_ClientMgmt %>" ProviderName="<%$ ConnectionStrings:CS_ClientMgmt.ProviderName %>" SelectCommand="SELECT DISTINCT [Owner_Type], [Owner_Name] FROM [tb_Owner_Details] WHERE ([Owner_Type] = ?)">
                        <SelectParameters>
                            
                            <asp:QueryStringParameter DefaultValue="DO" Name="Owner_Type" QueryStringField="DO" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri Light" Text="Supply Owner : " height="19px" width="218px"></asp:Label>
                    <asp:DropDownList ID="txt_Supply_Owner" Font-Names="Arial" runat="server" Height="31px" Width="280px" Font-Size="Small" DataSourceID="SO_Datasource" DataTextField="Owner_Name" DataValueField="Owner_Name" AutoPostBack="True" TabIndex="3">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SO_Datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_SO %>" ProviderName="<%$ ConnectionStrings:ConnectionString_SO.ProviderName %>" SelectCommand="SELECT DISTINCT Owner_Name FROM tb_Owner_Details WHERE (Owner_Type = 'SO')"></asp:SqlDataSource>
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Font-Names="Calibri Light" Text="Account Manager : " height="19px" width="218px"></asp:Label>
                    <asp:DropDownList ID="txt_Account_Manager" Font-Names="Arial" runat="server" Height="31px" Width="280px" Font-Size="Small" DataSourceID="sqlDataSource1" DataTextField="Owner_Name" DataValueField="Owner_Name" AutoPostBack="True" TabIndex="4">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_AM %>" ProviderName="<%$ ConnectionStrings:ConnectionString_AM.ProviderName %>" SelectCommand="SELECT DISTINCT Owner_Name FROM tb_Owner_Details WHERE (Owner_Type = 'AM')"></asp:SqlDataSource>
                    <br />
                    <br />
                    <fieldset class="formSection">
                        <asp:Button ID="btn_Save" runat="server" Height="30px" style="margin-left: 80px" Text="Save" Width="91px" OnClick="btn_Save_Click" />
                        <asp:Button ID="btn_Cancel" runat="server" Height="30px" style="margin-left:120px" Text="Cancel" Width="91px" />
                    </fieldset>
                    </fieldset><br />
               
          
            </asp:Panel>
        </div>
 
    

</asp:Content>

