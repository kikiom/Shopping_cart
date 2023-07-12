namespace Shopping_cart
{
    internal class ProductStruct
    {
        private string _name;
        private string _description;
        private double _price;
        private int _quantity;
        private int _id;

        public ProductStruct(int id, int quantity, double price, string name, string description)
        {
            _id = id;
            _quantity = quantity;
            _name = name;
            _price = price;
            _description = description;

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
        public string GetDescription()
        {
            return _description;
        }
        public int GetQuantity()
        {
            return _quantity;
        }
        public void SetPrice(double price)
        {
            _price = price;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }
        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }
        public string ToString()
        {
            return _id + " " + _name + " " + _quantity + " " + _price + " " + _description + "\n" ;
        }
    }
}
