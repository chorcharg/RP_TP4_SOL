<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="RP_TP4.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 96px;
        }
        .auto-style3 {
            width: 98px;
        }
        .auto-style4 {
            width: 300px;
        }
        .auto-style5 {
            width: 96px;
            height: 23px;
        }
        .auto-style6 {
            width: 98px;
            height: 23px;
        }
        .auto-style7 {
            width: 300px;
            height: 23px;
        }
        .auto-style8 {
            height: 23px;
        }
        .auto-style12 {
            width: 150px;
            text-align: center;
        }
        .auto-style13 {
            width: 19px;
        }
        .auto-style14 {
            width: 19px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style14">
                        </td>
                    <td class="auto-style5">
                        </td>
                    <td class="auto-style6">
                        </td>
                    <td class="auto-style7" colspan="2">
                        </td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="Lb_IdProducto" runat="server" Text="Id Producto"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="Ddl_IdProducto" runat="server" Height="18px">
                            <asp:ListItem Value="=">Igual a</asp:ListItem>
                            <asp:ListItem Value="&gt;">Mayor a</asp:ListItem>
                            <asp:ListItem Value="&lt;">Menor a</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="Tb_IdProducto" runat="server" Width="289px" CausesValidation="True" ValidationGroup="vgFiltros"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Tb_IdProducto" ErrorMessage="RegularExpressionValidator" ValidationExpression="^[0-9]*$" ValidationGroup="vgFiltros">Solo numeros </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="Lb_IdCategoria" runat="server" Text="IdCategoria"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="Ddl_IdCategoria" runat="server" Height="18px">
                            <asp:ListItem Value="=">Igual a</asp:ListItem>
                            <asp:ListItem Value="&gt;">Mayor a</asp:ListItem>
                            <asp:ListItem Value="&lt;">Menor a</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="Tb_IdCategoria" runat="server" Width="290px" ValidationGroup="vgFiltros"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revCat" runat="server" ControlToValidate="Tb_IdCategoria" ErrorMessage="RegularExpressionValidator" ValidationExpression="^[0-9]*$" ValidationGroup="vgFiltros">Solo numeros </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style5"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style7" colspan="2">
                        <asp:Label ID="lbl_error1" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style12">
                        <asp:Button ID="Btn_Filtrar" runat="server" Text="Filtrar" OnClick="Btn_Filtrar_Click" ValidationGroup="vgFiltros" />
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="Btn_QuitarFiltro" runat="server" Text="Quitar filtro" OnClick="Btn_QuitarFiltro_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4" colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td colspan="5">
                        <asp:GridView ID="Gv_Productos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4" colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
