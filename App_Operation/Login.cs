﻿using Shopping_cart.Interface;
using System;

namespace Shopping_cart.App_Operation
{
    internal class Login : IAppOperation
    {
        private string _name = "login";

        public void Bat(string data)
        {
            switch (data.Trim())
            {
                case "admin": 
                    Admin admin = new Admin(); 
                    admin.Run(); 
                    break;
                case "client": 
                    Client client = new Client(); 
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
