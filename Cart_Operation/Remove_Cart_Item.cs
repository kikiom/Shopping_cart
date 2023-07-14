using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class Remove_Cart_Item : IOperation, ICartOperation
    {
        private string _name = "remove_cart_item";

        public void Bat(ref List<CartStruct> cart_items, List<ProductStruct> products, string data)
        {
            char[] separator = { ';' };
            string[] sub = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id_item    
            int i = 0;
            int id_item = int.Parse(sub[0]);
            List<CartStruct> new_cart_items = new List<CartStruct>();
            foreach (CartStruct item in cart_items) 
            {
                if(item.GetId() != id_item) 
                {
                    new_cart_items.Add(new CartStruct(i, item.GetQuantity(), item.GetIdProduct()));
                    i++;
                }
            }
            cart_items.Clear();
            cart_items = new_cart_items;
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "remove_cart_item - removes a cart item";
        }
    }
}
