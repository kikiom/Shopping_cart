using System;
using System.Collections.Generic;

namespace Shopping_cart.Product_Operation
{
    internal class Remove_Prouduct : IOperation, IPruductOperation
    {
        string _name = "remove_product";
        public void Bat(ref List<ProductStruct> list, string data)
        {
            int i = 0, index =0;
            foreach (ProductStruct product in list)
            {
                
                if (product.GetId() == int.Parse(data))
                {
                    index = i;
                }
                i++;
            }
            if(!(index == 0 && i == list.Count)) 
            {
                list.RemoveAt(index);
            }
            
            Save_Prouduct save = new Save_Prouduct();
            save.ExportToTextFile(list);
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
