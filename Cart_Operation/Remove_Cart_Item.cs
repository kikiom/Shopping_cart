using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    public class Remove_Cart_Item : IOperation
    {
        private string _name = "remove_cart_item";

        public void Bat(Data data, string args)
        {
            List<CartStruct> cart_items = data.GetCarts();
            bool found_flag = false;
            bool parse_id_flag = false;
            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id_item    
            if (sub.Length == 1) 
            {
                int i = 0;
                int id_item = 0;
                if (int.TryParse(sub[0].Trim(), out int parsed_id))
                {
                    id_item = parsed_id;
                    parse_id_flag = true;
                }
                else
                {
                    Console.WriteLine("Parsing failed. The input is not a valid integer.");
                }
                if (parse_id_flag == true)
                {

                    List<CartStruct> new_cart_items = new List<CartStruct>();
                    if (cart_items.Count() > 0)
                    {
                        foreach (CartStruct item in cart_items)
                        {
                            if (item.GetId() != id_item)
                            {
                                new_cart_items.Add(new CartStruct(i, item.GetQuantity(), item.GetIdProduct()));
                                i++;
                                found_flag = true;
                            }
                        }
                        cart_items.Clear();
                        data.SetCarts(new_cart_items);

                    }
                    else
                    {
                        Console.WriteLine("No products in the cart");
                    }
                    if (found_flag == false)
                    {
                        Console.WriteLine("There is no item with this id");
                    }
                }
            }
            

        }

        public bool CheckType(string type)
        {
            switch (type)
            {
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
            return "remove_cart_item ( id_item )- removes a cart item";
        }
    }
}
