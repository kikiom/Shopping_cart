using Shopping_cart.App_Operation;
using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System.Collections.Generic;

namespace Shopping_cart
{
    internal class Admin
    {
        public void Run()
        {
            Read read = new Read();
            Save_Prouduct save = new Save_Prouduct();
            Data data = new Data();
            Help help = new Help();

            List<IOperation> admin_operations = data.GetAdminOperation();
            List<IAppOperation> app_operations = data.GetAppOperation();
            List<IOperation> all_operations = new List<IOperation>();
            all_operations.AddRange(admin_operations);
            List<ProductStruct> products = new List<ProductStruct>();
            List<CartStruct> carts = new List<CartStruct>();

            read.ReadFromFile(ref products);
            string command = null;
            string info = null;

            do
            {
                read.ReadFromTerminal(ref command, ref info);
                foreach (IOperation operation in admin_operations)
                {
                    if (operation.GetName() == command)
                    {
                        IPruductOperation pruductOperation = (IPruductOperation)operation;
                        pruductOperation.Bat(ref products, info);
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
