<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginTest.aspx.cs" Inherits="Login.loginTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入用户名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;请输入密码：<asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <asp:Image ID="Image1" runat="server" Height="17px" Width="62px" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="看不清？" OnClick="Button2_Click" />
            <asp:ImageMap ID="ImageMap1" runat="server">
            </asp:ImageMap>
            <br />
            <br />
&nbsp;输入验证码:
            <asp:TextBox ID="TextBox3" runat="server" Width="59px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登陆" Width="89px" />
        </p>
    </form>
</body>
</html>
