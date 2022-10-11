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
    public partial class UpdateTask : System.Web.UI.Page
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


            // Make sure a parameter has been passed via the url and can be cast as an integer
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_ID))
            {
                Task task = new Task(); // Create a client object from the Client class
                _ = new List<string>(4); // Create a new List object of type string
                List<string> TaskData = task.GetTask(Task_ID); // Place data returned by method into a list named clientdata
                bool isEmpty = AppUtilities.IsEmpty(TaskData); // Check whether or not the clientdata list is empty or not

                // Write customised header above form
                this.LblAddNewStaffMember.Text = "Update Details for task ID " + TaskData[0];

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no client details were returned"); // If Clientdata list is null or empty, inform user
                }
                else
                {  // If clientdata list contains data, place into the appropriate form locations

                    // Write client details to matching target controls in form
                    this.CtrlTaskID.Value = TaskData[0].ToString();
                    this.CtrlTaskTitle.Text = TaskData[1];
                    this.CtrlTaskDescription.Text = TaskData[2];
                    this.CtrlTaskRate.Text = TaskData[3].ToString();
                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }
        }

        protected void BtnUpdateTask_Click(object sender, EventArgs e)
        {
            // If form data is submitted via button press
            if (IsPostBack)
            {
                // Create a new object and populate it with the form data
                NameValueCollection UpdateTaskData = Request.Form;
                Task UpdateTask = new Task();
                // Complete the query and get a message back
                string Result = UpdateTask.UpdateTask(UpdateTaskData);
                // Print appropriate output to user
                if (Result == "Query Succeeded")
                {
                    this.frmcontTask.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='success'>Task details updated successfully.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");
                }
                else
                {
                    this.frmcontTask.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='error'>Update failed, task details have not been changed.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");
                }

            }
        }
    }
}