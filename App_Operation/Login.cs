using Shopping_cart.Interface;
using System;

namespace Shopping_cart.App_Operation
{
    public class Login : IOperation
    {
        private string _name = "login";
        public void Bat(Data data, string args)
        {
            switch (args.Trim())
            {
                case "admin":
                    Console.WriteLine("Welcome master");
                    data.SetUserType("admin");
                    break;
                case "client":
                    Console.WriteLine("Welcome wallet");
                    data.SetUserType("client");
                    break;
                case "handyman":
                    Console.WriteLine("Welcome staff");
                    data.SetUserType("handyman");
                    break;
                default:
                    Console.WriteLine("Incorrect type of user");
                    break;
            }
        }

        public bool CheckType(string type)
        {
            return true;
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "login ( type of user )- logs you in a accaunt";
        }
    }
}
