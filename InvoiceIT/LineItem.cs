using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class LineItem
    {
        // Fields for the lineitem object, linked to the database table of the same name
        public int LineItem_ID { get; set; }
        public int InvoiceNumber { get; set; }
        public int WorkItem_ID { get; set; }

        // Used to give meaningful data about the database connection
        public string Message { get; set; }


        // Adding a new line item
        public string AddLineItem(NameValueCollection NewLineItemData)
        {
            this.InvoiceNumber = Convert.ToInt32(NewLineItemData["CtrlInvoiceList"]);
            this.WorkItem_ID = Convert.ToInt32(NewLineItemData["CtrlWorkItemList"]);


            // Creating a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // Creating the SQL command to add data to the work item table
            SqlCommand AddLineItem = new SqlCommand
            {
                // Add the actual SQL command and fields to be added into a table here
                CommandText = "INSERT LINEITEM (InvoiceNumber, WorkItem_ID) " +
                "VALUES ('" + InvoiceNumber + "', '" + WorkItem_ID + "')",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Check to see if connection is active, defensive programming
            if (connection.State == ConnectionState.Open)
            {
                // Execute the insert query and get a value to see if the query succeeded
                int connectionCheck = AddLineItem.ExecuteNonQuery();

                // Check to see if the above query succeeded or not. Give appropriate message
                if (connectionCheck == 0)
                {
                    this.Message = "Query has failed";
                }
                else
                {
                    this.Message = "Query has succeeded!";
                }
            }
            else
            {
                // Send failure message if there is an error
                this.Message = "SQL DB connection failed";
            }

            // Remove the current database connection and cleanup data
            DBConnect.DropConnection(connection);

            // Returning the message string to caller
            return Message;
        }

        // This method lists all line items
        public List<List<string>> GetLineItem()
        {
            // Create a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command to retrive all workitems from the LINEITEM database table
            SqlCommand GetAllLineItems = new SqlCommand
            {
                CommandText = "SELECT * FROM LINEITEM",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Create a multi dimensional list that will hold all of the data from the query
            List<List<string>> AllLineItems = new List<List<string>>();

            // Read all results from the database
            SqlDataReader reader = GetAllLineItems.ExecuteReader();

            // Check that results are not null, if so then do
            if (reader.HasRows)
            {
                // Loop over results and read
                while (reader.Read())
                {
                    // Add each line to a single dimensional list that contains the result data
                    AllLineItems.Add(new List<string> {reader["LineItem_ID"].ToString(), reader["InvoiceNumber"].ToString(),
                        reader["WorkItem_ID"].ToString()});
                }
                // Close the reader to prevent any errors
                reader.Close();
            }
            else
            {
                // If no results then set return value to null
                AllLineItems = null;
            }

            // Close datbase connection
            DBConnect.DropConnection(connection);

            // Return the data read from the database
            return AllLineItems;

        }
    }
}