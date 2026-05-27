<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assessment1___ASP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>

            <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
            &nbsp;                    
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            &nbsp;&nbsp;                   
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
