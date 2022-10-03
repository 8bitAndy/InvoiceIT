<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="InvoiceIT.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice IT Login</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-header">
            <asp:Label ID="LblMainHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblMainMenu" class="login-title" runat="server" Text="Login"></asp:Label>

            <div class="login-page-content">
                <div class="textbox-with-label-above">
                    <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
                    <br />
                    <asp:TextBox ID="CtrlUsername" runat="server"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator 
                    ControlToValidate="CtrlUsername"
                    ID="rfvUsername"
                    class="field-validator-login"
                    Display="Static"
                    ErrorMessage="A username is required"
                    runat="server"/>

                <div class="textbox-with-label-above">
                    <asp:Label ID="LblUserPassword" runat="server" Text="Password"></asp:Label>
                    <br />
                    <asp:TextBox ID="CtrlUserPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator 
                    ControlToValidate="CtrlUserPassword"
                    ID="rfvUserPassword"
                    class="field-validator-login"
                    Display="Static"
                    ErrorMessage="A password is required"
                    runat="server"/>
                <div class="login-button-container">
                    <asp:Button ID="BtnLogin" class="submit-button" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
