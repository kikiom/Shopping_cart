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
            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id_product    sub1 = quantity 

            int id_item = cart_items.Count;
            int id_product = int.Parse(sub[0].Trim());
            int quantity = int.Parse(sub[1].Trim());

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
                if (product.GetQuantity() >= quantity && found_product_flag == true)
                {
                    cart_items.Add(new CartStruct(id_item, quantity, product.GetId()));
                }
                else
                {
                    Console.WriteLine("not enough quantity");
                }
                if (found_product_flag == false)
                {
                    Console.WriteLine("No product with this id");
                }

                data.SetCarts(cart_items);
            }
            else
            {
                Console.WriteLine("No products");
            }

        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "add_cart_item - add a new item to the cart";
        }
    }
}
