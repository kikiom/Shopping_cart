using Shopping_cart.App_Operation;
using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart
{
    internal class Client : IUser
    {
        public void Run(Data data)
        {
            Read read = new Read();
            Help help = new Help();
            


            
            
            string command = null;
            string args = null;

          /*  
            do
            {
                read.ReadFromTerminal(ref command, ref args);
                foreach (IOperation operation in all_operations)
                {
                    if (operation.GetName() == command)
                    {
                        operation.Bat (data, args);
                        break;
                    }
                }
                if (help.GetName() == command)
                {
                    help.Bat(all_operations);
                }

            } while (true);
*/

        }
    }
}
