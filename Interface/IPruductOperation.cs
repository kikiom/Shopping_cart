﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart
{
    public interface IPruductOperation
    {
        void Bat(ref List<ProductStruct> products, string data);
    }
}
