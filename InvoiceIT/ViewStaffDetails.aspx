<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStaffDetails.aspx.cs" Inherits="InvoiceIT.ViewStaffDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View staff details</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="ViewStaffDetails" runat="server">
        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="ViewStaffList.aspx" runat="server">Go Back</asp:LinkButton>
        <br/>
        <div class="delete-button-container">
            <asp:Button ID="BtnDeleteCurrent" class="delete-button" runat="server" Text="Delete current staff" />
        </div>
    </form>
</body>
</html>
