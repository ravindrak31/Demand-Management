<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit_Client.aspx.cs" Inherits="Edit_Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Edit Client Details</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
        <div style="margin-left: 240px">
            <asp:Panel ID="Panel1" runat="server" Height="320px" HorizontalAlign="Justify" ToolTip="Client Details Wizard" BackColor="#CCCCCC" Width="637px" style="margin-top: 0px">
                <fieldset class="formSection" >
                    <legend class="formSectionHeading">Client Entry Wizard</legend>
                    <asp:Label ID="Label2" runat="server" Font-Names="Calibri Light" Text="Client Name : " height="19px" width="219px"></asp:Label>
                   <asp:DropDownList ID="txt_Client_Name" Font-Names="Arial" runat="server" Height="22px" Width="280px" TabIndex="1" Autopostback="true" OnSelectedIndexChanged="txt_Client_Name_TextChanged">
          
                    </asp:DropDownList>
                   
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri Light" Text="Vertical : " height="19px" width="219px"></asp:Label>
                    <asp:DropDownList ID="txt_vertical" Font-Names="Arial" runat="server" Height="22px" Width="280px" TabIndex="1" OnSelectedIndexChanged="txt_vertical_SelectedIndexChanged" OnTextChanged="txt_vertical_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>BFS</asp:ListItem>
                        <asp:ListItem>Comms</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Font-Names="Calibri Light" Text="Demand Owner : " height="19px" width="218px"></asp:Label>
                    <asp:DropDownList ID="txt_DO_PL" Font-Names="Arial" runat="server" Height="31px" Width="280px" Font-Size="Small" DataSourceID="ClientMgmt_DB" DataTextField="Owner_Name" DataValueField="Owner_Name" TabIndex="2" AutoPostBack="false">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="ClientMgmt_DB" runat="server" ConnectionString="<%$ ConnectionStrings:CS_ClientMgmt %>" ProviderName="<%$ ConnectionStrings:CS_ClientMgmt.ProviderName %>" SelectCommand="SELECT DISTINCT [Owner_Type], [Owner_Name] FROM [tb_Owner_Details] WHERE ([Owner_Type] = ?)">
                        <SelectParameters>                            
                            <asp:QueryStringParameter DefaultValue="DO" Name="Owner_Type" QueryStringField="DO" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri Light" Text="Supply Owner : " height="19px" width="218px"></asp:Label>
                    <asp:DropDownList ID="txt_Supply_Owner" Font-Names="Arial" runat="server" Height="31px" Width="280px" Font-Size="Small" AutoPostBack="True" TabIndex="3">
                    </asp:DropDownList>
                    
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Font-Names="Calibri Light" Text="Account Manager : " height="19px" width="218px"></asp:Label>
                    <asp:DropDownList ID="txt_Account_Manager" Font-Names="Arial" runat="server" Height="31px" Width="280px" Font-Size="Small" AutoPostBack="True" TabIndex="4">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <fieldset class="formSection">
                        <asp:Button ID="btn_Edit" runat="server" Height="30px" style="margin-left: 40px" Text="Edit" Width="91px" OnClick="btn_Edit_Click"/>
                        <asp:Button ID="btn_Delete" runat="server" Height="30px" style="margin-left:80px" Text="Delete" Width="91px" OnClick="btn_Delete_Click" />
                        <asp:Button ID="btn_Cancel" runat="server" Height="30px" style="margin-left:120px" Text="Cancel" Width="91px" />
                    </fieldset>
                    </fieldset><br />
               
          
            </asp:Panel>
        </div>
</asp:Content>

