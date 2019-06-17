using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Data
{
    public class DVDs : Product
    {
        public DVDs(string name, double price, int quantity)
            : base(name, price)  { }
    }
}
