using System;
using System.Data.SqlClient;

namespace Adonet
{
    class Program
    {
        private static string ConnectionString = @"Server=ELLA\SQLEXPRESS;Initial Catalog=ADONET;Integrated Security=SSPI";
        static void Main(string[] args)
        {
            //GetName();
            //CreateStudent();
            GetStudentsName();
        }

        public static void GetName()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string command = "SELECT Name FROM Students WHERE Id=1";
                using (SqlCommand com = new SqlCommand(command,connection))
                {
                    string name = com.ExecuteScalar().ToString();
                    Console.WriteLine(name);
                }
            }
        }
        public static void CreateStudent()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string command = "INSERT INTO Students VALUES('Elvin',28)";
                using (SqlCommand com = new SqlCommand(command, connection))
                {
                    int result = com.ExecuteNonQuery();
                    if (result>0)
                    {
                        Console.WriteLine("stu created");
                    }
                    else
                    {
                        Console.WriteLine("process failed");
                    }
                }
            }
        }
        public static void GetStudentsName()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string command = "SELECT Name FROM Students";
                using (SqlCommand com = new SqlCommand(command, connection))
                {
                    SqlDataReader result = com.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            Console.WriteLine(result.GetString(0));
                        }
                    }
                }
            }
        }
    }

}