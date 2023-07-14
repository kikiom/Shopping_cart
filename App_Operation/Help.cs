using Shopping_cart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.App_Operation
{
    internal class Help 
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
            help = help + "login - logs in a user\n" +
                "exit - close the program\n";
            Console.Write(help);
        }

        public string GetName()
        {
            return _name;
        }
    }
}
