﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class WorkItem
    {
        // Fields for the workitem object, linked to the database table of the same name
        public int WorkItem_ID { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }
        public int Client_ID { get; set; }
        public int Task_ID { get; set; }
        public int Staff_ID { get; set; }
        public string Comment { get; set; }

        // Used to give meaningful data about the database connection
        public string Message { get; set; }


        // Adding a new work item
        public string AddWorkItem(NameValueCollection NewWorkItemData)
        {
            this.Date = DateTime.ParseExact(NewWorkItemData["CtrlWorkItemDate"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.StartTime = NewWorkItemData["CtrlStartTime"];
            this.EndTime = NewWorkItemData["CtrlEndTime"];
            this.Status = NewWorkItemData["CtrlStatus"];
            this.Client_ID = Convert.ToInt32(NewWorkItemData["CtrlClientList"]);
            this.Task_ID = Convert.ToInt32(NewWorkItemData["CtrlTaskList"]);
            this.Staff_ID = Convert.ToInt32(NewWorkItemData["CtrlStaffList"]);
            this.Comment = NewWorkItemData["CtrlComment"];
            

            // Creating a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // Creating the SQL command to add data to the work item table
            SqlCommand AddWorkItem = new SqlCommand
            {
                // Add the actual SQL command and fields to be added into a table here
                CommandText = "INSERT WORKITEM (Date, StartTime, EndTime, Status, Client_ID, Task_ID, Staff_ID, Comment) " +
                "VALUES ('" + Date + "', '" + StartTime + "', '" + EndTime + "', '" + Status + "', '" + Client_ID + "', '" + Task_ID + "', '" + Staff_ID + "','" + Comment + "')",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Check to see if connection is active, defensive programming
            if (connection.State == ConnectionState.Open)
            {
                // Execute the insert query and get a value to see if the query succeeded
                int connectionCheck = AddWorkItem.ExecuteNonQuery();

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

        // This method lists all workitems
        public List<List<string>> GetWorkItem()
        {
            // Create a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command to retrive all workitems from the WORKITEM database table
            SqlCommand GetAllWorkItems = new SqlCommand
            {
                CommandText = "SELECT * FROM WORKITEM",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Create a multi dimensional list that will hold all of the data from the query
            List<List<string>> AllWorkItems = new List<List<string>>();

            // Read all results from the database
            SqlDataReader reader = GetAllWorkItems.ExecuteReader();

            // Check that results are not null, if so then do
            if (reader.HasRows)
            {
                // Loop over results and read
                while (reader.Read())
                {
                    // Add each line to a single dimensional list that contains the result data
                    AllWorkItems.Add(new List<string> {reader["WorkItem_ID"].ToString(), reader["Date"].ToString(),
                        reader["StartTime"].ToString(), reader["EndTime"].ToString(), reader["Status"].ToString(),
                        reader["Client_ID"].ToString(), reader["Task_ID"].ToString(), reader["Staff_ID"].ToString(),
                        reader["Comment"].ToString() });
                }
                // Close the reader to prevent any errors
                reader.Close();
            }
            else
            {
                // If no results then set return value to null
                AllWorkItems = null;
            }

            // Close datbase connection
            DBConnect.DropConnection(connection);

            // Return the data read from the database
            return AllWorkItems;

        }
    }
}