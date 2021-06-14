<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="kullanicidetay.aspx.cs" Inherits="odevim.kullanicidetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
            color: red;
        }
        .auto-style2 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyField="Id" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <ItemStyle BackColor="#DEDFDE" ForeColor="Black" />
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" Height="235px" ImageUrl='<%# Eval("resim") %>' Width="344px" />
            <br />
            <br />
            <h1 class="auto-style2"><span class="auto-style1"><strong><em>KULLANICI BİLGİLERİ</em></strong></span></h1>
            <br />
            <br />
            KULLANICI NO:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            İSİM:
            <asp:Label ID="isimLabel" runat="server" Text='<%# Eval("isim") %>' />
            <br />
            SOYİSİM:
            <asp:Label ID="soyisimLabel" runat="server" Text='<%# Eval("soyisim") %>' />
            <br />
            CİNSİYET:
            <asp:Label ID="cinsiyetLabel" runat="server" Text='<%# Eval("cinsiyet") %>' />
            <br />
            dogumtarihi:
            <asp:Label ID="dogumtarihiLabel" runat="server" Text='<%# Eval("dogumtarihi") %>' />
            <br />
            KULLANICI ADI:
            <asp:Label ID="kullaniciadiLabel" runat="server" Text='<%# Eval("kullaniciadi") %>' />
            <br />
            <br />
            <br />
<br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [kullanicilar] WHERE ([Id] = @Id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
