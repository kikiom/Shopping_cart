﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart
{
    public interface IOperation
    {
        string print();
        string GetName();
        void Bat(Data data, string args);
        bool CheckType(string type);
    }
}
