using System;
using System.IO;

namespace Shopping_cart.Logger_Operations
{
    enum Type_MSG
    {
        erorr,
        warn,
        info,
        debug
    }
    static class Logger
    {
        private static int _type_msg = 0;
        public static void Set_Type_MSG(string type_msg)
        {
            switch (type_msg)
            {
                case "error":
                    _type_msg = 0;
                    break;
                case "warn":
                    _type_msg = 1;
                    break;
                case "info":
                    _type_msg = 2;
                    break;
                case "debug":
                    _type_msg = 3;
                    break;
                default:
                    _type_msg = 0;
                    break;
            }

        }
        public static void Log(Data data, string type_msg, string message)
        {
            int this_type_msg;
            switch (type_msg)
            {
                case "error":
                    this_type_msg = 0;
                    break;
                case "warn":
                    this_type_msg = 1;
                    break;
                case "info":
                    this_type_msg = 2;

                    break;
                case "debug":
                    this_type_msg = 3;
                    break;
                default:
                    this_type_msg = 0;
                    break;
            }
            if (this_type_msg <= _type_msg)
            {
                Save(data, type_msg, message);
            }
        }

        public static void Save(Data data, string type_msg, string message)
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
