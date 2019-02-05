using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign06B.Common
{
    public class Client
    {
        public string ClientCode { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public decimal YTDSales { get; set; }
        public bool CreditHold { get; set; }
        public string Notes { get; set; }


        public Client() { }

        public Client(string clientCode, string companyName, string address1, string address2, string city, string province, string postalCode, decimal yTDSales, bool creditHold, string notes)
        {
            ClientCode = clientCode;
            CompanyName = companyName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            Province = province;
            PostalCode = postalCode;
            YTDSales = yTDSales;
            CreditHold = creditHold;
            Notes = notes;
        }

        public override string ToString()
        {
            return string.Format($"{CompanyName} {Address1} {Province}");
        }


    }
}
