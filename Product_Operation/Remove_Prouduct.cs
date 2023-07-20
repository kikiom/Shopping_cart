using System;
using System.Collections.Generic;

namespace Shopping_cart.Product_Operation
{
    internal class Remove_Prouduct : IOperation
    {
        string _name = "remove_product";
        public void Bat(Data data, string args)
        {
            bool found_flag=false;
            List<ProductStruct> products = data.GetProducts();
            int i = 0, index =0;
            
            if (products.Count > 0)
            {
                foreach (ProductStruct product in products)
                {

                    if (product.GetId() == int.Parse(args.Trim()))
                    {
                        index = i;
                        found_flag = true;
                    }
                    i++;
                }
                if (!(index == 0 && i == products.Count))
                {
                    products.RemoveAt(index);
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
            Save_Prouduct save = new Save_Prouduct();
            save.ExportToTextFile(products);
            data.SetProducts(products);
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

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "remove_product( id ) - removes a product";
        }
    }
}
