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
                        <asp:Label ID="LblStartTime" runat="server" Text="Start time (24hr)*"></asp:Label>
                        <br />
                            <asp:DropDownList ID="CtrlStartTime" runat="server">
                            <asp:ListItem>9:00</asp:ListItem>
                            <asp:ListItem>9:15</asp:ListItem>
                            <asp:ListItem>9:30</asp:ListItem>
                            <asp:ListItem>9:45</asp:ListItem>
                            <asp:ListItem>10:00</asp:ListItem>
                            <asp:ListItem>10:15</asp:ListItem>
                            <asp:ListItem>10:30</asp:ListItem>
                            <asp:ListItem>10:45</asp:ListItem>
                            <asp:ListItem>11:00</asp:ListItem>
                            <asp:ListItem>11:15</asp:ListItem>
                            <asp:ListItem>11:30</asp:ListItem>
                            <asp:ListItem>11:45</asp:ListItem>
                            <asp:ListItem>12:00</asp:ListItem>
                            <asp:ListItem>12:15</asp:ListItem>
                            <asp:ListItem>12:30</asp:ListItem>
                            <asp:ListItem>12:45</asp:ListItem>
                            <asp:ListItem>13:00</asp:ListItem>
                            <asp:ListItem>13:15</asp:ListItem>
                            <asp:ListItem>13:30</asp:ListItem>
                            <asp:ListItem>13:45</asp:ListItem>
                            <asp:ListItem>14:00</asp:ListItem>
                            <asp:ListItem>14:15</asp:ListItem>
                            <asp:ListItem>14:30</asp:ListItem>
                            <asp:ListItem>14:45</asp:ListItem>
                            <asp:ListItem>15:00</asp:ListItem>
                            <asp:ListItem>15:15</asp:ListItem>
                            <asp:ListItem>15:30</asp:ListItem>
                            <asp:ListItem>15:45</asp:ListItem>
                            <asp:ListItem>16:00</asp:ListItem>
                            <asp:ListItem>16:15</asp:ListItem>
                            <asp:ListItem>16:30</asp:ListItem>
                            <asp:ListItem>16:45</asp:ListItem>
                            <asp:ListItem>17:00</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblTaskList" runat="server" Text="Task*"></asp:Label>
                        <br />
                        <asp:Literal ID="TaskListPH" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblEndTime" runat="server" Text="End time (24hr)*"></asp:Label>
                        <br />
                        <asp:DropDownList ID="CtrlEndTime"  runat="server">
                            <asp:ListItem>9:00</asp:ListItem>
                            <asp:ListItem>9:15</asp:ListItem>
                            <asp:ListItem>9:30</asp:ListItem>
                            <asp:ListItem>9:45</asp:ListItem>
                            <asp:ListItem>10:00</asp:ListItem>
                            <asp:ListItem>10:15</asp:ListItem>
                            <asp:ListItem>10:30</asp:ListItem>
                            <asp:ListItem>10:45</asp:ListItem>
                            <asp:ListItem>11:00</asp:ListItem>
                            <asp:ListItem>11:15</asp:ListItem>
                            <asp:ListItem>11:30</asp:ListItem>
                            <asp:ListItem>11:45</asp:ListItem>
                            <asp:ListItem>12:00</asp:ListItem>
                            <asp:ListItem>12:15</asp:ListItem>
                            <asp:ListItem>12:30</asp:ListItem>
                            <asp:ListItem>12:45</asp:ListItem>
                            <asp:ListItem>13:00</asp:ListItem>
                            <asp:ListItem>13:15</asp:ListItem>
                            <asp:ListItem>13:30</asp:ListItem>
                            <asp:ListItem>13:45</asp:ListItem>
                            <asp:ListItem>14:00</asp:ListItem>
                            <asp:ListItem>14:15</asp:ListItem>
                            <asp:ListItem>14:30</asp:ListItem>
                            <asp:ListItem>14:45</asp:ListItem>
                            <asp:ListItem>15:00</asp:ListItem>
                            <asp:ListItem>15:15</asp:ListItem>
                            <asp:ListItem>15:30</asp:ListItem>
                            <asp:ListItem>15:45</asp:ListItem>
                            <asp:ListItem>16:00</asp:ListItem>
                            <asp:ListItem>16:15</asp:ListItem>
                            <asp:ListItem>16:30</asp:ListItem>
                            <asp:ListItem>16:45</asp:ListItem>
                            <asp:ListItem>17:00</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblStaffList" runat="server" Text="Staff member*"></asp:Label>
                        <br />
                        <asp:Literal ID="StaffListPH" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblStatus" runat="server" Text="Status*"></asp:Label>
                        <br />
                        <asp:DropDownList ID="CtrlStatus" class="dropdown-list" runat="server">
                            <asp:ListItem>Paused</asp:ListItem>
                            <asp:ListItem>Ongoing</asp:ListItem>
                            <asp:ListItem>Completed</asp:ListItem>
                            <asp:ListItem>Discontinued</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblComment" runat="server" Text="Comments"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlComment" class="textbox-medium" runat="server" Textmode="MultiLine"></asp:TextBox>
                    </div>
                </div>

                <div class="add-work-item-button-container">
                    <div class="button-two-row">
                        <asp:Button ID="BtnAddNewWorkItem" class="submit-button" runat="server" OnClick="BtnAddNewWorkItem_Click" Text="Add new work item" />
                    </div>
                    <div class="button-one-row">
                        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="WorkItemPortal.aspx" runat="server">Back to menu</asp:LinkButton>
                    </div>
                    <asp:Literal ID="LblValidatorList" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
