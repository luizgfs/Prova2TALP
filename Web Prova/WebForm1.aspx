<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web_Prova.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" id="GridView2" AutoGenerateColumns="false">
        <Columns>
              <asp:BoundField DataField="id" HeaderText="Id" />
              <asp:BoundField DataField="idProduto" HeaderText="idProduto" />
              <asp:BoundField DataField="precoVenda" HeaderText="Preço" />
                               
        </Columns>

    </asp:GridView>
</asp:Content>
