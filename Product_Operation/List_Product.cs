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
            List<ProductStruct> products = data.GetProducts();
            foreach (ProductStruct product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public string print()
        {
            return "list_products - shows all products";
        }
    }
}
