using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.App_Operation
{
    public class Help 
    {
        private string _name = "help";

        public void Bat(List<IOperation> operations)
        {
            string help = "Operations : \n";
            foreach (IOperation operation in operations)
            {
                help = help + operation.print();
                help = help + "\n";

            }
            Console.Write(help);
        }

        public string GetName()
        {
            return _name;
        }
    }
}
