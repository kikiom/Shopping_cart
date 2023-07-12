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
        private double _price;
        private string _name;

        public CartStruct(int id, int quantity, ProductStruct product)
        {
            _id = id;
            _quantity = quantity;
            _name = product.GetName();
            _price = product.GetPrice();
        }

        public double GetPrice()
        {
            return _price;
        }
        public string GetName()
        {
            return _name;
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
        public string ToString()
        {
            return _id + " " + _name + " " + _quantity + " " + _price + "\n";
        }
    }
}
