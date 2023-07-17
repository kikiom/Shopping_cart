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
    internal class Client
    {
        public void Run()
        {
            Read read = new Read();
            Save_Prouduct save = new Save_Prouduct();
            Data data = new Data();
            Help help = new Help();
           
            List<IOperation> client_operations = data.GetClientOperation();
            List<IAppOperation> app_operations = data.GetAppOperation();
            List<IOperation> all_operations = new List<IOperation>();
            all_operations.AddRange(client_operations);
            List<ProductStruct> products = new List<ProductStruct>();
            List<CartStruct> carts = new List<CartStruct>();

            read.ReadFromFile(ref products, "C:\\Users\\zlati\\Source\\Repos\\Shopping_cart\\save.txt");
            string command = null;
            string info = null;

            do
            {
                read.ReadFromTerminal(ref command, ref info);
                foreach (IOperation operation in client_operations)
                {
                    if (operation.GetName() == command)
                    {
                        ICartOperation cartOperation = (ICartOperation)operation;
                        cartOperation.Bat(ref carts, products, info);
                    }
                }
                foreach (IAppOperation operation in app_operations)
                {
                    if (operation.GetName() == command)
                    {
                        operation.Bat(info);
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
