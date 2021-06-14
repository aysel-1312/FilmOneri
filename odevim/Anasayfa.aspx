<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="odevim.Anasayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 
    <style type="text/css">
        .auto-style1 {
            margin-right: 0;
        }
    </style>

 
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <p>
        <asp:DataList ID="DataList1" runat="server" BorderColor="Aqua" BorderWidth="2px" CellPadding="4" CssClass="auto-style1" DataSourceID="SqlDataSource1" ForeColor="#333333" RepeatColumns="3">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#E3EAEB" />
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" Height="140px" ImageUrl='<%# Eval("resim", "{0}") %>' Width="222px" />
                <br />
                Id:
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                <br />
                FilmTuru:
                <asp:Label ID="FilmTuruLabel" runat="server" Text='<%# Eval("FilmTuru") %>' />
                <br />
                FilmAdi:
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("altkatid", "filmdetay.aspx?altkatid={0}") %>' Text='<%# Eval("FilmAdi", "{0}") %>'></asp:HyperLink>
                <br />
                VizyonTarihi:
                <asp:Label ID="VizyonTarihiLabel" runat="server" Text='<%# Eval("VizyonTarihi") %>' />
                <br />
                Süre:
                <asp:Label ID="SüreLabel" runat="server" Text='<%# Eval("Süre") %>' />
                <br />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [filmtanim]"></asp:SqlDataSource>
    </p>
</asp:Content>


