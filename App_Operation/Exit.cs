using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.App_Operation
{
    internal class Exit : IAppOperation 
    {
        private string _name = "exit";

        public void Bat(string data)
        {
            System.Environment.Exit(0);
        }

        public string GetName()
        {
            return _name;
        }
    }
}
