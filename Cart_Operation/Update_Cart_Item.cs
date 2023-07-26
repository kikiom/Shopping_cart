using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    public class Update_Cart_Item : IOperation
    {
        private string _name = "update_cart_item";
        public void Bat(Data data, string args)
        {
            List<CartStruct> cart_items = data.GetCarts(); 
            List< ProductStruct > products = data.GetProducts();

            bool found_flag = false;
            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id_item    sub1 = quantity 
            if (sub.Length == 2)
            {
                bool parse_id_flag = false;
                bool parse_quantity_flag = false;
                int id_item = 0, quantity = 0;
                int id_product;
                if (int.TryParse(sub[0].Trim(), out int parsed_id))
                {
                    id_item = parsed_id;
                    parse_id_flag = true;
                }
                else
                {
                    Console.WriteLine("Parsing failed. The input is not a valid integer.");
                }
                if (int.TryParse(sub[1].Trim(), out int parsed_quantity))
                {
                    quantity = parsed_quantity;
                    parse_quantity_flag = true;
                }
                else
                {
                    Console.WriteLine("Parsing failed. The input is not a valid integer.");
                }
                if (parse_id_flag == true && parse_quantity_flag == true)
                {


                    ProductStruct product = new ProductStruct();

                    if (cart_items.Count() > 0)
                    {
                        foreach (CartStruct item in cart_items)
                        {
                            if (item.GetId() == id_item)
                            {
                                id_product = item.GetIdProduct();
                                foreach (ProductStruct product_item in products)
                                {
                                    if (product_item.GetId() == id_product)
                                    {
                                        product = product_item;
                                    }
                                }
                                if (product.GetQuantity() >= quantity)
                                {
                                    item.SetQuantity(quantity);
                                }
                                else
                                {
                                    Console.WriteLine("not enough quantity");
                                }
                                found_flag = true;
                            }
                        }
                        data.SetCarts(cart_items);
                        if (found_flag == false)
                        {
                            Console.WriteLine("No product with this id");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No cart items");
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
            return "update_cart_item ( id_item ; quantity ) - updates the quantity of the item";
        }
    }
}
