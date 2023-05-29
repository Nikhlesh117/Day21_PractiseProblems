using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Contact contact = new Contact()
            {
                FirstName = "Sara",
                LastName = "siri",
                Address = "abc",
                City = "VSKP",
                State = "AP",
                PostalCode = 12354,
                Phone = 8888844444,
                Email = "NK.R@gamil.com"
            };
            Contact con = new Contact()
            {
                FirstName = "NK",
                LastName = "siri",
            };

            AddressBook book = new AddressBook();
            book.AddDataInbase(contact);
            book.GetAllData();


            book.GetUpdateData(con);
            book.GetDeleteData("Nk", "siri");
            Console.ReadLine();
     
        }
    }
}
