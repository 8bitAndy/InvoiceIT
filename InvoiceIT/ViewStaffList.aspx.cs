using System;
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
                Response.Write("<p> There are " +results + " staff members in total <p>");

                // Display results for each invidiual staff member
                Response.Write("<div class='staff-listing-container'");



                // Create each staff members display of details within the web form
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div>" + allstaff[i][0] + "</div>");
                    Response.Write("<div>" + allstaff[i][1] + "</div>");
                    Response.Write("<div>" + allstaff[i][2] + "</div>");
                    Response.Write("<div>" + allstaff[i][3] + "</div>");
                    Response.Write("<div>" + allstaff[i][4] + "</div>");
                    Response.Write("<div>" + allstaff[i][5] + "</div>");
                    Response.Write("<div>" + allstaff[i][6] + "</div>");
                    Response.Write("<div>" + allstaff[i][7] + "</div>");
                    Response.Write("<div>" + allstaff[i][8] + "</div>");

                    Response.Write("<a href='ViewStaffDetails.aspx?ID=" + allstaff[i][0] + "'>View</a>");


                    /*
                    Response.Write("<div class='staff-listing-row'");
                    Response.Write("<div class='staff-id'" + allstaff[i][0] + "</div>");
                    Response.Write("<div class='staff-first-name'" + allstaff[i][1] + "</div>");
                    Response.Write("<div class='staff-surname'" + allstaff[i][2] + "</div>");
                    Response.Write("<div class='staff-email'" + allstaff[i][3] + "</div>");
                    Response.Write("<div class='staff-mobile'" + allstaff[i][4] + "</div>");
                    Response.Write("<div class='staff-accessLevel'" + allstaff[i][5] + "</div>");
                    Response.Write("<div class='staff-status'" + allstaff[i][6] + "</div>");
                    Response.Write("<div class='staff-username'" + allstaff[i][7] + "</div>");
                    Response.Write("<div class='staff-password'" + allstaff[i][8] + "</div>");

                    Response.Write("<div class='staff-view-details'><a href='ViewStaffDetails.aspx?ID=" +
                        allstaff[i][0] + "'>View</a></div>");
                     */


                }
            }
        }
    }
}