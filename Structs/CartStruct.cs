using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shopping_cart
{
    internal class CartStruct
    {
        private int _id;
        private int _quantity;
        private int _id_product;

        public CartStruct(int id, int quantity, int id_product)
        {
            _id = id;
            _quantity = quantity;
            _id_product = id_product;
        }

        public int GetIdProduct()
        {
            return _id_product;
        }
        public int GetId()
        {
            return _id;
        }
        public int GetQuantity()
        {
            return _quantity;
        }
        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }
        public void SetId(int id)
        {
            _id = id;
        }
        public string ToString()
        {
            return "ID item cart: " + _id + "; Quantity: " + _quantity ;
        }
    }
}
