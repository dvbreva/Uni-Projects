using ProductInventory.Data;
using System;

namespace ProductInventory
{
    class Program
    {
        private static Inventory inventory = Inventory.Instance;

        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine(" ");
                PrintInfo(); 

                Console.WriteLine(". . . . . . . . . . . . .  ");
                Console.WriteLine("// MR R O B O T Fan Store");

                Console.Write(DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));
                Console.WriteLine("<mr.robot>: Hello _friend. If you've come, you've come for a reason.\n" +
                    "You have successfully launched my Mr.Robot themed fan store.\n" +
                    "You can choose between 4 products and 4 commands. \n");
             

                Console.WriteLine("Available Commands:");
                foreach(var comm in Commands.AvailableCommands)
                {
                    Console.Write( $"{comm}\n");
                }

                
                Console.WriteLine("\nPlease enter a command: ");
                string command = Console.ReadLine();

                switch(command)
                {
                    case Commands.ADDPRODUCT:
                        AddProduct();
                        break;
                    case Commands.ADDSTOCK:
                        AddStock();
                        break;
                    case Commands.GETPRODUCT_TOTAL:
                        GetProductTotalUI();
                        break;
                    case Commands.GETINVENTORY_TOTAL:
                        GetInventoryTotal();
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
        }

        public static void AddProduct() 
        {
            string[] types = new string[] { "Shirt", "DVD", "Accessories", "Art Prints" };

          
            Console.Write("\n// Available products: ");
            foreach (var type in types)
            {
               
                Console.Write($"{type} , ");
                
            }

           
            Console.WriteLine("\nProduct type: ");
            string productType = Console.ReadLine();

            
            Console.Write("Name: ");
            string name = Console.ReadLine();

           
            Console.Write("Price: ");
            double.TryParse(Console.ReadLine(), out double price);

           
            Console.Write("Quantity: ");
            int.TryParse(Console.ReadLine(), out int quantity);

            Product product = null;

            switch (productType)
            {
                case "Shirt":
                    product = new Shirt(name, price, quantity);
                    break;
                case "DVD":
                    product = new DVDs(name, price, quantity);
                    break;
                case "Art Prints":
                    product = new ArtPrints(name, price, quantity);
                    break;
                case "Accessories":
                    product = new Accessories(name, price, quantity);
                    break;
                default:
                    break;
            };
            
            if (product==null)
            {
                Console.WriteLine("Unsupported type!");
            }
            else
            {
                inventory.AddProduct(product);
            }

        }

        private static void AddStock()
        {
            Console.WriteLine("Enter product id: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Enter quantity:");
            int.TryParse(Console.ReadLine(), out int quantity);

            Console.WriteLine($"Updated quantity: { inventory.AddQuantity(id, quantity)}");
        }

        public static void GetProductTotalUI()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Enter product id: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine($"The total amount of the product with id={id} you've chosen is: { inventory.GetProductTotal(id)}$");
            Console.ReadKey();
        }

        public static void GetInventoryTotal()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Total amount of the inventory: {inventory.GetInventoryTotal()}$");
            Console.ReadKey();
        }

        private static void PrintInfo()
        {
            if (inventory.Merchandise.Count == 0)
            {
                Console.WriteLine("You have added no products to the inventory yet!");
            }
            else
            {
                foreach (var product in inventory.Merchandise)
                {
                    Console.WriteLine($"Id: {product.Id},  Type: {product.GetType().Name},  Name: {product.Name},  Price: {product.Price}$,  Quantity: {product.Quantity}");
                }
            }
        }
    }
}
