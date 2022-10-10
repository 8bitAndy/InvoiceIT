using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewWorkItemDetails : System.Web.UI.Page
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

            // Code that generates details of current staff
            // Test if page loaded with an ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int WorkItem_ID))
            {
                // Create a new work item object
                WorkItem workitem = new WorkItem();
                // New list without a name yet
                _ = new List<string>(9);
                List<string> WorkItemData = workitem.GetWorkItem(WorkItem_ID);

                // Check if list is empty or not
                bool isEmpty = AppUtilities.IsEmpty(WorkItemData);

                if (isEmpty)
                {
                    // If list is empty
                    Response.Write("There was an unexpected error - no staff details were returned.");
                }
                else
                {
                    // Display details from the query here
                    Response.Write("<br/>");
                    Response.Write("<h3>Details for work item with ID " + WorkItemData[0] + "</h3>");
                    Response.Write("<br/>");
                    Response.Write("Work item ID: " + WorkItemData[0] + "<br/>");
                    Response.Write("Date: " + WorkItemData[1].Substring(0, 10) + "<br/>");
                    Response.Write("Start time: " + WorkItemData[2] + "<br/>");
                    Response.Write("End time: " + WorkItemData[3] + "<br/>");
                    Response.Write("Status: " + WorkItemData[4] + "<br/>");
                    Response.Write("Client_ID: " + WorkItemData[5] + "<br/>");
                    Response.Write("Task_ID: " + WorkItemData[6] + "<br/>");
                    Response.Write("Staff_ID: " + WorkItemData[7] + "<br/>");
                    Response.Write("Comment: " + WorkItemData[8] + "<br/>");
                    Response.Write("<br/>");
                    Response.Write("<a href='UpdateWorkItem.aspx?ID=" + WorkItemData[0] + "'>Update work item</a>");
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
    }
}