using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Data
{
    public class ArtPrints : Product
    {
        public ArtPrints(string name, double price, int quantity)
            : base(name, price)  { }
    }
}
