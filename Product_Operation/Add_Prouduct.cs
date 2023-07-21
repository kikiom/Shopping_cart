using System;
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
            if (sub.Length == 4)
            {
                
                bool parse_price_flag = false;
                bool parse_quantity_flag = false;
                int   quantity = 0;
                double price = 0;
                
                if (int.TryParse(sub[2].Trim(), out int parsed_quantity))
                {
                    quantity = parsed_quantity;
                    parse_quantity_flag = true;
                }
                else
                {
                    Console.WriteLine("Parsing failed. The input is not a valid integer.");
                }
                
                if (double.TryParse(sub[1].Trim(),  out double parsed_price))
                {
                    price = parsed_price;
                    parse_price_flag = true;
                }
                else
                {
                    Console.WriteLine("Parsing failed. The input is not a valid double.");
                }

                if (parse_price_flag == true && parse_quantity_flag == true)
                {

                    foreach (ProductStruct product in products)
                    {
                        if (price == product.GetPrice() && sub[0].Trim() == product.GetName() && sub[3].Trim() == product.GetDescription())
                        {
                            Console.WriteLine("Already exist. Use edit_product ");
                        }
                        else
                        {
                            if (price >= 0 && quantity >= 0)
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

                                ProductStruct new_product = new ProductStruct(id, quantity, price, sub[0].Trim(), sub[3].Trim());
                                products.Add(new_product);
                                data.SetProducts(products);
                                Save save = new Save();
                                save.ExportToTextFile(products);
                                Console.WriteLine("Product added");
                            }

                        }
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
