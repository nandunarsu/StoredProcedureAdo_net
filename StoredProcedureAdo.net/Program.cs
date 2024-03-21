using System.Data.SqlClient;
using System.Data;
using System;
using System.Xml.Serialization;
//using System.Security.Cryptography.X509Certificates;
namespace StoredProcedureAdo.net

{
    class Program

    {
       public static string connection = "server=DESKTOP-8Q6KN97\\SQLEXPRESS; Initial Catalog = storedprocedure;Integrated Security =SSPI";
      public static SqlConnection conn  = new SqlConnection(connection);
        private static int choice;

        public static void Insert()
        {
            //Console.WriteLine("Enter ID");
            //int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Address");
            string Address  = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("InsertvaluesSP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NAME", name);
            cmd.Parameters.AddWithValue("@AGE",age );
            cmd.Parameters.AddWithValue("@ADDRESS", Address);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Display()
        {
            SqlCommand cmd = new SqlCommand("DisplaySP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while( dataReader.Read())
            {
                Console.Write("Id:" + dataReader.GetValue(0) + " ");
                Console.Write("NAME:" + dataReader.GetValue(1) + " ");
                Console.Write("AGE:" + dataReader.GetValue(2) + " ");
                Console.Write("ADDRESS:" + dataReader.GetValue(3) + " ");
                Console.WriteLine();
            }
        }
        public static void Delete()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("DeletevaluesSP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NAME", name);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static void Update()
        {
            Console.WriteLine("Enter the employee id");
            int empid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Address");
            string Address = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("UpdatevaluesSP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@NAME", name);
            cmd.Parameters.AddWithValue("@AGE", age);
            cmd.Parameters.AddWithValue("@ADDRESS", Address);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void create()
        {
            SqlCommand cmd = new SqlCommand("CreateStudentSP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();   

        }
        static void Main()
        {

            do
            {
                Console.WriteLine("Enter your choice\n 1.Create\n 2.Insertion \n 3.Deletion\n 4.Update\n 5.Display \n6.Exit ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        create();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Display();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            } while (choice <= 6);
        }
    }
}

