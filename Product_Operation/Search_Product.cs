using Shopping_cart.Logger_Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Product_Operation
{
    public class Search_Product : IOperation
    {
        private string _name = "search_product";
        public string GetName() 
        { 
            return _name;
        }
        public void Bat(Data data, string args) 
        {
            Logger.Log(data, "debug", "Enter search_product");

            bool found_flag = false;
            List<ProductStruct> products = data.GetProducts();
            if(products != null)
            {
                foreach (ProductStruct product in products)
                {
                    if (product.GetName() == args.Trim())
                    {
                        Console.WriteLine("product " + data + " id is " + product.GetId());
                        found_flag = true;
                    }
                }
                if (found_flag == false)
                {
                    Console.WriteLine("Product is not found");
                    Logger.Log(data, "info", "Product is not found in search");

                }
            }
            else 
            {
                Console.WriteLine("No products");
                Logger.Log(data, "warn", "No products");
            }
            Logger.Log(data, "debug", "Exit search_product");

        }
        public string print()
        {
            return "search_product( name ) - searching for a product";
        }

        public bool CheckType(string type)
        {
            switch (type)
            {
                case "admin":
                    return true;

                case "client":
                    return true;

                default: return false;
            }
        }
    }
}
