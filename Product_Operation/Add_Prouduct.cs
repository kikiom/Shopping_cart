using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Product_Operation
{
    internal class Add_Prouduct : IOperation , IPruductOperation
    {
        private string _name = "add_product";
        public string GetName()
        {
            return _name;
        }
        
        public string print()
        {
            return "add_product - adds a new product";
        }

        public void Bat(ref List<ProductStruct> products, string data)
        {
            char[] separator = { ';' };
            string[] sub = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = name     sub1 = price    sub2 = quantity     sub3 = description
            int id;
            if (products.Count > 0)
            {
                id = products.Last().GetId() + 1;
            }
            else
            {
                id = 0;
            }
            ProductStruct product = new ProductStruct(id, int.Parse(sub[2]), double.Parse(sub[1]), sub[0], sub[3]);
            products.Add(product);
            Save_Prouduct save = new Save_Prouduct();
            save.ExportToTextFile(products);
        }
    }
}
