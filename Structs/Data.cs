using Shopping_cart.App_Operation;
using Shopping_cart.Cart_Operation;
using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System.Collections.Generic;

namespace Shopping_cart
{
    internal class Data
    {
        List<IOperation> _client_operations = new List<IOperation>() { new Add_Cart_Item(), new Checkout(), new Remove_Cart_Item(), new Update_Cart_Item(), new List_Cart_Items() };
        List<IOperation> _admin_operations = new List<IOperation>() { new Add_Prouduct(), new Edit_Prouduct(), new Remove_Prouduct(), new List_Product(), new Search_Product() };
        List<IAppOperation> _app_operations = new List<IAppOperation>() { new Login(), new Exit() };
        List<ProductStruct> _products = new List<ProductStruct>();
        List<CartStruct> _carts = new List<CartStruct>();

        public List<IOperation> GetClientOperation()
        {
            return _client_operations;
        }
        public List<IOperation> GetAdminOperation()
        {
            return _admin_operations;
        }
        public List<IAppOperation> GetAppOperation()
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
        public void SetAppOperation(List<IAppOperation> operations)
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
    }
}
