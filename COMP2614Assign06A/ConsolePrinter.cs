using COMP2614Assign06B.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign06B
{

    //Print to console to test if the database is working

    class ConsolePrinter
    {

        public static void PrintClientCollection(ClientCollection clients)
        {
            string divider = new string('-', 70);
            Console.WriteLine($"{"CompanyName",-35} {"City",-16} {"Prov",-4} {"Postal",-7} {"Hold",1}\n{divider}");

            foreach (Client client in clients)
            {
                PrintClient(client);
            }
        }

        public static void PrintClient(Client client)
        {
            Console.WriteLine($"{client.CompanyName,-35} {client.City,-16} {client.Province,-4} {client.PostalCode,-7}  {(client.CreditHold ? "Y" : "N"),1}");

        }


    }
}
