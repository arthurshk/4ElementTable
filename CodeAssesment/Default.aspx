<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CodeAssesment._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p>This is the data from your file</p>
        <asp:DataGrid ID="myDataGrid" runat="server" AutoGenerateColumns="true" CssClass="datagrid"></asp:DataGrid>
        
        <p>These are the creatures broken out by type:</p>
      <!--create the Data Grids for the filtered "Water" and "Fire" types-->
        <h3>Fire</h3>
        <asp:DataGrid ID="fireDataGrid" runat="server" AutoGenerateColumns="true" CssClass="datagrid">
            <HeaderStyle Font-Bold="true"/>
        </asp:DataGrid>
        
        <h3>Water</h3>
        <asp:DataGrid ID="waterDataGrid" runat="server" AutoGenerateColumns="true" CssClass="datagrid">
            <HeaderStyle Font-Bold="true"/>
        </asp:DataGrid>
    </div>
</asp:Content>
