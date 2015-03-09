<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demand_New.aspx.cs" Inherits="Demand_New" MasterPageFile="~/MasterPage.master" %>



<asp:Content runat="server" ID="content" ContentPlaceHolderId="ContentPlaceHolder1">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <div style="margin-left: 240px">
            <asp:Panel ID="Panel1" runat="server" Height="492px" HorizontalAlign="Justify" ToolTip="Client Details Wizard" BackColor="#D4EBF3" Width="843px" style="margin-top: 0px" BorderColor="Black" BorderStyle="Outset">
                <fieldset class="formSection" >
                    <legend class="formSectionHeading">Demand Entry Wizard</legend>
                     <asp:Label ID="Label6" runat="server" Font-Names="Calibri Light" Text="Client : " height="19px" width="219px"></asp:Label>

                    <asp:DropDownList ID="txt_Client_Name" Font-Names="Verdana" runat="server" Height="23px" Width="140px" AutoPostBack="true" TabIndex="1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Size="Small">
                    </asp:DropDownList>
                    
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="txt_Client_Name" InitialValue="1"></asp:RequiredFieldValidator>
                    
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
                     <asp:Label ID="Label18" runat="server" Font-Names="Calibri Light" Text="" height="19px" width="218px" Visible="false"></asp:Label>
                   <br />
                    <br />
                    <br />
                   <asp:Label ID="Label1" runat="server" Font-Names="Calibri Light" Text="Vertical : " height="19px" width="218px"></asp:Label>
                    <asp:TextBox ID="txt_vertical" Font-Names="Verdana" runat="server" Height="16px" Width="130px" Font-Size="Small" DataSourceID="ClientMgmt_DB" DataTextField="Owner_Name" DataValueField="Owner_Name" TabIndex="2" BorderStyle="Ridge"></asp:TextBox>
             
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
                     <asp:Label ID="Label7" runat="server" Font-Names="Calibri Light" Text="Demand Owner/Practice Lead : " height="19px" width="218px"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt_DO_PL" runat="server" DataSourceID="ClientMgmt_DB" DataTextField="Owner_Name" DataValueField="Owner_Name" Font-Names="Verdana" Font-Size="Small" Height="16px" TabIndex="2" Width="130px" BorderStyle="Ridge"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Font-Names="Calibri Light" height="19px" Text="Supply Owner : " width="218px"></asp:Label>
                    <asp:TextBox ID="txt_Supply_Owner" runat="server" AutoPostBack="True" DataSourceID="SO_Datasource" DataTextField="Owner_Name" DataValueField="Owner_Name" Font-Names="Verdana" Font-Size="Small" Height="16px" TabIndex="3" Width="130px" BorderStyle="Ridge"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri Light" height="19px" Text="Account Manager : " width="218px"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt_Account_manager" runat="server" AutoPostBack="True" DataSourceID="sqlDataSource1" DataTextField="Owner_Name" DataValueField="Owner_Name" Font-Names="Verdana" Font-Size="Small" Height="16px" TabIndex="4" Width="130px" BorderStyle="Ridge"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Font-Names="Calibri Light" height="19px" Text="Project Name : " width="219px"></asp:Label>
                    <asp:TextBox ID="txt_Project_Name" runat="server" Font-Names="Verdana" Font-Size="Small" Height="16px" Width="536px" BorderStyle="Ridge"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txt_Project_Name"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri Light" height="19px" Text="Practice : " width="218px"></asp:Label>
                    <asp:DropDownList ID="txt_Practice" runat="server" AutoPostBack="True" Font-Names="Verdana" Font-Size="Small" Height="20px" TabIndex="3" Width="140px">
                        <asp:ListItem>----Select----</asp:ListItem>
                        <asp:ListItem>QE&amp;A</asp:ListItem>
                        <asp:ListItem>EAS</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txt_Practice" InitialValue="0" Display="Dynamic" ForeColor="#FF5050" ToolTip="Please choose one of the options"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label12" runat="server" Font-Names="Calibri Light" height="19px" Text="Onshore/Offshore :" width="218px"></asp:Label>
                    &nbsp;&nbsp;<asp:DropDownList ID="txt_destination" runat="server" AutoPostBack="True" Font-Names="Verdana" Font-Size="Small" Height="18px" TabIndex="3" Width="140px">
                        <asp:ListItem>----Select----</asp:ListItem>
                        <asp:ListItem>Onshore</asp:ListItem>
                        <asp:ListItem>Offshore</asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txt_destination" InitialValue="0" EnableClientScript="true"></asp:RequiredFieldValidator>
                     <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Font-Names="Calibri Light" height="19px" Text="Expected Start Date :" width="218px"></asp:Label>
                    <asp:TextBox ID="date1" runat="server" Font-Names="Verdana" Font-Size="Small" Height="16px" name="date1" TextMode="Date" ToolTip="dd/MM/yyyy" Width="135px" BorderStyle="Ridge"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="*" ControlToValidate="date1" MinimumValue="01/01/1900" MaximumValue="31/12/9999"></asp:RangeValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri Light" height="19px" Text="Number of Resources :" width="218px"></asp:Label>
                    <asp:TextBox ID="txt_number_of_resources" runat="server" Font-Names="Verdana" Font-Size="Small" Height="16px" name="txt_number_of_resources" ToolTip="dd/MM/yyyy" Width="130px" BorderStyle="Ridge"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txt_number_of_resources"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri Light" height="19px" Text="Designation :" width="218px"></asp:Label>
                    <asp:TextBox ID="txt_designation" runat="server" BorderStyle="Ridge" Font-Names="Verdana" Font-Size="Small" Height="16px" name="txt_designation" ToolTip="Associate, Senior Associate" Width="130px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txt_designation"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri Light" height="19px" Text="Probability :" width="218px"></asp:Label>
                    &nbsp;<asp:TextBox ID="txt_probability" runat="server" BorderStyle="Ridge" Font-Names="Verdana" Font-Size="Small" Height="16px" name="txt_probability" ToolTip="probability of opportunity" Width="130px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri Light" height="19px" Text="Skillset :" width="218px"></asp:Label>
                    <asp:TextBox ID="txt_Skillset" runat="server" BorderStyle="Ridge" Font-Names="Verdana" Font-Size="Small" Height="16px" name="txt_Skillset" ToolTip="" Width="130px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txt_Skillset"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label14" runat="server" Font-Names="Calibri Light" height="19px" Text="Location :" width="218px"></asp:Label>
                    &nbsp;&nbsp;<asp:TextBox ID="txt_Location" runat="server" BorderStyle="Ridge" Font-Names="Verdana" Font-Size="Small" Height="16px" name="txt_Location" ToolTip="Location of opportunity" Width="130px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txt_Location"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label15" runat="server" Font-Names="Calibri Light" height="19px" Text="Resources Identified :" width="218px"></asp:Label>
                    <asp:TextBox ID="txt_Resource_Identified" runat="server" BorderStyle="Ridge" Font-Names="Verdana" Font-Size="Small" Height="16px" name="txt_Resource_Identified" ToolTip="" Width="130px" OnTextChanged="txt_Resource_Identified_TextChanged" AutoPostBack="true"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label16" runat="server" Font-Names="Calibri Light" height="19px" Text="Number of Closed Positions :" width="218px"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txt_Number_of_ClosedPositions" runat="server" BorderStyle="Ridge" Font-Names="Verdana" Font-Size="Small" Height="16px" name="txt_Number_of_ClosedPositions" ToolTip="" Width="130px">0</asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label17" runat="server" Font-Names="Calibri Light" height="19px" Text="Please add comma (,) after every name in Resource Identified" width="416px" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri Light" height="19px" Text="Please add comma (,) after every name in Resource Identified" width="416px" ForeColor="Red" Visible="false"></asp:Label>
                    <br />
                    <fieldset class="formSection">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Save" runat="server" Height="30px" style="margin-left: 80px" Text="Save" Width="91px" OnClick="btn_Save_Click" />
                        <asp:Button ID="btn_Cancel" runat="server" Height="30px" style="margin-left:120px" Text="Cancel" Width="91px" />
                    </fieldset>
                    </fieldset><br />
               
          
            </asp:Panel>
    </div>
   
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .formSection {
            height: 31px;
            width: 781px;
        }
    </style>
</asp:Content>

