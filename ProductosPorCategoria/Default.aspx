<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductosPorCategoria._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>En la siguiente lista se ven las categorias vendidas en el año 2019</h3>
    <asp:DropDownList ID="ddlCategorias" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">
        <asp:ListItem Text="-- Selecciona una categoría --" Value="" />
    </asp:DropDownList>

    <br /><br />

    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="true" />

</asp:Content>
