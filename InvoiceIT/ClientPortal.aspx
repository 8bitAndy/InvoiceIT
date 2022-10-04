<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientPortal.aspx.cs" Inherits="InvoiceIT.ClientPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Management Portal</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="ClientManagementPortal" class="page-no-scroll" runat="server">
        <div class="page-header">
            <asp:Label ID="LblMainHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblClientManagementPortal" class="body-title" runat="server" Text="Client management portal"></asp:Label>

            <div class="staff-management-page-content">
                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="LblViewAllClients" class="main-button-label" runat="server" Height="50" Text="View all clients"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnViewAllClients" class="submit-button" runat="server" href="ViewClientList.aspx">View all</asp:LinkButton>
                    </div>
                    <div class="button-with-text-above">
                        <asp:Label ID="LblAddNewClient" class="main-button-label" runat="server" Height="50" Text="Add new client"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnAddNewClient" class="submit-button" runat="server" href="AddClient.aspx">Add Client</asp:LinkButton>
                    </div>
                </div>
                <div class="text-information">
                    <p class="p-information-text">- A client can have their data changed from within the view all staff tab</p>
                    <p class="p-information-text">- A client can be removed from within the view all staff tab</p>
                </div>
                <div class="button-one-row">
                    <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="index.aspx" runat="server">Back to menu</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
