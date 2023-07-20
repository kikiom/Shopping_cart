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
            command = subs[0].Trim();
            if (subs.Length > 1 ) 
            {
                data = subs[1];
            }
            else
            {
                data = null;
            }
            
           
        }
        public void ReadFromFile(Data data)
        {
            List<ProductStruct> products = new List<ProductStruct>();
            string  filename =  "save.txt";
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
                        products.Add(new ProductStruct(int.Parse(sub[0].Trim()), int.Parse(sub[3].Trim()), double.Parse(sub[2].Trim()), sub[1].Trim(), sub[4].Trim()));
                    }
                }
            }
            data.SetProducts(products);
        }
    }
}
