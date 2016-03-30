using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopEF
{
    public partial class Book
    {
        public string DisplayName
        {
            get { return this.name + " by " + this.author; }
        }
    }
    public partial class Customer
    {
        public int OrdersCount
        {
            get
            {
                return this.Orders.Count;
            }
        }
    }
}