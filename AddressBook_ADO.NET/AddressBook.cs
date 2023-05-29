using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO.NET
{
    //ADO.Net : IT is established connection between application and data Source.
    //DataSource : It includes data Source like Sql server and XML
    //ADO.Net is used for CRUD operations
    public class AddressBook
    {
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = Address_Book; Integrated Security = True";
        public void AddDataInbase(Contact contact)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                sqlConnection.Open();
                //SPAddingData is Stored Procedure name
                SqlCommand sqlCommand = new SqlCommand("SPAddingData", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", contact.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", contact.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", contact.Address);
                sqlCommand.Parameters.AddWithValue("@City", contact.City);
                sqlCommand.Parameters.AddWithValue("@State", contact.State);
                sqlCommand.Parameters.AddWithValue("@PostalCode", contact.PostalCode);
                sqlCommand.Parameters.AddWithValue("@Phone", contact.Phone);
                sqlCommand.Parameters.AddWithValue("@Email", contact.Email);
                int result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if(result>= 1)
                {
                    Console.WriteLine("New Contact Added");
                }
                else
                {
                    Console.WriteLine("error while adding data");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error"+ex.Message);
            }

        }
        public void GetAllData()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                List<Contact> listOfContact = new List<Contact>();
                using(sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SPGetAllData", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Contact contact = new Contact(); 
                           // contact.ID = reader.GetInt32(0);
                            contact.FirstName =  reader.GetString(1);
                            contact.LastName = reader.GetString(2);
                            contact.Address = reader.GetString(3);
                            contact.City = reader.GetString(4);
                            contact.State = reader.GetString(5);
                            contact.PostalCode = reader.GetInt32(6);
                            contact.Phone = reader.GetInt64(7);
                            contact.Email = reader.GetString(8);
                            listOfContact.Add(contact); 

                        }
                        foreach(Contact contact in listOfContact)
                        {
                            Console.WriteLine(contact.FirstName+" "+ contact.LastName+" "+ contact.Address+" "+ contact.City+" "+ contact.State+" "+contact.PostalCode+" "+contact.Phone+" "+ contact.Email+" ");
                            //Console.WriteLine(contact.LastName);
                            //Console.WriteLine(contact.Address);
                            //Console.WriteLine(contact.City);
                            //Console.WriteLine(contact.State);
                            //Console.WriteLine(contact.PostalCode);
                            //Console.WriteLine(contact.Phone);
                            //Console.WriteLine(contact.Email);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Database have no data");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error"+ex.Message);
            }
        }
        public void GetUpdateData(Contact contact)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateData", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    int output = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (output >= 1)
                    {
                        Console.WriteLine("Updated Successfuly");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetDeleteData(string firstName, string lastName)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SPDeleteData", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    int output = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (output >= 1)
                    {
                        Console.WriteLine("Delete Successfuly");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
