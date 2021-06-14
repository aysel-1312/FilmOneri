<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="filmdetay.aspx.cs" Inherits="odevim.filmdetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black">
    <AlternatingItemStyle BackColor="PaleGoldenrod" />
    <FooterStyle BackColor="Tan" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" />
    <ItemTemplate>
        <asp:Image ID="Image1" runat="server" Height="157px" ImageUrl='<%# Eval("resim", "{0}") %>' Width="232px" />
        <br />
        AltKatId:
        <asp:Label ID="AltKatIdLabel" runat="server" Text='<%# Eval("AltKatId") %>' />
        <br />
        Id:
        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
        <br />
        SenaristId:
        <asp:Label ID="SenaristIdLabel" runat="server" Text='<%# Eval("SenaristId") %>' />
        <br />
        YonetmenId:
        <asp:Label ID="YonetmenIdLabel" runat="server" Text='<%# Eval("YonetmenId") %>' />
        <br />
        FilmTuru:
        <asp:Label ID="FilmTuruLabel" runat="server" Text='<%# Eval("FilmTuru") %>' />
        <br />
        FilmAdi:
        <asp:Label ID="FilmAdiLabel" runat="server" Text='<%# Eval("FilmAdi") %>' />
        <br />
        VizyonTarihi:
        <asp:Label ID="VizyonTarihiLabel" runat="server" Text='<%# Eval("VizyonTarihi") %>' />
        <br />
        Süre:
        <asp:Label ID="SüreLabel" runat="server" Text='<%# Eval("Süre") %>' />
        <br />
        resim: <br />
<br />
    </ItemTemplate>
    <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
</asp:DataList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [filmtanim] WHERE ([AltKatId] = @AltKatId)">
    <SelectParameters>
        <asp:QueryStringParameter Name="AltKatId" QueryStringField="AltKatId" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>
