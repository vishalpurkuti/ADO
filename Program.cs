using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=.;database=trippy;integrated security=SSPI");
            con.Open();
            var command = new SqlCommand();
            command.Connection = con;

           

           /* command.CommandText = "Create table saman(id int  primary key , name varchar(30)  )";
             command.ExecuteNonQuery(); */

            Console.WriteLine("Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            string name = Console.ReadLine();
            try { 
            command.CommandText = "Insert into saman values("+id+",'"+name+"')";
            command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Try Again");

            }
            finally{
                Console.WriteLine("Finished");
            }
            /*
            command.CommandText = "Select * from saman";
            SqlDataReader sdr = command.ExecuteReader();
            while (sdr.Read()) {
                Console.WriteLine(sdr["id"]+" " + sdr["name"]);
            }
            */

            SqlDataAdapter adp =new SqlDataAdapter( "Select * from saman",con);
            DataSet ds = new DataSet();
            adp.Fill(ds,"saman");
            con.Close();
            Console.WriteLine("ID   Name");
            foreach (DataRow row in ds.Tables["saman"].Rows) { 
                Console.WriteLine("{0} {1}", row[0], row[1]);
            }





        }
    }
}
