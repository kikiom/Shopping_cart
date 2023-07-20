﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Product_Operation
{
    internal class Add_Prouduct : IOperation
    {
        private string _name = "add_product";
        public string GetName()
        {
            return _name;
        }
        
        public string print()
        {
            return "add_product( name ; price ; quantity ; description) - adds a new product";
        }

        public void Bat(Data data, string args)
        {
            List<ProductStruct> products;
            products = data.GetProducts();

            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = name     sub1 = price    sub2 = quantity     sub3 = description
            foreach(ProductStruct product in products)
            {
                if (double.Parse(sub[1].Trim()) == product.GetPrice() && sub[0].Trim() == product.GetName() && sub[3].Trim() == product.GetDescription())
                {
                    Console.WriteLine("Already exist. Use edit_product ");
                }
                else
                {
                    if(double.Parse(sub[1].Trim())>=0 && int.Parse(sub[2].Trim())>=0)
                    {
                        int id;
                        if (products.Count > 0)
                        {
                            id = products.Last().GetId() + 1;
                        }
                        else
                        {
                            id = 0;
                        }

                        ProductStruct new_product = new ProductStruct(id, int.Parse(sub[2].Trim()), double.Parse(sub[1].Trim()), sub[0].Trim(), sub[3].Trim());
                        products.Add(new_product);
                        data.SetProducts(products);
                        Save_Prouduct save = new Save_Prouduct();
                        save.ExportToTextFile(products);
                        Console.WriteLine("Product added");
                    }
                    
                }
            }
        }

        public bool CheckType(string type)
        {
            switch (type)
            {
                case "admin":
                    return true;

                default: return false;
            }
        }
    }
}
