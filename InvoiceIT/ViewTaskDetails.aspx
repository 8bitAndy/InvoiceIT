<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTaskDetails.aspx.cs" Inherits="InvoiceIT.ViewTaskDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View task details</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <div id="frmcontTaskDelete" runat="server">
    <form id="ViewTaskDetails" runat="server">
        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="ViewTaskList.aspx" runat="server">Go Back</asp:LinkButton>
        <br/>
        <div class="delete-button-container">
            <asp:Button ID="BtnDeleteCurrentTask" class="delete-button" OnClick="BtnDeleteCurrentTask_Click" runat="server" Text="Delete current task" />
        </div>
        <br/>
        <asp:Literal ID="ErrorMessagePH" runat="server"></asp:Literal>
    </form>
    </div>
</body>
</html>
