using Shopping_cart.App_Operation;
using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System.Collections.Generic;

namespace Shopping_cart
{
    internal class Admin :  IUser
    {
        public void Run(Data data)
        {
            Read read = new Read();
            Save_Prouduct save = new Save_Prouduct();
            Help help = new Help();


            List<IOperation> all_operations = new List<IOperation>();
            all_operations.AddRange(data.GetAdminOperation());


            read.ReadFromFile(data);
            string command = null;
            string args = null;

            do
            {
                read.ReadFromTerminal(ref command, ref args);
                foreach (IOperation operation in data.GetAdminOperation())
                {
                    if (operation.GetName() == command)
                    {
                        operation.Bat(data, args);
                    }
                }
                foreach (IOperation operation in data.GetAppOperation())
                {
                    if (operation.GetName() == command)
                    {
                        operation.Bat(data, args);
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
