using Shopping_cart.Logger_Operations;
using System;
using System.Collections.Generic;

namespace Shopping_cart.Product_Operation
{
    internal class List_Product : IOperation
    {
        private string _name = "list_products";
        public string GetName()
        {
            return _name;
        }
        public void Bat(Data data, string args)
        {
            Logger.Log(data, "debug", "Enter list_product");

            List<ProductStruct> products = data.GetProducts();
            if(products != null ) 
            {
                foreach (ProductStruct product in products)
                {
                    Console.WriteLine(product.ToString());
                }
            }
            else
            {
                Console.WriteLine("No products");
                Logger.Log(data, "warn", "No product");

            }
            Logger.Log(data, "debug", "Exit list_product");

        }

        public string print()
        {
            return "list_products() - shows all products";
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
