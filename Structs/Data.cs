using Shopping_cart.App_Operation;
using Shopping_cart.Cart_Operation;
using Shopping_cart.Handyman_Operation;
using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System.Collections.Generic;

namespace Shopping_cart
{
    internal class Data
    {
        private List<IOperation> _all_operations = new List<IOperation>() { new Add_Cart_Item(), new Checkout(), new Remove_Cart_Item(), new Update_Cart_Item(), new List_Cart_Items(), new List_Product(), new Search_Product(), new Add_Prouduct(), new Edit_Prouduct(), new Remove_Prouduct(), new Login(), new Exit(), new Logger_Type(), new Update_Quantity() };
      
        private List<ProductStruct> _products = new List<ProductStruct>();
        private List<CartStruct> _carts = new List<CartStruct>();

   
        private string _user_type;
        
        public Data() 
        {
            _user_type = "user";
        }

        public List<IOperation> GetAllOperation()
        {
            return _all_operations;
        }
        public List<ProductStruct> GetProducts()
        {
            return _products;
        }
        public List<CartStruct> GetCarts()
        {
            return _carts;
        }
        public string GetUserType() 
        {
            return _user_type;
        }
        public List<IOperation> GetTypeOperations()
        {
            List<IOperation> type_operations = new List<IOperation>();
            foreach (IOperation operation in _all_operations)
            {
                if (operation.CheckType(_user_type)==true)
                {
                    type_operations.Add(operation);
                }
            }
            return type_operations;
        }
        public void SetClientOperation(List<IOperation> operations)
        {
            _all_operations = operations;
        }
        public void SetProducts(List<ProductStruct> products)
        {
            _products = products;
        }
        public void SetCarts(List<CartStruct> carts)
        {
            _carts = carts;
        }
        public void SetUserType(string user_type)
        {
            _user_type = user_type;
        }
    }
}
