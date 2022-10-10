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
                if (AccessLevel == "Staff")
                {
                    Response.Write("Hello " + userDetails[0] + " you are logged in as " + AccessLevel + " | <a href='Logout.aspx'>Log out</a>");
                }
                else if (AccessLevel == "Administrator")
                {
                    Response.Write("Hello " + userDetails[0] + " you are logged in as " + AccessLevel + " | <a href='Logout.aspx'>Log out</a>");
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
                // Create a new task object to send ID to
                Task DeleteTask = new Task();

                // Get the result of the delete query
                string Result = DeleteTask.DeleteTask(TaskID);
                if (Result == "Query Succeeded")
                {
                    this.frmcontTaskDelete.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='success'>Task details deleted successfully.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Course List</a>");
                }
                else
                {
                    this.frmcontTaskDelete.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='error'>Deletion failed, task details have not been changed.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Course List</a>");
                }

            }
        }
    }
}