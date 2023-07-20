using Shopping_cart.App_Operation;
using Shopping_cart.Interface;
using Shopping_cart.Product_Operation;
using System;
using System.Collections.Generic;

namespace Shopping_cart
{

    internal class Program
    {
        static bool exitRequested = false;
        static void Main(string[] args)
        {
            Read read = new Read();
            Data data = new Data();
            Help help = new Help();


            read.ReadFromFile(data);
            string command = null;
            string arguments = null;

            Console.WriteLine("Hello there");
            do
            {
                read.ReadFromTerminal(ref command, ref arguments);
                foreach (IOperation operation in data.GetAllOperation())
                {
                    if (operation.GetName() == command && operation.CheckType(data.GetUserType())==true )
                    {
                        operation.Bat(data, arguments);
                        break;
                    }
                }
                if (help.GetName() == command)
                {
                    help.Bat(data.GetTypeOperations());
                }
                Console.CancelKeyPress += Console_CancelKeyPress;

            } while (command != "exit" || !exitRequested);

            Save_Prouduct save = new Save_Prouduct();
            save.ExportToTextFile(data.GetProducts());
            // Clean up and exit the program
            Console.WriteLine("Exiting the program...");
          

            
        }
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            
            exitRequested = true;
        }

    }

}
