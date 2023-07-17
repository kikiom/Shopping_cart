using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class Update_Cart_Item : IOperation, ICartOperation
    {
        private string _name = "update_cart_item";
        public void Bat(ref List<CartStruct> cart_items, List<ProductStruct> products, string data)
        {
            char[] separator = { ';' };
            string[] sub = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id_item    sub1 = id_product    sub2 = quantity 
            int id_item = int.Parse(sub[0].Trim());
            int id_product = int.Parse(sub[1].Trim());
            int quantity = int.Parse(sub[2].Trim());
            ProductStruct product = new ProductStruct();
            foreach (ProductStruct item in products)
            {
                if (item.GetId() == id_product)
                {
                    product = item;
                }
            }
            foreach (CartStruct item in cart_items) 
            {
                if(item.GetId() == id_item) 
                {
                    if (product.GetQuantity() >= quantity)
                    {
                        item.SetQuantity(quantity);
                    }
                    else
                    {
                        Console.WriteLine("not enough quantity");
                    }
                }
            }
            
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "update_cart_item - updates the quantity of the item";
        }
    }
}
