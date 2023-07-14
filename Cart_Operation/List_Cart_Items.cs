using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class List_Cart_Items : IOperation, ICartOperation
    {
        private string _name = "list_cart_items";
        public void Bat(ref List<CartStruct> cart_items, List<ProductStruct> products, string data)
        {
            string text = null;
            foreach (CartStruct item in cart_items)
            {
                text = (item.GetId()).ToString();
                foreach (ProductStruct product in products)
                {
                    if (item.GetIdProduct() == product.GetId()) 
                    {
                        text = text + product.GetName();
                        text = text + product.GetPrice();
                        break;
                    }
                }
                text = text + item.GetQuantity();
                Console.WriteLine(text);
            }
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "list_cart_items - list all items in the cart";
        }
    }
}
