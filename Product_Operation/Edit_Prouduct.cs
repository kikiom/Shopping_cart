using System;
using System.Collections.Generic;

namespace Shopping_cart.Product_Operation
{
    internal class Edit_Prouduct : IOperation, IPruductOperation
    {
        private string _name = "edit_product";
        public string GetName()
        {
            return _name;
        }
        public void Bat(ref List<ProductStruct> products, string data)
        {
            char[] separator = { ';' };
            string[] sub = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id     sub1 = name     sub2 = price    sub3 = quantity     sub4 = description
            int id = int.Parse(sub[0]);
            foreach (ProductStruct product in products)
            {
                if (product.GetId() == id)
                {
                    product.SetName(sub[1]);
                    product.SetPrice(double.Parse(sub[2]));
                    product.SetQuantity(int.Parse(sub[3]));
                    product.SetDescription(sub[4]);
                }
            }
            Save_Prouduct save = new Save_Prouduct();
            save.ExportToTextFile(products);
        }
        public string print()
        {
            return "edit_product - eidt the specified product";
        }

    }
}
