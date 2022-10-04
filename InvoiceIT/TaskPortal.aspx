<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskPortal.aspx.cs" Inherits="InvoiceIT.TaskPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task Management Portal</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="TaskManagementPortal" class="page-no-scroll" runat="server">
        <div class="page-header">
            <asp:Label ID="LblMainHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblTaskManagementPortal" class="body-title" runat="server" Text="Task management portal"></asp:Label>

            <div class="staff-management-page-content">
                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="LblViewAllTasks" class="main-button-label" runat="server" Height="50" Text="View all Tasks"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnViewAllTasks" class="submit-button" runat="server" href="ViewTaskList.aspx">View Tasks</asp:LinkButton>
                    </div>
                    <div class="button-with-text-above">
                        <asp:Label ID="LblAddNewTask" class="main-button-label" runat="server" Height="50" Text="Add a new Task"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnAddNewTask" class="submit-button" runat="server" href="AddNewTask.aspx">Add Task</asp:LinkButton>
                    </div>
                </div>
                <div class="text-information">
                    <p class="p-information-text">- A task can have its data changed from within the view all tasks tab</p>
                    <p class="p-information-text">- A task can be deleted from within the view all tasks tab</p>
                </div>
                <div class="button-one-row">
                    <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="index.aspx" runat="server">Back to menu</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
