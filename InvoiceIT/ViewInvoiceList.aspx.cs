using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewInvoiceList : System.Web.UI.Page
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


            // Create a new workitem object to help display results
            Invoice AllInvoices = new Invoice();

            // Assign results from query to a multi dimensional list
            List<List<string>> allinvoices = AllInvoices.GetInvoice();

            // Check to see if the list contains results or not
            if (allinvoices == null)
            {
                Response.Write("No records found");
            }
            else
            {
                // Get the length of results to be used in a loop below
                int results = allinvoices.Count;

                // Display the number of total staff
                Response.Write("<h3>Current Invoice list</h3>");
                Response.Write("<p> There are " + results + " invoices in total <p>");

                // Display results for each invidiual staff member
                Response.Write("<div class='stafflistingcont'>");

                // Headers for the display of information
                Response.Write("<div class='rmslistingrow'>");
                Response.Write("<div class='work-item-id'>Invoice Number</div>");
                Response.Write("<div class='invoice-date'>Start Date</div>");
                Response.Write("<div class='invoice-date'>End Date</div>");
                Response.Write("<div class='invoice-date-long'>Invoice update date</div>");
                Response.Write("<div class='invoice-date-long'>Invoice sent date</div>");
                Response.Write("<div class='contact-first-name'>Payment due date</div>");
                Response.Write("<div class='contact-last-name'>Status of invoice</div>");
                Response.Write("<div class='client-status'>Client ID</div>");
                Response.Write("<div class='work-item-view'>View details</div>");
                Response.Write("<br/>");
                Response.Write("<hr class='main-hr' />");
                Response.Write("<br/>");

                // Create each staff members display of details within the web form
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='stafflistingrow'>");
                    Response.Write("<div class='work-item-id'>" + allinvoices[i][0] + "</div>");
                    Response.Write("<div class='invoice-date'>" + allinvoices[i][1].Substring(0, 10) + "</div>");
                    Response.Write("<div class='invoice-date'>" + allinvoices[i][2].Substring(0, 10) + "</div>");
                    Response.Write("<div class='invoice-date-long'>" + allinvoices[i][3].Substring(0, 10) + "</div>");
                    Response.Write("<div class='invoice-date-long'>" + allinvoices[i][4].Substring(0, 10) + "</div>");
                    Response.Write("<div class='contact-first-name'>" + allinvoices[i][5].Substring(0, 10) + "</div>");
                    Response.Write("<div class='contact-last-name'>" + allinvoices[i][6] + "</div>");
                    Response.Write("<div class='client-status'>" + allinvoices[i][7] + "</div>");
                    Response.Write("<a class='work-item-view' href='ViewStaffDetails.aspx?ID=" + allinvoices[i][0] + "'>View</a>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");
                Response.Write("<br/>");
                Response.Write("<br/>");
            }
        }
    }
}