<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewWorkItemDetails.aspx.cs" Inherits="InvoiceIT.ViewWorkItemDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View work item details</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="ViewWorkItemDetails" runat="server">
        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="ViewWorkItemList.aspx" runat="server">Go Back</asp:LinkButton>
        <br/>
        <div class="delete-button-container">
            <asp:Button ID="BtnDeleteCurrent" class="delete-button" runat="server" Text="Delete current item" />
        </div>
    </form>
</body>
</html>
