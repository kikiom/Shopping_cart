using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.App_Operation
{
    internal class Exit : IOperation 
    {
        private string _name = "exit";

        public void Bat(Data data, string args)
        {
            System.Environment.Exit(0);
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "exit - exits the program";
        }
    }
}
