﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart
{
    internal interface IPruductOperation
    {
        void Bat(ref List<ProductStruct> products, string data);
    }
}