using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Product_Operation
{
    internal class Search_Product : IOperation ,IPruductOperation
    {
        private string _name = "search_product";
        public string GetName() 
        { 
            return _name;
        }
        public void Bat(ref List<ProductStruct> products, string data) 
        {
            foreach (ProductStruct product in products) 
            {
                if (product.GetName()==data.Trim())
                {
                    Console.WriteLine("product " + data + " id is " + product.GetId());
                }
            }
        }
        public string print()
        {
            return "search_product - searching for a product";
        }

    }
}
