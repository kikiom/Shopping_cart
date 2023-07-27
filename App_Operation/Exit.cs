using System;

namespace Shopping_cart.App_Operation
{
    public class Exit : IOperation
    {
        private string _name = "exit";

        public void Bat(Data data, string args)
        {
            Console.WriteLine("bye");
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
            return "exit () - exits the program";
        }
    }
}
