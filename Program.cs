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

            List<IOperation> admin_operations = data.GetAdminOperation();
            List<IOperation> client_operations = data.GetClientOperation();
            List<IAppOperation> app_operations = data.GetAppOperation();
            List<IOperation> all_operations = new List<IOperation>();
            all_operations.AddRange(admin_operations);
            all_operations.AddRange(client_operations);
            List<ProductStruct> products = new List<ProductStruct>();
            List<CartStruct>  carts = new List<CartStruct>();

            read.ReadFromFile(ref products);
            string command = null;
            string info = null;

            do
            {
                read.ReadFromTerminal(ref command, ref info);
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
