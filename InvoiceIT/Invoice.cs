using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Invoice
    {
        // Fields for the invoice object, linked to the database table of the same name
        public int InvoiceNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string InvoiceUpdateDate { get; set; }
        public string InvoiceSentDate { get; set; }
        public string PaymentDueDate { get; set; }
        public string StatusOfInvoice { get; set; }
        public int Client_ID { get; set; }

        // Used to give meaningful data about the database connection
        public string Message { get; set; }


        // Adding a invoice
        public string AddInvoice(NameValueCollection NewInvoiceData)
        {
            this.StartDate = DateTime.ParseExact(NewInvoiceData["CtrlInvoiceStartDate"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.EndDate = DateTime.ParseExact(NewInvoiceData["CtrlInvoiceEndDate"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.InvoiceUpdateDate = DateTime.ParseExact(NewInvoiceData["CtrlInvoiceChangeDate"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.InvoiceSentDate = DateTime.ParseExact(NewInvoiceData["CtrlInvoiceSentDate"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.PaymentDueDate = DateTime.ParseExact(NewInvoiceData["CtrlInvoicePaymentDueDate"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.StatusOfInvoice = NewInvoiceData["CtrlInvoiceStatus"];
            this.Client_ID = Convert.ToInt32(NewInvoiceData["CtrlClientList"]);

            // Creating a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // Creating the SQL command to add data to the task table
            SqlCommand AddInvoice = new SqlCommand
            {
                // Add the actual SQL command and fields to be added into a table here
                CommandText = "INSERT INVOICE (StartDate, EndDate, InvoiceUpdateDate, InvoiceSentDate, PaymentDueDate, StatusOfInvoice, Client_ID)" +
                " VALUES ('" + StartDate + "', '" + EndDate + "', '" + InvoiceUpdateDate + "','" + 
                InvoiceSentDate + "', '" + PaymentDueDate + "', '" + StatusOfInvoice + "', '" + Client_ID + "')",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Check to see if connection is active, defensive programming
            if (connection.State == ConnectionState.Open)
            {
                // Execute the insert query and get a value to see if the query succeeded
                int connectionCheck = AddInvoice.ExecuteNonQuery();

                // Check to see if the above query succeeded or not. Give appropriate message
                if (connectionCheck == 0)
                {
                    this.Message = "Invoice was not created, an error occured";
                }
                else
                {
                    this.Message = "Invoice successfully generated";
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

        // This method lists all invoices
        public List<List<string>> GetInvoice()
        {
            // Create a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command to retrive all invoices from the INVOICE database table
            SqlCommand GetAllInvoices = new SqlCommand
            {
                CommandText = "SELECT * FROM INVOICE",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Create a multi dimensional list that will hold all of the data from the query
            List<List<string>> AllInvoices = new List<List<string>>();

            // Read all results from the database
            SqlDataReader reader = GetAllInvoices.ExecuteReader();

            // Check that results are not null, if so then do
            if (reader.HasRows)
            {
                // Loop over results and read
                while (reader.Read())
                {
                    // Add each line to a single dimensional list that contains the result data
                    AllInvoices.Add(new List<string> {reader["InvoiceNumber"].ToString(), reader["StartDate"].ToString(),
                        reader["EndDate"].ToString(), reader["InvoiceUpdateDate"].ToString(), reader["InvoiceSentDate"].ToString()
                        , reader["PaymentDueDate"].ToString(), reader["StatusOfInvoice"].ToString(), reader["Client_ID"].ToString()
                    });
                }
                // Close the reader to prevent any errors
                reader.Close();
            }
            else
            {
                // If no results then set return value to null
                AllInvoices = null;
            }

            // Close datbase connection
            DBConnect.DropConnection(connection);

            // Return the data read from the database
            return AllInvoices;

        }
    }
}