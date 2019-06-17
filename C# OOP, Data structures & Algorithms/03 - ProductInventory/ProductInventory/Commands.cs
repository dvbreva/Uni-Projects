using System.Collections.Generic;

namespace ProductInventory
{
    class Commands
    {
        public const string ADDPRODUCT = "/AddProduct";
        public const string ADDSTOCK = "/AddStock";
        public const string GETPRODUCT_TOTAL = "/GetProductTotal";
        public const string GETINVENTORY_TOTAL = "/GetInventoryTotal";

        public static IEnumerable<string> AvailableCommands = new List<string>()
        {
            ADDPRODUCT,
            ADDSTOCK,
            GETPRODUCT_TOTAL,
            GETINVENTORY_TOTAL,   
        };
    }
}
