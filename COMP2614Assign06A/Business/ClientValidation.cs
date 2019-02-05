using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP2614Assign06B.Common;
using COMP2614Assign06B.Data;

namespace COMP2614Assign06A.Business
{
    class ClientValidation
    {
        private static List<string> errors;

        static ClientValidation()
        {
            errors = new List<string>();
        }

        public static string ErrorMessage
        {
            get
            {
                string message = "";

                foreach (string line in errors)
                {
                    message += line + "\r\n";
                }

                return message;
            }
        }

        public static ClientCollection GetAllClients() => ClientRepository.GetAllClients();

        public static int AddClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.AddClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int UpdateClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.UpdateClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int DeleteClient(Client client) => ClientRepository.DeleteClient(client);


        private static bool validate(Client client)
        {
            bool success = true;
            errors.Clear();

            if (string.IsNullOrEmpty(client.ClientCode))
            {
                errors.Add("Client Code cannot be empty");
                success = false;
            }

            if (string.IsNullOrEmpty(client.CompanyName))
            {
                errors.Add("Company Name cannot be empty");
                success = false;
            }

            if (string.IsNullOrEmpty(client.Address1))
            {
                errors.Add("Address1 cannot be empty");
                success = false;
            }

            if (string.IsNullOrEmpty(client.Province))
            {
                errors.Add("Province cannot be empty");
                success = false;
            }


            if (client.YTDSales < 0)
            {
                errors.Add("YTDSales cannot be negative");
                success = false;
            }

            return success;
        }
    }
}
