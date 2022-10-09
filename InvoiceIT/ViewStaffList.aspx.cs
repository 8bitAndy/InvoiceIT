using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewStaffList : System.Web.UI.Page
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


            // Create a new staff object to help display results
            Staff AllStaff = new Staff();

            // Assign results from query to a multi dimensional list
            List<List<string>> allstaff = AllStaff.GetStaff();

            // Check to see if the list contains results or not
            if(allstaff == null)
            {
                Response.Write("No records found");
            }
            else
            {
                // Get the length of results to be used in a loop below
                int results = allstaff.Count;

                // Display the number of total staff
                Response.Write("<h3>Current Staff list</h3>");
                Response.Write("<p> There are " +results + " staff members in total <p>");

                // Display results for each invidiual staff member
                Response.Write("<div class='stafflistingcont'>");

                // Headers for the display of information
                Response.Write("<div class='rmslistingrow'>");
                Response.Write("<div class='staff-id'> Staff ID</div>");
                Response.Write("<div class='staff-first-name'>First name</div>");
                Response.Write("<div class='staff-last-name'>Last name</div>");
                Response.Write("<div class='staff-email'>Email</div>");
                Response.Write("<div class='staff-mobile'>Mobile</div>");
                Response.Write("<div class='staff-access-level'>Access level</div>");
                Response.Write("<div class='staff-status'>Status</div>");
                Response.Write("<br/>");
                Response.Write("<hr class='main-hr' />");
                Response.Write("<br/>");

                // Create each staff members display of details within the web form
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='stafflistingrow'>");
                    Response.Write("<div class='staff-id'>" + allstaff[i][0] + "</div>");
                    Response.Write("<div class='staff-first-name'>" + allstaff[i][1] + "</div>");
                    Response.Write("<div class='staff-last-name'>" + allstaff[i][2] + "</div>");
                    Response.Write("<div class='staff-email'>" + allstaff[i][3] + "</div>");
                    Response.Write("<div class='staff-mobile'>" + allstaff[i][4] + "</div>");
                    Response.Write("<div class='staff-access-level'>" + allstaff[i][5] + "</div>");
                    Response.Write("<div class='staff-status'>" + allstaff[i][6] + "</div>");
                    Response.Write("<a class='staff-view-details' href='ViewStaffDetails.aspx?ID=" + allstaff[i][0] + "'>View</a>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");
                Response.Write("<br/>");
                Response.Write("<br/>");
            }
        }
    }
}