using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Cart_Operation
{
    internal class Checkout : IOperation, ICartOperation
    {
        private string _name = "checkout";
        public void Bat(ref List<CartStruct> cart_items, List<ProductStruct> products, string data)
        {
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
