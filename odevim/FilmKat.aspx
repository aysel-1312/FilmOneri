<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="FilmKat.aspx.cs" Inherits="odevim.FilmKat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [filmtanim] WHERE ([Id] = @Id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" RepeatColumns="4" Width="145px">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" Height="143px" ImageUrl='<%# Eval("resim", "{0}") %>' Width="215px" />
            <br />
            FilmTuru:
            <asp:Label ID="FilmTuruLabel" runat="server" Text='<%# Eval("FilmTuru") %>' />
            <br />
            FilmAdi:
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("altkatid", "filmdetay.aspx?altkatid={0}") %>' Text='<%# Eval("FilmAdi") %>' BorderColor="#FFFF99" Font-Italic="True" ForeColor="#6666FF"></asp:HyperLink>
            <br />
            VizyonTarihi:
            <asp:Label ID="VizyonTarihiLabel" runat="server" Text='<%# Eval("VizyonTarihi") %>' />
            <br />
            Süre:
            <asp:Label ID="SüreLabel" runat="server" Text='<%# Eval("Süre") %>' />
            <br />
            &nbsp;<br />
            <br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>


</asp:Content>
