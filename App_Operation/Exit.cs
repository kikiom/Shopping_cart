using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.App_Operation
{
    internal class Exit : IOperation
    {
        public void bat()
        {
            Environment.Exit(0);
        }

        public string print()
        {
            throw new NotImplementedException();
        }
    }
}
