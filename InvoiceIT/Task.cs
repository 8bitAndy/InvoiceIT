using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Task
    {
        // Fields for the Task object, linked to the database table of the same name
        public int Task_ID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskRate { get; set; }

        // Used to give meaningful data about the database connection
        public string Message { get; set; }


        // Adding a new staff member
        public string AddTask(NameValueCollection NewTaskData)
        {
            this.TaskTitle = NewTaskData["CtrlTaskTitle"];
            this.TaskDescription = NewTaskData["CtrlTaskDescription"];
            this.TaskRate = NewTaskData["CtrlTaskRate"];

            // Creating a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // Creating the SQL command to add data to the task table
            SqlCommand AddTask = new SqlCommand
            {
                // Add the actual SQL command and fields to be added into a table here
                CommandText = "INSERT TASK (TaskTitle, TaskDescription, TaskRate) VALUES ('" +
                TaskTitle + "', '" + TaskDescription + "', '" + TaskRate + "')",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Check to see if connection is active, defensive programming
            if (connection.State == ConnectionState.Open)
            {
                // Execute the insert query and get a value to see if the query succeeded
                int connectionCheck = AddTask.ExecuteNonQuery();

                // Check to see if the above query succeeded or not. Give appropriate message
                if (connectionCheck == 0)
                {
                    this.Message = "Task was not added, an error occured";
                }
                else
                {
                    this.Message = "Task successfully added";
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

        // This method lists all tasks
        public List<List<string>> GetTask()
        {
            // Create a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command to retrive all staff from the TASK database table
            SqlCommand GetAllTasks = new SqlCommand
            {
                CommandText = "SELECT * FROM TASK",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Create a multi dimensional list that will hold all of the data from the query
            List<List<string>> AllTasks = new List<List<string>>();

            // Read all results from the database
            SqlDataReader reader = GetAllTasks.ExecuteReader();

            // Check that results are not null, if so then do
            if (reader.HasRows)
            {
                // Loop over results and read
                while (reader.Read())
                {
                    // Add each line to a single dimensional list that contains the result data
                    AllTasks.Add(new List<string> {reader["Task_ID"].ToString(), reader["TaskTitle"].ToString(),
                        reader["TaskDescription"].ToString(), reader["TaskRate"].ToString()
                    });
                }
                // Close the reader to prevent any errors
                reader.Close();
            }
            else
            {
                // If no results then set return value to null
                AllTasks = null;
            }

            // Close datbase connection
            DBConnect.DropConnection(connection);

            // Return the data read from the database
            return AllTasks;

        }
    }
}