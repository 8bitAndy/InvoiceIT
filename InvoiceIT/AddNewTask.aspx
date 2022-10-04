<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewTask.aspx.cs" Inherits="InvoiceIT.AddNewTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add new task</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="AddNewTaskForm" class="page-no-scroll" runat="server">
        <div class="page-header">
            <asp:Label ID="LblAddNewTaskHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblAddNewStaffMember" class="body-title" runat="server" Text="Add a new task"></asp:Label>

            <div class="main-page-content">
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblTaskTitle" runat="server" Text="Task Title*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlTaskTitle" class="textbox-large" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblTaskRate" runat="server" Text="Task Rate*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlTaskRate" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlTaskTitle"
                        ID="rfvTaskTitle"
                        Display="Static"
                        ErrorMessage="A task title is required"
                        runat="server"/>
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlTaskRate"
                        ID="rfvTaskRate"
                        Display="Static"
                        ErrorMessage="A task rate is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblTaskDescription" runat="server" Text="Task Description"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlTaskDescription" class="textbox-large" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="add-button-container">
                    <div class="button-two-row">
                        <asp:Button ID="BtnAddNewTask" class="submit-button" runat="server" OnClick="BtnAddNewTask_Click" Text="Add task" />
                    </div>
                    <div class="button-one-row">
                        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="TaskPortal.aspx" runat="server">Back to menu</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
