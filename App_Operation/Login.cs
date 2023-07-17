using Shopping_cart.Interface;
using System;

namespace Shopping_cart.App_Operation
{
    internal class Login : IAppOperation
    {
        private string _name = "login";
        private Client client = new Client();
        private Admin admin = new Admin();
        public void Bat(string data)
        {
            switch (data.Trim())
            {
                case "admin": 
                    
                    admin.Run(); 
                    break;
                case "client": 
                    
                    client.Run(); 
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
    }
}
