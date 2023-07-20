using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_cart.Cart_Operation
{
    internal class Add_Cart_Item : IOperation
    {
        private string _name = "add_cart_item";
        public void Bat(Data data, string args)
        {
            List<CartStruct> cart_items = data.GetCarts();
            List<ProductStruct> products = data.GetProducts();

            bool found_product_flag = false;
            bool item_added_flag = false;

            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id_product    sub1 = quantity 
            if (sub.Length == 2)
            {
                bool parse_id_flag = false;
                bool parse_quantity_flag = false;
                int id_item = cart_items.Count, id_product = 0, quantity = 0;
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
                    if (products.Count() > 0)
                    {
                        foreach (ProductStruct item in products)
                        {
                            if (item.GetId() == id_product)
                            {
                                product = item;
                                found_product_flag = true;
                            }
                        }
                        foreach (CartStruct cart_item in cart_items)
                        {
                            if (cart_item.GetIdProduct() == id_product)
                            {
                                if (product.GetQuantity() >= (quantity + cart_item.GetQuantity()) && found_product_flag == true)
                                {
                                    cart_item.SetQuantity(quantity + cart_item.GetQuantity());
                                    Console.WriteLine("item added to cart");
                                }
                                else
                                {
                                    Console.WriteLine("not enough quantity");
                                }
                                item_added_flag = true;
                            }
                        }
                        if (item_added_flag == false)
                        {
                            if (product.GetQuantity() >= quantity && found_product_flag == true)
                            {
                                cart_items.Add(new CartStruct(id_item, quantity, product.GetId()));
                                Console.WriteLine("item added to cart");
                            }
                            else if (found_product_flag == true)
                            {
                                Console.WriteLine("not enough quantity");
                            }
                            if (found_product_flag == false)
                            {
                                Console.WriteLine("No product with this id");
                            }
                        }


                        data.SetCarts(cart_items);
                    }
                    else
                    {
                        Console.WriteLine("No products");
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
                case "user":
                    return false;
                default: return false;
            }
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "add_cart_item ( id_product ; quantity ) - add a new item to the cart";
        }
    }
}
