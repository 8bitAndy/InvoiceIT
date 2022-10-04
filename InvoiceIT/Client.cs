using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Client
    {
        // Fields for the Client object, linked to the database table of the same name
        public int Client_ID { get; set; }
        public string CompName { get; set; }
        public string CompAdd1 { get; set; }
        public string CompAdd2 { get; set; }
        public string CompLocation { get; set; }
        public string CompPcode { get; set; }
        public string ContactFname { get; set; }
        public string ContactLname { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMobile { get; set; }
        public string BillTo { get; set; }
        public string Status { get; set; }

        // Used to give meaningful data about the database connection
        public string Message { get; set; }


        // Adding a new staff member
        public string AddClient(NameValueCollection NewClientData)
        {
            this.CompName = NewClientData["CtrlCompName"];
            this.CompAdd1 = NewClientData["CtrlAddress1"];
            this.CompAdd2 = NewClientData["CtrlAddress2"];
            this.CompLocation = NewClientData["CtrlLocation"];
            this.CompPcode = NewClientData["CtrlPostcode"];
            this.ContactFname = NewClientData["CtrlContactFirstName"];
            this.ContactLname = NewClientData["CtrlContactLastName"];
            this.ContactEmail = NewClientData["CtrlContactEmail"];
            this.ContactMobile = NewClientData["CtrlContactMobile"];
            this.BillTo = NewClientData["CtrlBillToDropList"];
            this.Status = NewClientData["CtrlStatus"];

            // Creating a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // Creating the SQL command to add data to the client table
            SqlCommand AddClient = new SqlCommand
            {
                // Add the actual SQL command and fields to be added into a table here
                CommandText = "INSERT CLIENT (CompName, CompAdd1, CompAdd2, CompLocation, CompPcode, " +
                "ContactFname, ContactLname, ContactEmail, ContactMobile, BillTo, Status) VALUES ('" + 
                CompName + "', '" + CompAdd1 + "', '" + CompAdd2 + "', '" + CompLocation + "', '" + CompPcode + 
                "', '" + ContactFname + "', '" + ContactLname + "','" + ContactEmail + "', '" + 
                ContactMobile + "', '" + BillTo + "','" + Status + "')",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Check to see if connection is active, defensive programming
            if (connection.State == ConnectionState.Open)
            {
                // Execute the insert query and get a value to see if the query succeeded
                int connectionCheck = AddClient.ExecuteNonQuery();

                // Check to see if the above query succeeded or not. Give appropriate message
                if (connectionCheck == 0)
                {
                    this.Message = "Client was not added, an error occured";
                }
                else
                {
                    this.Message = "Client successfully added";
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

        // This method lists all clients
        public List<List<string>> GetClient()
        {
            // Create a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command to retrive all staff from the CLIENT database table
            SqlCommand GetAllClients = new SqlCommand
            {
                CommandText = "SELECT * FROM CLIENT",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Create a multi dimensional list that will hold all of the data from the query
            List<List<string>> AllClients = new List<List<string>>();

            // Read all results from the database
            SqlDataReader reader = GetAllClients.ExecuteReader();

            // Check that results are not null, if so then do
            if (reader.HasRows)
            {
                // Loop over results and read
                while (reader.Read())
                {
                    // Add each line to a single dimensional list that contains the result data
                    AllClients.Add(new List<string> {reader["Client_ID"].ToString(), reader["CompName"].ToString(),
                        reader["CompAdd1"].ToString(), reader["CompAdd2"].ToString(), reader["CompLocation"].ToString(),
                        reader["CompPcode"].ToString(), reader["ContactFname"].ToString(), reader["ContactLname"].ToString(),
                        reader["ContactEmail"].ToString(), reader["ContactMobile"].ToString(), reader["BillTo"].ToString(),
                        reader["Status"].ToString()
                    });
                }
                // Close the reader to prevent any errors
                reader.Close();
            }
            else
            {
                // If no results then set return value to null
                AllClients = null;
            }

            // Close datbase connection
            DBConnect.DropConnection(connection);

            // Return the data read from the database
            return AllClients;

        }
    }
}