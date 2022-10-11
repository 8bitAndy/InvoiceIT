using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewTaskDetails : System.Web.UI.Page
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
                    Response.Redirect("index.aspx");
                }
                else
                {
                    // Defensive programming, return back to login if not a valid user
                    Response.Redirect("login.aspx");
                }
            }

            // Code that generates details of current task
            // Test if page loaded with an ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_ID))
            {
                // Create a new task object
                Task task = new Task();
                // New list without a name yet
                _ = new List<string>(4);
                List<string> TaskData = task.GetTask(Task_ID);

                // Check if list is empty or not
                bool isEmpty = AppUtilities.IsEmpty(TaskData);

                if (isEmpty)
                {
                    // If list is empty
                    Response.Write("There was an unexpected error - no staff details were returned.");
                }
                else
                {
                    // Display details from the query here
                    Response.Write("<br/>");
                    Response.Write("<h3>Details for task ID " + TaskData[0] + "</h3>");
                    Response.Write("Task ID: " + TaskData[0] + "<br/>");
                    Response.Write("Task title: " + TaskData[1] + "<br/>");
                    Response.Write("Task description: " + TaskData[2] + "<br/>");
                    Response.Write("Task rate: " + TaskData[3] + "<br/>");
                    Response.Write("<br/>");
                    Response.Write("<a href='UpdateTask.aspx?ID=" + TaskData[0] + "'>Update Task Details</a>");
                    Response.Write("<br/>");
                    Response.Write("<br/>");
                }
            }
            else
            {
                // Something went wrong code here
                Response.Write("No ID in url or couldn't parse to an int");
            }
        }

        protected void BtnDeleteCurrentTask_Click(object sender, EventArgs e)
        {
            // If form data is submitted via button press
            if (IsPostBack)
            {
                // Get the current forms client ID from the parameters
                int TaskID = Convert.ToInt32(Request.Params["ID"]);




                // Code here to check if task id is in use elsewhere. If so it cannot be deleted.
                // Check work item to see if task is there
                WorkItem CheckWorkItem = new WorkItem();
                // Get a list of every work item
                List<List<string>> allworkitems = CheckWorkItem.GetWorkItem();

                // Check invoices to see if client is there
                LineItem CheckLineItem = new LineItem();
                // Get a list of every invoice
                List<List<string>> alllineitems = CheckLineItem.GetLineItem();

                // Count of how many work items or invoices the client appears in
                int mentions = 0;

                // If results are not null then make a count
                if (allworkitems != null || alllineitems != null)
                {
                    // Number of results returned from query
                    int results1 = allworkitems.Count;

                    // Loop through results and check to see if client is mentioned in any work items
                    for (int i = 0; i <= results1 - 1; i++)
                    {
                        // See if client id matches the current client ID
                        if (Convert.ToInt32(allworkitems[i][6]) == TaskID)
                        {
                            mentions += 1;
                        }
                    }
                    // Check if task id appears in any invoices and add to count if they do
                    // Number of results returned from query
                    int results2 = alllineitems.Count;

                    // Loop through results and check to see if task is mentioned in any invoices
                    for (int j = 0; j <= results2 - 1; j++)
                    {
                        // See if task id matches the invoice id
                        if (Convert.ToInt32(alllineitems[j][2]) == TaskID)
                        {
                            mentions += 1;
                        }
                    }
                }
                if (mentions >= 1)
                {
                    // Print to screen if client is mentioned in
                    ErrorMessagePH.Text = "The current task is used in other parts of the application, cannot be deleted until other references are deleted";
                }
                else
                {
                    // No error message since client can be deleted
                    ErrorMessagePH.Text = "";

                    // Carry on with deletion since it is allowed
                    // Create a new client object to send ID to
                    // Create a new task object to send ID to
                    Task DeleteTask = new Task();

                    // Get the result of the delete query
                    string Result = DeleteTask.DeleteTask(TaskID);
                    if (Result == "Query Succeeded")
                    {
                        this.frmcontTaskDelete.Visible = false;
                        Response.Write("<br/>");
                        Response.Write("<span class='success'>Task details deleted successfully.</span><br />");
                        Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");
                    }
                    else
                    {
                        this.frmcontTaskDelete.Visible = false;
                        Response.Write("<br/>");
                        Response.Write("<span class='error'>Deletion failed, task details have not been changed.</span><br />");
                        Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");
                    }
                }
            }
        }
    }
}