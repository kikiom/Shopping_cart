using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class Remove_Cart_Item : IOperation
    {
        private string _name = "remove_cart_item";

        public void Bat(Data data, string args)
        {
            List<CartStruct> cart_items = data.GetCarts();

            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id_item    
            int i = 0;
            int id_item = int.Parse(sub[0].Trim());

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
            data.SetCarts(new_cart_items);

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
