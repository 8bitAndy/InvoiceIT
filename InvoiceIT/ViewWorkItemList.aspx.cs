using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewWorkItemList : System.Web.UI.Page
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
                    Response.Write("Hello " + userDetails[0] + " you are logged in as " + AccessLevel + " | <a href='Logout.aspx'>Log out</a>");
                }
                else
                {
                    // Defensive programming, return back to login if not a valid user
                    Response.Redirect("login.aspx");
                }
            }


            // Create a new workitem object to help display results
            WorkItem AllWorkItems = new WorkItem();

            // Assign results from query to a multi dimensional list
            List<List<string>> allworkitems = AllWorkItems.GetWorkItem();

            // Check to see if the list contains results or not
            if (allworkitems == null)
            {
                Response.Write("No records found");
            }
            else
            {
                // Get the length of results to be used in a loop below
                int results = allworkitems.Count;

                // Display the number of total staff
                Response.Write("<h3>Current Work Item list</h3>");
                Response.Write("<p> There are " + results + " work items in total <p>");

                // Display results for each invidiual staff member
                Response.Write("<div class='stafflistingcont'>");

                // Headers for the display of information
                Response.Write("<div class='rmslistingrow'>");
                Response.Write("<div class='work-item-id'>Work item ID</div>");
                Response.Write("<div class='company-name'>Date</div>");
                Response.Write("<div class='client-location'>Start time</div>");
                Response.Write("<div class='client-postcode'>End time</div>");
                Response.Write("<div class='work-item-status'>Status</div>");
                Response.Write("<div class='contact-first-name'>Client ID</div>");
                Response.Write("<div class='contact-last-name'>Task ID</div>");
                Response.Write("<div class='client-status'>Staff ID</div>");
                Response.Write("<div class='work-item-view'>More details</div>");
                Response.Write("<div class='work-item-comments'>Comments</div>");
                Response.Write("<br/>");
                Response.Write("<hr class='main-hr' />");
                Response.Write("<br/>");

                // Create each staff members display of details within the web form
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='stafflistingrow'>");
                    Response.Write("<div class='work-item-id'>" + allworkitems[i][0] + "</div>");
                    Response.Write("<div class='company-name'>" + allworkitems[i][1].Substring(0, 10) + "</div>");
                    Response.Write("<div class='client-location'>" + allworkitems[i][2] + "</div>");
                    Response.Write("<div class='client-postcode'>" + allworkitems[i][3] + "</div>");
                    Response.Write("<div class='work-item-status'>" + allworkitems[i][4] + "</div>");
                    Response.Write("<div class='contact-first-name'>" + allworkitems[i][5] + "</div>");
                    Response.Write("<div class='contact-last-name'>" + allworkitems[i][6] + "</div>");
                    Response.Write("<div class='client-status'>" + allworkitems[i][7] + "</div>");
                    Response.Write("<a class='work-item-view' href='ViewWorkItemDetails.aspx?ID=" + allworkitems[i][0] + "'>View</a>");
                    Response.Write("<div class='work-item-comments'>" + allworkitems[i][8] + "</div>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");
                Response.Write("<br/>");
                Response.Write("<br/>");
            }
        }
    }
}