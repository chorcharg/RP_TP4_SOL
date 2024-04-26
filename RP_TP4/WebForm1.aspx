<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RP_TP4.WebForm1" %>

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
            height: 63px;
        }
        .auto-style3 {
            height: 63px;
            width: 206px;
        }
        .auto-style4 {
            width: 206px;
        }
        .auto-style7 {
            height: 61px;
        }
        .auto-style8 {
            height: 61px;
            width: 206px;
        }
        .auto-style9 {
            height: 43px;
        }
        .auto-style10 {
            width: 206px;
            height: 43px;
        }
        .auto-style11 {
            height: 38px;
        }
        .auto-style12 {
            width: 206px;
            height: 38px;
        }
        .auto-style13 {
            height: 51px;
        }
        .auto-style14 {
            width: 206px;
            height: 51px;
        }
        .auto-style15 {
            height: 48px;
        }
        .auto-style16 {
            width: 206px;
            height: 48px;
        }
        .auto-style17 {
            height: 63px;
            width: 266px;
        }
        .auto-style18 {
            height: 48px;
            width: 266px;
        }
        .auto-style19 {
            height: 51px;
            width: 266px;
        }
        .auto-style20 {
            width: 266px;
        }
        .auto-style21 {
            height: 61px;
            width: 266px;
        }
        .auto-style22 {
            height: 43px;
            width: 266px;
        }
        .auto-style23 {
            height: 38px;
            width: 266px;
        }
        .auto-style24 {
            height: 63px;
            width: 351px;
        }
        .auto-style25 {
            height: 48px;
            width: 351px;
        }
        .auto-style26 {
            height: 51px;
            width: 351px;
        }
        .auto-style27 {
            width: 351px;
        }
        .auto-style28 {
            height: 61px;
            width: 351px;
        }
        .auto-style29 {
            height: 43px;
            width: 351px;
        }
        .auto-style30 {
            height: 38px;
            width: 351px;
        }
        .auto-style31 {
            height: 63px;
            width: 56px;
        }
        .auto-style32 {
            height: 48px;
            width: 56px;
        }
        .auto-style33 {
            height: 51px;
            width: 56px;
        }
        .auto-style34 {
            width: 56px;
        }
        .auto-style35 {
            height: 61px;
            width: 56px;
        }
        .auto-style36 {
            height: 43px;
            width: 56px;
        }
        .auto-style37 {
            height: 38px;
            width: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style24"></td>
                    <td class="auto-style3"><strong>DESTINO DE INICIO</strong></td>
                    <td class="auto-style17"></td>
                    <td class="auto-style31"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style25"></td>
                    <td class="auto-style16"><strong>PROVINCIA:</strong></td>
                    <td class="auto-style18"><strong>
                        <asp:DropDownList ID="DdlProvinciaInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlProvinciaInicio_SelectedIndexChanged">
                        </asp:DropDownList>
                        </strong></td>
                    <td class="auto-style32"></td>
                    <td class="auto-style15"></td>
                    <td class="auto-style15"></td>
                    <td class="auto-style15"></td>
                </tr>
                <tr>
                    <td class="auto-style26"><strong></strong></td>
                    <td class="auto-style14"><strong>LOCALIDAD:</strong></td>
                    <td class="auto-style19">
                        <asp:DropDownList ID="DdlLocalidadInicio" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style33"><strong></strong></td>
                    <td class="auto-style13"><strong></strong></td>
                    <td class="auto-style13"><strong></strong></td>
                    <td class="auto-style13"><strong></strong></td>
                </tr>
                <tr>
                    <td class="auto-style27">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style34">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28"></td>
                    <td class="auto-style8">DESTINO FINAL</td>
                    <td class="auto-style21"></td>
                    <td class="auto-style35"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style29"></td>
                    <td class="auto-style10"><strong>PROVINCIA:</strong></td>
                    <td class="auto-style22">
                        <asp:DropDownList ID="DdlProvinciaFinal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlProvinciaFinal_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style36"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style30"></td>
                    <td class="auto-style12"><strong>LOCALIDAD:</strong></td>
                    <td class="auto-style23">
                        <asp:DropDownList ID="DdlLocalidadFinal" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style37"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
