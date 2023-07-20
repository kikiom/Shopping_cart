using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class Update_Cart_Item : IOperation
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
            int id_item = int.Parse(sub[0].Trim());
            int id_product;
            int quantity = int.Parse(sub[1].Trim());

            ProductStruct product = new ProductStruct();

            if (cart_items.Count() > 0)
            {
                foreach (CartStruct item in cart_items)
                {
                    if (item.GetId() == id_item)
                    {
                        id_product = item.GetIdProduct();
                        foreach(ProductStruct product_item in products)
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
