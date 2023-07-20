using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Product_Operation
{
    internal class Search_Product : IOperation
    {
        private string _name = "search_product";
        public string GetName() 
        { 
            return _name;
        }
        public void Bat(Data data, string args) 
        {
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
                }
            }
            else 
            {
                Console.WriteLine("No products"); 
            }
            
        }
        public string print()
        {
            return "search_product - searching for a product";
        }

    }
}
