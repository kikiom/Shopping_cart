using Shopping_cart.App_Operation;
using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System.Collections.Generic;

namespace Shopping_cart
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Read read = new Read();
            Save_Prouduct save = new Save_Prouduct();
            Data data = new Data();
            Help help = new Help();

            
            data.GetAppOperation();
            List<IOperation> all_operations = new List<IOperation>();
            all_operations.AddRange(data.GetAdminOperation());
            all_operations.AddRange(data.GetClientOperation());


            string command = null;
            string arguments = null;

            do
            {
                read.ReadFromTerminal(ref command, ref arguments);
                foreach (IOperation operation in data.GetAppOperation())
                {
                    if (operation.GetName() == command)
                    {
                        operation.Bat(data, arguments);
                    }
                }
                if (help.GetName() == command)
                {
                    help.Bat(all_operations);
                }

            } while (true);

            


        }
    }
}
