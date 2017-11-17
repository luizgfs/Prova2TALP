<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Prova._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="Button1" runat="server" Text="Compras" OnClick="Button1_Click" /><br /><br />

    <div class="row">
        <div class="col-md-4">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BorderStyle="Double" AllowPaging="true" OnRowCommand="GridView1_RowCommand" Width="481px" >
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" />
                    <asp:BoundField DataField="Produto" HeaderText="Nome" />
                    <asp:BoundField DataField="Preco" HeaderText="Preço" />
                    <asp:ButtonField CommandName="Comprar" Text="Comprar" />
                    
                </Columns>
            </asp:GridView>
        </div>
    </div>
        

</asp:Content>
