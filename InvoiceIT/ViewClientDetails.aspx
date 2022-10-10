<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewClientDetails.aspx.cs" Inherits="InvoiceIT.ViewClientDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View client details</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <div id="frmcontClientDelete" runat="server">
    <form id="ViewClientDetails" runat="server">
        <asp:HiddenField ID="CtrlClientID" runat="server" Value=""></asp:HiddenField>
        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="ViewClientList.aspx" runat="server">Go Back</asp:LinkButton>
        <br/>
        <div class="delete-button-container">
            <asp:Button ID="BtnDeleteCurrentClient" class="delete-button" OnClick="BtnDeleteCurrentClient_Click" runat="server" Text="Delete current staff" />
        </div>
    </form>
     </div>
</body>
</html>
