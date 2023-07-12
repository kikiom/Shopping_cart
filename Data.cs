using Shopping_cart.Product_Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart
{
    internal class Data
    {
        List<IOperation> client_operation = new List<IOperation>() { new List_Product()  };
        List<IOperation> admin_operation = new List<IOperation>() { };
        List<ProductStruct> product = new List<ProductStruct>();
        List<CartStruct> cart = new List<CartStruct>();
    }
}
