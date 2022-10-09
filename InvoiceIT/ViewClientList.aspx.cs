using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewClientList : System.Web.UI.Page
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
            Client AllClients = new Client();

            // Assign results from query to a multi dimensional list
            List<List<string>> allclients = AllClients.GetClient();

            // Check to see if the list contains results or not
            if (allclients == null)
            {
                Response.Write("No records found");
            }
            else
            {
                // Get the length of results to be used in a loop below
                int results = allclients.Count;

                // Display the number of total staff
                Response.Write("<h3>Current Client list</h3>");
                Response.Write("<p> There are " + results + " clients in total <p>");

                // Display results for each invidiual staff member
                Response.Write("<div class='stafflistingcont'>");

                // Headers for the display of information
                Response.Write("<div class='rmslistingrow'>");
                Response.Write("<div class='client-id'>Client ID</div>");
                Response.Write("<div class='company-name'>Company Name</div>");
                Response.Write("<div class='client-location'>Location</div>");
                Response.Write("<div class='client-postcode'>Postcode</div>");
                Response.Write("<div class='client-address-1'>Address 1</div>");
                Response.Write("<div class='contact-first-name'>Contact first name</div>");
                Response.Write("<div class='contact-last-name'>Contact last name</div>");
                Response.Write("<div class='client-status'>Status</div>");
                Response.Write("<br/>");
                Response.Write("<hr class='main-hr' />");
                Response.Write("<br/>");

                // Create each staff members display of details within the web form
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='stafflistingrow'>");
                    Response.Write("<div class='client-id'>" + allclients[i][0] + "</div>");
                    Response.Write("<div class='company-name'>" + allclients[i][1] + "</div>");
                    Response.Write("<div class='client-location'>" + allclients[i][4] + "</div>");
                    Response.Write("<div class='client-postcode'>" + allclients[i][5] + "</div>");
                    Response.Write("<div class='client-address-1'>" + allclients[i][2] + "</div>");
                    Response.Write("<div class='contact-first-name'>" + allclients[i][6] + "</div>");
                    Response.Write("<div class='contact-last-name'>" + allclients[i][7] + "</div>");
                    Response.Write("<div class='client-status'>" + allclients[i][11] + "</div>");
                    Response.Write("<a class='staff-view-details' href='ViewClientDetails.aspx?ID=" + allclients[i][0] + "'>View</a>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");
                Response.Write("<br/>");
                Response.Write("<br/>");
            }
        }
    }
}