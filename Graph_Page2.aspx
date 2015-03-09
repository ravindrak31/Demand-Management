<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Graph_Page2.aspx.cs" Inherits="Graph_Page2" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .formSection {
            height: 46px;
            width: 786px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;&nbsp;
    <asp:Panel ID="Panel1" runat="server" Font-Names="Calibri Light" HorizontalAlign="Center">
         

                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true" BorderColor="#3333cc" >
                    </asp:RadioButtonList>

 </asp:Panel>
   <br/>
<asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" Font-Names="Calibri Light">
     <asp:Chart ID="Chart1" runat="server" Palette="SeaGreen" BackColor="LightGray" Width="654px" BorderlineDashStyle="Solid" Visible="False" Height="320px" OnCustomizeLegend="Chart1_CustomizeLegend">
             <Series>
              <asp:series Name="Series1" ChartArea="ChartArea1" ChartType="Pie"></asp:series>
             </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" AlignmentOrientation="Horizontal">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
   
    </asp:Panel>
    </asp:Content>

