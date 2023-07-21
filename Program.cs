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
            Save save = new Save();


            read.ReadFromFile(data);
            string command = null;
            string arguments = null;
            bool no_command_found=false;

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Hello there");
            
            //while ( !exitRequested )
            //{
                do
                {


                    read.ReadFromTerminal(ref command, ref arguments);
                    foreach (IOperation operation in data.GetAllOperation())
                    {
                        if (operation.GetName() == command && operation.CheckType(data.GetUserType()) == true)
                        {
                            operation.Bat(data, arguments);
                            no_command_found = true;
                            break;
                        }
                    }
                    if (help.GetName() == command)
                    {
                        help.Bat(data.GetTypeOperations());
                        no_command_found = true;
                    }
                    if (no_command_found == false)
                    {
                        Console.WriteLine("Wrong input. Either no command with this name or not right user");
                    }


                } while (command != "exit" || !exitRequested);

            //}
            save.ExportToTextFile(data.GetProducts());

            Console.WriteLine("Exiting the program...");
          

        }
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true; // Prevent the default behavior (terminate the application)

            // Add your custom handling here (optional)
            // For example, you can display a message, ask for confirmation, etc.

            Console.WriteLine("saving....");
            
            // Set the exitRequested flag to true to break out of the while loop in Main()
            exitRequested = true;
        }
        
    }

}
