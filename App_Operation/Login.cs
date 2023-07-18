using Shopping_cart.Interface;
using System;

namespace Shopping_cart.App_Operation
{
    internal class Login :  IOperation
    {
        private string _name = "login";
        public void Bat(Data data, string args)
        {
            switch (args.Trim())
            {
                case "admin":
                    Admin admin = data.GetAdmin();
                    admin.Run(data);
                    break;
                case "client":
                    Client client = data.GetClient();
                    client.Run(data);
                    break;
                default:
                    Console.WriteLine("Incorrect type of user");
                    break;
            }
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "login - logs you in a accaunt";
        }
    }
}
