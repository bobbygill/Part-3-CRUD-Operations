using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using COMP2614Assign06B.Common;

namespace COMP2614Assign06B.Data
{
    class ClientRepository
    {

        private static string connString = @"Server = tcp:skeena.database.windows.net,1433;
                                            Initial Catalog = comp2614;
                                            User ID = student;
                                            Password=93nu5#Z183;
                                            Encrypt = True;
                                            TrustServerCertificate=False;
                                            Connection Timeout = 30;";

        public static ClientCollection GetAllClients()
        {
            ClientCollection clients;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query;


                query = @"SELECT ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes
                               FROM Client913705
                               ORDER BY CompanyName";



                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    clients = new ClientCollection();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string clientCode; // not null 0
                        string companyName; // not null 1
                        string address1; // not null 2
                        string address2 = null; //null 3
                        string city = null; //null 4
                        string province; // not null 5
                        string postalCode = null; //null 6
                        decimal ytdSales; //not null 7 
                        bool creditHold; //not null 
                        string notes = null; //null 9

                        while (reader.Read())
                        {
                            clientCode = reader["ClientCode"] as string; // 0
                            companyName = reader["CompanyName"] as string; // 1
                            address1 = reader["Address1"] as string; // 2


                            if (!reader.IsDBNull(3))
                            {
                                address2 = reader["Address2"] as string;
                            }
                            if (!reader.IsDBNull(4))
                            {
                                city = reader["City"] as string;
                            }

                            province = reader["Province"] as string; //5 


                            if (!reader.IsDBNull(6))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }

                            ytdSales = (decimal)reader["YTDSales"]; //7

                            creditHold = (bool)reader["CreditHold"]; //8

                            if (!reader.IsDBNull(9))
                            {
                                notes = reader["Notes"] as string;
                            }


                            clients.Add(new Client(clientCode, companyName, address1, address2, city, province, postalCode, ytdSales, creditHold, notes));

                            //clientCode = null;
                            //companyName = null;
                            //address1 = null;
                            //province = null;
                            //ytdSales = 0;
                            //creditHold = false;
                        }
                    }

                    return clients;

                }
            }
        }

        public static int AddClient(Client client)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //I removed Clientcode from the front??
                string query = @"INSERT INTO Client913705
                                 (ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes)
                                 VALUES (@clientCode, @companyName, @address1, @address2, @city, @province, @postalCode, @ytdSales, @creditHold, @notes)";


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@clientCode", client.ClientCode);
                    cmd.Parameters.AddWithValue("@companyName", client.CompanyName);
                    cmd.Parameters.AddWithValue("@address1", client.Address1);

                    if (client.Address2 != null)
                    {
                        cmd.Parameters.AddWithValue("@address2", client.Address2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address2", DBNull.Value);
                    }

                    if (client.City != null)
                    {
                        cmd.Parameters.AddWithValue("@city", client.City);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }



                    cmd.Parameters.AddWithValue("@province", client.Province);


                    if (client.PostalCode != null)
                    {
                        cmd.Parameters.AddWithValue("@postalCode", client.PostalCode);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@postalCode", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@ytdSales", client.YTDSales);
                    cmd.Parameters.AddWithValue("@creditHold", client.CreditHold);


                    if (client.Notes != null)
                    {
                        cmd.Parameters.AddWithValue("@notes", client.Notes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
                    }

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }


        public static int DeleteClient(Client client)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"DELETE Client913705
                                 WHERE ClientCode = @clientCode";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@clientCode", client.ClientCode);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }


        public static int UpdateClient(Client client)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"UPDATE Client913705
                                 SET CompanyName = @companyName
                                 , Address1 = @address1
                                 , Address2 = @address2
                                 , City = @city
                                 , Province = @province
                                 , PostalCode = @postalCode
                                 , YTDSales = @ytdSales
                                 , CreditHold = @creditHold
                                 , Notes = @notes
                                 WHERE ClientCode = @clientCode";


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@companyName", client.CompanyName);
                    cmd.Parameters.AddWithValue("@address1", client.Address1);

                    if (client.Address2 != null)
                    {
                        cmd.Parameters.AddWithValue("@address2", client.Address2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address2", DBNull.Value);
                    }

                    if (client.City != null)
                    {
                        cmd.Parameters.AddWithValue("@city", client.City);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }



                    cmd.Parameters.AddWithValue("@province", client.Province);


                    if (client.PostalCode != null)
                    {
                        cmd.Parameters.AddWithValue("@postalCode", client.PostalCode);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@postalCode", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@ytdSales", client.YTDSales);
                    cmd.Parameters.AddWithValue("@creditHold", client.CreditHold);


                    if (client.Notes != null)
                    {
                        cmd.Parameters.AddWithValue("@notes", client.Notes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@clientCode", client.ClientCode);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
