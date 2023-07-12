using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.App_Operation
{
    internal class Help 
    {
        public void ToString(List<IOperation> operations)
        {
            string help = "Operations : \n";
            foreach (IOperation operation in operations)
            {
                help = help + operation.print();
                help = help + "\n";

            }
            Console.Write(help);
        }
    }
}
