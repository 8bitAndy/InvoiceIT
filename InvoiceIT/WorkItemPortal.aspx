<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkItemPortal.aspx.cs" Inherits="InvoiceIT.WorkItemPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Work Item Management Portal</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="WorkItemManagementPortal" class="page-no-scroll" runat="server">
        <div class="page-header">
            <asp:Label ID="LblMainHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblClientManagementPortal" class="body-title" runat="server" Text="Work item management portal"></asp:Label>

            <div class="staff-management-page-content">
                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="LblViewAllWorkItems" class="main-button-label" runat="server" Height="50" Text="View all work items"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnViewAllClients" class="submit-button" runat="server" href="ViewWorkItemList.aspx">View all</asp:LinkButton>
                    </div>
                    <div class="button-with-text-above">
                        <asp:Label ID="LblAddNewClient" class="main-button-label" runat="server" Height="50" Text="Add work item"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnAddNewWorkItem" class="submit-button" runat="server" href="AddWorkItem.aspx">Add Work Item</asp:LinkButton>
                    </div>
                </div>
                <div class="text-information">
                    <p class="p-information-text">- A work item can have its data changed from within the view all work items tab</p>
                    <p class="p-information-text">- A work item can be removed from within the view all work items tab</p>
                </div>
                <div class="button-one-row">
                    <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="index.aspx" runat="server">Back to menu</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
