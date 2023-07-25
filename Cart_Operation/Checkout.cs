using Shopping_cart.Interface;
using Shopping_cart.Logger_Operations;
using Shopping_cart.Product_Operation;
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
            Logger.Log(data, "debug", "Enter checkout");

            List<CartStruct> cart_items = data.GetCarts();
            List<ProductStruct> products = data.GetProducts();
            List<ProductStruct> to_be_remove = new List<ProductStruct>();


            double price = 0;
            int id_product;
            ProductStruct product = new ProductStruct();
            if (cart_items.Count() > 0)
            {

                foreach (CartStruct item in cart_items)
                {
                    id_product = item.GetIdProduct();
                    foreach (ProductStruct item_product in products)
                    {
                        if (item_product.GetId() == id_product)
                        {
                            price = price + (item_product.GetPrice() * item.GetQuantity());
                            if (item_product.GetQuantity() == item.GetQuantity())
                            {
                                to_be_remove.Add(item_product);
                                
                            }
                            else
                            {
                                item_product.SetQuantity(item_product.GetQuantity()- item.GetQuantity());
                            }
                        }
                    }
                   
                }
                if (to_be_remove.Count() > 0)
                {
                    Remove_Prouduct remove_Prouduct = new Remove_Prouduct();
                    foreach (var item in to_be_remove)
                    {
                        
                        remove_Prouduct.Bat(data, item.GetId().ToString());
                    }
                    
                }
                Console.WriteLine("You paid "+price.ToString());
                cart_items.Clear();
                data.SetCarts(cart_items);
                data.SetProducts(products);
                Logger.Log(data, "info", "Checkout is complete");
            }
            else
            {
                Console.WriteLine("No products in the cart");
                Logger.Log(data, "warn", "No products in the cart");
            }
            Logger.Log(data, "debug", "Exit checkout");
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
            return "checkout() - retunr a sum for pay and clear cart";
        }
    }
}
