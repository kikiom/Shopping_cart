using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class Checkout : IOperation
    {
        private string _name = "checkout";
        public void Bat(Data data, string args)
        {
            List<CartStruct> cart_items = data.GetCarts();
            List<ProductStruct> products = data.GetProducts();

            double price = 0;
            int id_product;
            ProductStruct product = new ProductStruct();

            foreach (CartStruct item in cart_items) 
            {
                id_product = item.GetIdProduct();
                foreach (ProductStruct item_prouduct in products) 
                {
                    if(item_prouduct.GetId()  == id_product)
                    {
                        product = item_prouduct;
                    }
                }
                price = price + (product.GetPrice()*item.GetQuantity());
            }
            
            cart_items.Clear();
            data.SetCarts(cart_items);
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "checkout - retunr a sum for pay and clear cart";
        }
    }
}
