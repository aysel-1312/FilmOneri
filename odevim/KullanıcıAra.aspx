<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="KullanıcıAra.aspx.cs" Inherits="odevim.KullanıcıAra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>KULLANICI ARAMA</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" BorderWidth="2px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Height="20px" OnClick="Button1_Click" Text="ARA" Width="84px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                TÜM KULLANICILAR</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [kullaniciadi], [Id] FROM [kullanicilar]"></asp:SqlDataSource>
                <br />
                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource1">

                     <ItemTemplate>
                                <li><a href="kullanicidetay.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>">
                                    <%#DataBinder.Eval(Container.DataItem,"kullaniciadi") %></a></li>
                            </ItemTemplate>
                </asp:Repeater>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
