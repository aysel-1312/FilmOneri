<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="filmdetay2.aspx.cs" Inherits="odevim.filmdetay2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 24px;
        }
        .auto-style3 {
            height: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FİLM DETAY</td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image1" runat="server" Height="151px" Width="172px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Film BİLGİLERİ</td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>FİLMDEN YAPILAN ALINTILAR</td>
            <td>&nbsp;HAKKINDA YAPILAN İNCELEMELER</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="GridView3" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButton1" runat="server" Text="Filmi izledim" />
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Filmi izlemedim" />
            </td>
            <td>&nbsp;Puan Ver(1-10)<asp:TextBox ID="TextBox1" runat="server" BorderWidth="2px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Puan Ver" Height="30px" OnClick="Button1_Click" Width="103px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Filmi İzleyen Sayısı =<asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td class="auto-style2">Film Puanı(İMDB)=<asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="Button2" runat="server" BorderWidth="2px" OnClick="Button2_Click" Text="ALINTI YAP" />
            </td>
            <td class="auto-style2">
                <asp:Button ID="Button3" runat="server" BorderWidth="2px" OnClick="Button3_Click" Text="İNCELEME YAP" />
            </td>
        </tr>
    </table>
</asp:Content>
