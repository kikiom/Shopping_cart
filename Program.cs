using Shopping_cart.App_Operation;
using Shopping_cart.Product_Operation;
using System;

namespace Shopping_cart
{

    internal class Program
    {
        static bool exitRequested = false;
        static Data data = new Data();
        static void Main(string[] args)
        {
            Read read = new Read();
            
            Help help = new Help();


            read.ReadFromFile(data);
            string command = null;
            string arguments = null;
            bool no_command_found = false;

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Hello there");

            
            do
            {
                if (exitRequested == true)
                {
                    break;
                }
                else
                {
                    no_command_found = false;
                    command = null; arguments = null;
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
                    if (no_command_found == false && command != null)
                    {
                        Console.WriteLine("Wrong input. Either no command with this name or not right user");
                    }

                }


            } while (command != "exit");

           
            

            Console.WriteLine("Exiting the program...");


        }
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = false; // Prevent the default behavior (terminate the application)

            // Add your custom handling here (optional)
            // For example, you can display a message, ask for confirmation, etc.
            
            Console.WriteLine("Unexpected exit");
            Console.WriteLine("saving....");
            Save save = new Save();
            save.ExportToTextFile(data.GetProducts());
            Console.WriteLine("data saved");

            // Set the exitRequested flag to true to break out of the while loop in Main()
            exitRequested = true;
        }

    }

}
