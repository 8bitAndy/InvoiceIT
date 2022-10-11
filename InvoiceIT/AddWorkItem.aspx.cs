using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class AddWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check to see if a user should be permitted onto this page
            if (System.Web.HttpContext.Current.Session["CurrentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                // Create new array list to hold details of current user
                _ = new ArrayList();
                ArrayList userDetails = (ArrayList)Session["CurrentUser"];
                // Get the access level of a user and store for later
                string AccessLevel = (string)userDetails[1];
                // Trim all leading or trailing white space
                AccessLevel = AccessLevel.Trim();

                // Give the user a tailored message depending on login credentials
                if (AccessLevel == "Administrator")
                {
                    Response.Write("Hello " + userDetails[0] + " you are logged in as " + AccessLevel + " | <a href='Logout.aspx'>Log out</a>");
                }
                else if (AccessLevel == "Staff")
                {
                    // Defensive programming, return back to main page if staff
                    Response.Write("Hello " + userDetails[0] + " you are logged in as " + AccessLevel + " | <a href='Logout.aspx'>Log out</a>");
                }
                else
                {
                    // Defensive programming, return back to login if not a valid user
                    Response.Redirect("login.aspx");
                }
            }

            // Generate the pre populated drop down lists

            /*
             CODE FOR GENERATING CLIENT DROP DOWN LIST
             */

            // Create a variable to hold the generated drop list for clients
            string dlclient;

            // Create a new client object
            Client AllClients = new Client();

            List<List<string>> allclients = AllClients.GetClient();

            // Check to see if allclients is empty
            if(allclients == null)
            {
                ClientsListPH.Text = "Error - no clients found";
            }
            else
            {
                // Get the count of how many records there are for clients
                int clientCount = allclients.Count;

                // Create the courses droplist
                
                dlclient = "<select class='dllist' name='CtrlClientList'>";
                dlclient += "<option value='0'>--Please make a selection--</option>";

                // Add all the clients to the client drop down list
                for(int i =0; i <= clientCount - 1; i++)
                {
                    dlclient += "<option value='" + allclients[i][0] + "'>" + allclients[i][1] + " (ID " + allclients[i][0] + ")" + "</option>";
                }

                dlclient += "</select>";
                // Add the course droplist to the placeholder on the aspx page
                ClientsListPH.Text = dlclient;
            }


            /*
             CODE FOR GENERATING TASK DROP DOWN LIST
             */

            // Create a variable to hold the generated drop list for tasks
            string dltask;

            // Create a new task object
            Task AllTasks = new Task();

            List<List<string>> alltasks = AllTasks.GetTask();

            // Check to see if alltasks is empty
            if (alltasks == null)
            {
                TaskListPH.Text = "Error - no tasks found";
            }
            else
            {
                // Get the count of how many records there are for tasks
                int taskCount = alltasks.Count;

                // Create the tasks droplist

                dltask = "<select class='dllist' name='CtrlTaskList'>";
                dltask += "<option value='0'>--Please make a selection--</option>";

                // Add all the tasks to the task drop down list
                for (int j = 0; j <= taskCount - 1; j++)
                {
                    dltask += "<option value='" + alltasks[j][0] + "'>" + alltasks[j][1] + " (ID " + alltasks[j][0] + ")" + "</option>";
                }

                dltask += "</select>";
                // Add the course droplist to the placeholder on the aspx page
                TaskListPH.Text = dltask;
            }


            /*
             CODE FOR GENERATING STAFF DROP DOWN LIST
             */

            // Create a variable to hold the generated drop list for staff
            string dlstaff;

            // Create a new staff object
            Staff AllStaff = new Staff();

            List<List<string>> allstaff = AllStaff.GetStaff();

            // Check to see if allstaff is empty
            if (allstaff == null)
            {
                StaffListPH.Text = "Error - no tasks found";
            }
            else
            {
                // Get the count of how many records there are for staff
                int staffCount = allstaff.Count;

                // Create the staff droplist
                dlstaff = "<select class='dllist' name='CtrlStaffList'>";
                dlstaff += "<option value='0'>--Please make a selection--</option>";

                // Add all the staff to the staff drop down list
                for (int k = 0; k <= staffCount - 1; k++)
                {
                    dlstaff += "<option value='" + allstaff[k][0] + "'>" + allstaff[k][1] + " " + allstaff[k][2] +  " (ID " + allstaff[k][0] + ")" + "</option>";
                }

                dlstaff += "</select>";
                // Add the staff droplist to the placeholder on the aspx page
                StaffListPH.Text = dlstaff;
            }
        }

        protected void BtnAddNewWorkItem_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // Check to see if date picker was filled out, prevents errors
                if(Request.Form["CtrlWorkItemDate"] == null || string.IsNullOrWhiteSpace(Request.Form["CtrlWorkItemDate"]))
                {
                    LblValidatorList.Text = "<p class='error-text'>Date was not entered</p>";
                }
                else
                {
                    // This code executes if the user has correctly chosen a date
                    LblValidatorList.Text = "";

                    // Create a new name value collection with the populated fields in the form
                    NameValueCollection NewWorkItemData = Request.Form;
                    // Create a new work item object
                    WorkItem NewWorkItem = new WorkItem();
                    // Saves values in form to database
                    string Result = NewWorkItem.AddWorkItem(NewWorkItemData);
                    // Print the result of the query to the user
                    Response.Write("<br/>" + Result);
                    // Clear the form so another entry can happen
                    AppUtilities.ClearForm(Form.Controls);
                }
            }
            
        }
    }
}