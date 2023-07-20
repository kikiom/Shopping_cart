using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class List_Cart_Items : IOperation
    {
        private string _name = "list_cart_items";
        public void Bat(Data data, string args)
        {
            List<CartStruct> cart_items = data.GetCarts();
            List<ProductStruct> products = data.GetProducts();

            string text = null;
            if (cart_items.Count() > 0)
            {
                foreach (CartStruct item in cart_items)
                {

                    text = "ID : " + (item.GetId()).ToString();
                    foreach (ProductStruct product in products)
                    {
                        if (item.GetIdProduct() == product.GetId())
                        {
                            text = text + "; Name : " + product.GetName();
                            text = text + "; Price : " + product.GetPrice();
                            break;
                        }
                    }

                    text = text + "; Quantity : " + item.GetQuantity();
                    Console.WriteLine(text);
                }
            }
            else
            {
                Console.WriteLine("No products in the cart");
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
            return "list_cart_items() - list all items in the cart";
        }
    }
}
