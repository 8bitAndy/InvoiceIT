<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkItem.aspx.cs" Inherits="InvoiceIT.AddWorkItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add a new work item</title>
    <link rel="stylesheet" href="styles.css" />
    <link rel="stylesheet" href="jqrui/jquery-ui.min.css" />
    <script src="jqrui/external/jquery/jquery.js"></script>
    <script src="jqrui/jquery-ui.min.js"></script>
    <script>
        $(function () {
            $("#CtrlWorkItemDate").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
        });
    </script>
</head>
<body>
    <form id="AddNewWorkItem" runat="server">
        <div class="page-header">
            <asp:Label ID="LblAddNewClientHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body-add-client">
            <asp:Label ID="LblAddNewStaffMember" class="body-title" runat="server" Text="Add a new work item"></asp:Label>

            <div class="add-work-item-page-content">
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblWorkItemDate" runat="server" Text="Date*"></asp:Label>
                        <br />
                        <input type="text" id="CtrlWorkItemDate" runat="server" />
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblClientList" runat="server" Text="Client*"></asp:Label>
                        <br />
                        <asp:Literal ID="ClientsListPH" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="Label1" runat="server" Text="Start time*"></asp:Label>
                        <br />
                        <input type="text" id="Text1" runat="server" />
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblTaskList" runat="server" Text="Task*"></asp:Label>
                        <br />
                        <asp:Literal ID="TaskListPH" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="Label3" runat="server" Text="End time*"></asp:Label>
                        <br />
                        <input type="text" id="Text2" runat="server" />
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblStaffList" runat="server" Text="Staff member*"></asp:Label>
                        <br />
                        <asp:Literal ID="StaffListPH" runat="server"></asp:Literal>
                    </div>
                </div>


                <div class="add-client-button-container">
                    <div class="button-two-row">
                        <asp:Button ID="BtnAddNewWorkItem" class="submit-button" runat="server" OnClick="BtnAddNewWorkItem_Click" Text="Add new work item" />
                    </div>
                    <div class="button-one-row">
                        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="WorkItemPortal.aspx" runat="server">Back to menu</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
