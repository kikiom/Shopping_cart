using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Logger_Operations
{
    internal class Logger_Type : IOperation
    {
        private string _name = "logger_type";
        public void Bat(Data data, string args)
        {
            args = args.Trim();
            if (args.Length > 0)
            {
                Logger.Set_Type_MSG(args);
            }
        }

        public bool CheckType(string type)
        {
            return true;
        }

        public string GetName()
        {
            return _name;

        }

        public string print()
        {
            return "logger_type ( type ) - set the type of msg level, the default is errror level";
        }
    }
}
