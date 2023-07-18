using System;
using System.Collections.Generic;

namespace Shopping_cart.Product_Operation
{
    internal class Remove_Prouduct : IOperation
    {
        string _name = "remove_product";
        public void Bat(Data data, string args)
        {
            List<ProductStruct> products = data.GetProducts();
            int i = 0, index =0;
            foreach (ProductStruct product in products)
            {
                
                if (product.GetId() == int.Parse(args.Trim()))
                {
                    index = i;
                }
                i++;
            }
            if(!(index == 0 && i == products.Count)) 
            {
                products.RemoveAt(index);
            }
            
            Save_Prouduct save = new Save_Prouduct();
            save.ExportToTextFile(products);
            data.SetProducts(products);
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "remove_product - removes a product";
        }
    }
}
