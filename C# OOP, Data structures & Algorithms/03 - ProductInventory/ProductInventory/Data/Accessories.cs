using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Data
{
    public class Accessories : Product
    {
        public Accessories(string name, double price, int quantity)
            : base(name, price)  { }
    }
}
