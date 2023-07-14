using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart
{
    internal class Read
    {
        public void ReadFromTerminal(ref string command, ref string data) 
        {
            string input = Console.ReadLine();
            char[] separators = new char[] { '(', ')' };

            string[] subs = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            command = subs[0];
            if (subs.Length > 1 ) 
            {
                data = subs[1];
            }
            else
            {
                data = null;
            }
            
           
        }
        public void ReadFromFile(ref List<ProductStruct> products, string filename)
        {
            if (File.Exists(filename))
            {
                // Create a StreamReader to read from the file
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        char[] separator = { ';' };
                        string[] sub = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        //sub0 = id     sub1 = name     sub2 = price    sub3 = quantity     sub4 = description
                        products.Add(new ProductStruct(int.Parse(sub[0]), int.Parse(sub[3]), double.Parse(sub[2]), sub[1], sub[4]));
                    }
                }
            }
        }
    }
}
