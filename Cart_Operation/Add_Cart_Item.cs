using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class Add_Cart_Item : IOperation
    {
        private string _name="add_cart_item";
        public void Bat(Data data, string args)
        {
            List<CartStruct> cart_items = data.GetCarts();
            List<ProductStruct> products = data.GetProducts();

            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id_product    sub1 = quantity 

            int id_item =cart_items.Count;
            int id_product = int.Parse(sub[0].Trim());
            int quantity = int.Parse(sub[1].Trim());

            ProductStruct product = new ProductStruct();

            foreach(ProductStruct item in products) 
            { 
                if(item.GetId() == id_product)
                {
                    product = item;
                }
            }
            if(product.GetQuantity() >= quantity)
            {
                cart_items.Add(new CartStruct(id_item, quantity, product.GetId()));
            }
            else
            {
                Console.WriteLine("not enough quantity");
            }

            data.SetCarts(cart_items);
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
