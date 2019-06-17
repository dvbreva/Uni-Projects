using ProductInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductInventory
{
    public class Inventory
    {
        private static Inventory _instance;

        public static Inventory Instance
        {
            get
            {
                if (_instance == null) 
                {
                    _instance = new Inventory();
                }
                return _instance;
            }
        }

        
        public List<Product> Merchandise { get; private set; } 

        public Inventory() 
        {
            this.Merchandise = new List<Product>();
        }


        // method to add non-existing product to the inventory
        public void AddProduct(Product product)
        {
            if (this.Merchandise.Any(p =>
             { return p.Name == product.Name && p.GetType() != product.GetType();
             }))
            {
                Console.WriteLine($"The inventory already contains a product of Type {product.GetType().Name} called {product.Name}");
                Console.ReadKey();
            }
            else
            {
                this.Merchandise.Add(product);
                SaveChanges();
            }
        }


        // method to add stock to an existing product
        public int AddQuantity(int id, int quantity)
        {
            Product targetProduct = this.Merchandise.FirstOrDefault(p => p.Id == id); 
            if(targetProduct!=null)
            {
                targetProduct.Quantity += quantity;   
                return targetProduct.Quantity;
            }
            Console.WriteLine("Product with the requested id { id} does not exist. Please try again.");
            Console.ReadKey();
            return -1;
        }


        //method to get the total amount of a certain product
        public double GetProductTotal(int id)
        {
            double productTotal = 0.0;
            Product targetProduct = this.Merchandise.FirstOrDefault(p => p.Id == id); 
            if (targetProduct != null)
            {
                productTotal=targetProduct.Price*targetProduct.Quantity;  
                return productTotal;
            }
            Console.WriteLine("Product with the requested id {id} does not exist.Try again.");
            Console.ReadKey();
            return -1;
        }


        //method to get the total amount of the whole inventory
        public double GetInventoryTotal()
        {
            double total = 0;
            foreach(var product in Merchandise)
            {
                total += GetProductTotal(product.Id);
            }
            return total; 
        }


        private void SaveChanges()
        {
            foreach(var product in Merchandise.Where(p=> p.Id==0))
            {
                product.Id = Merchandise.Max(p => p.Id) + 1; 
            }
        }

    }
}
