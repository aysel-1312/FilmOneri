<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="KullaniciKayit.aspx.cs" Inherits="odevim.KullaniciKayit" %>

<script runat="server">


  
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="Id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="isim" HeaderText="isim" SortExpression="isim" />
                        <asp:BoundField DataField="soyisim" HeaderText="soyisim" SortExpression="soyisim" />
                        <asp:BoundField DataField="cinsiyet" HeaderText="cinsiyet" SortExpression="cinsiyet" />
                        <asp:BoundField DataField="dogumtarihi" HeaderText="dogumtarihi" SortExpression="dogumtarihi" />
                        <asp:BoundField DataField="kullaniciadi" HeaderText="kullaniciadi" SortExpression="kullaniciadi" />
                        <asp:BoundField DataField="sifre" HeaderText="sifre" SortExpression="sifre" />
                        <asp:BoundField DataField="resim" HeaderText="resim" SortExpression="resim" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [kullanicilar] WHERE [Id] = @Id" InsertCommand="INSERT INTO [kullanicilar] ([Id], [isim], [soyisim], [cinsiyet], [dogumtarihi], [kullaniciadi], [sifre], [resim]) VALUES (@Id, @isim, @soyisim, @cinsiyet, @dogumtarihi, @kullaniciadi, @sifre, @resim)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [Id], [isim], [soyisim], [cinsiyet], [dogumtarihi], [kullaniciadi], [sifre], [resim] FROM [kullanicilar]" UpdateCommand="UPDATE [kullanicilar] SET [isim] = @isim, [soyisim] = @soyisim, [cinsiyet] = @cinsiyet, [dogumtarihi] = @dogumtarihi, [kullaniciadi] = @kullaniciadi, [sifre] = @sifre, [resim] = @resim WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                        <asp:Parameter Name="isim" Type="String" />
                        <asp:Parameter Name="soyisim" Type="String" />
                        <asp:Parameter Name="cinsiyet" Type="String" />
                        <asp:Parameter Name="dogumtarihi" Type="DateTime" />
                        <asp:Parameter Name="kullaniciadi" Type="String" />
                        <asp:Parameter Name="sifre" Type="String" />
                        <asp:Parameter Name="resim" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="isim" Type="String" />
                        <asp:Parameter Name="soyisim" Type="String" />
                        <asp:Parameter Name="cinsiyet" Type="String" />
                        <asp:Parameter Name="dogumtarihi" Type="DateTime" />
                        <asp:Parameter Name="kullaniciadi" Type="String" />
                        <asp:Parameter Name="sifre" Type="String" />
                        <asp:Parameter Name="resim" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Ad</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" ForeColor="#CCCCCC"></asp:TextBox>
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>soyad</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" BorderWidth="2px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>cinsiyet</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>ERKEK</asp:ListItem>
                    <asp:ListItem>KADIN</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>dogumtarihi</td>
            <td>
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>kullanıcı adı</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" BorderWidth="2px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>sifre</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" BorderWidth="2px" TextMode="Password"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>resim</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" BorderWidth="2px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Height="42px" OnClick="Button1_Click" Text="KAYIT OL" Width="197px" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
