using Shopping_cart.App_Operation;
using Shopping_cart.Cart_Operation;
using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System.Collections.Generic;

namespace Shopping_cart
{
    internal class Data
    {
        private List<IOperation> _client_operations = new List<IOperation>() { new Add_Cart_Item(), new Checkout(), new Remove_Cart_Item(), new Update_Cart_Item(), new List_Cart_Items(), new List_Product(), new Search_Product() };
        private List<IOperation> _admin_operations = new List<IOperation>() { new Add_Prouduct(), new Edit_Prouduct(), new Remove_Prouduct(), new List_Product(), new Search_Product() };
        private List<IOperation> _app_operations = new List<IOperation>() { new Login(), new Exit() };
      
        private List<ProductStruct> _products = new List<ProductStruct>();
        private List<CartStruct> _carts = new List<CartStruct>();

        private Client _client = new Client();
        private Admin _admin = new Admin();

        public List<IOperation> GetClientOperation()
        {
            return _client_operations;
        }
        public List<IOperation> GetAdminOperation()
        {
            return _admin_operations;
        }
        public List<IOperation> GetAppOperation()
        {
            return _app_operations;
        }
        public List<ProductStruct> GetProducts()
        {
            return _products;
        }
        public List<CartStruct> GetCarts()
        {
            return _carts;
        }
        public void SetClientOperation(List<IOperation> operations)
        {
            _client_operations = operations;
        }
        public void SetAdminOperation(List<IOperation> operations)
        {
            _admin_operations = operations;
        }
        public void SetAppOperation(List<IOperation> operations)
        {
            _app_operations = operations;
        }
        public void SetProducts(List<ProductStruct> products)
        {
            _products = products;
        }
        public void SetCarts(List<CartStruct> carts)
        {
            _carts = carts;
        }
        public Admin GetAdmin()
        {
            return _admin;
        }
        public Client GetClient()
        {
            return _client;
        }
    }
}
