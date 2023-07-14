using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Interface
{
    internal interface ICartOperation
    {
        void Bat(ref List<CartStruct> cart_items, List<ProductStruct> products, string data);
    }
}
