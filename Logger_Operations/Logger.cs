using System;
using System.IO;

namespace Shopping_cart.Logger_Operations
{

    static class Logger
    {
        private static string _type_msg = "error";
        public static void Set_Type_MSG(string type_msg)
        {
            _type_msg = type_msg;
        }
        public static void Type(string type_msg)
        {
            switch (type_msg)
            {
                case "error":
                    break;
                case "warn":
                    break;
                case "info":
                    break;
                case "debug":
                    break;
                default:
                    break;
            }
        }

        public static void Log(Data data, string type_msg, string message)
        {

            string logFilePath = "example.log"; // Replace this with your actual log file path

            // Information to append to the log file
            string logInformation = DateTime.Now.ToString() + " / " + type_msg + " / " + data.GetUserType() + " / " + message + "\n";

            try
            {
                // Append the information to the log file
                File.AppendAllText(logFilePath, logInformation);


            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }
}
