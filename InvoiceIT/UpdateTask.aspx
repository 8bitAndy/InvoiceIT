<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTask.aspx.cs" Inherits="InvoiceIT.UpdateTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update task</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <div id="frmcontTask" runat="server">
    <form id="AddNewTaskForm" class="page-no-scroll" runat="server">
        <asp:HiddenField ID="CtrlTaskID" runat="server" Value=""></asp:HiddenField>
        <div class="page-header">
            <asp:Label ID="LblAddNewTaskHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblAddNewStaffMember" class="body-title" runat="server" Text=""></asp:Label>

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
                        <asp:Button ID="BtnUpdateTask" class="submit-button" runat="server" OnClick="BtnUpdateTask_Click" Text="Update task" />
                    </div>
                    <div class="button-one-row">
                        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="ViewTaskList.aspx" runat="server">Back to menu</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
    </div>
</body>
</html>
