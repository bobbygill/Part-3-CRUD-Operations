using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign06B.Common
{
    public class ClientCollection : BindingList<Client>
    {
        //will use these later

        public decimal TotalYTDSales => this.Sum(x => x.YTDSales);

        public int CreditHoldCount => this.Count(x => x.CreditHold);


    }
}
