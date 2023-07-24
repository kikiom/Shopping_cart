using Shopping_cart.Product_Operation;
using System;
using System.Collections.Generic;

namespace Shopping_cart.Handyman_Operation
{
    internal class Update_Quantity : IOperation
    {
        private string _name = "update_quantity";
        public void Bat(Data data, string args)
        {
            bool found_flag = false;
            List<ProductStruct> products = data.GetProducts();

            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id     sub1 = info


            if (sub.Length == 2)
            {
                bool parse_id_flag = false;
                int id_product = 0;

                if (int.TryParse(sub[0].Trim(), out int parsed_id))
                {
                    id_product = parsed_id;
                    parse_id_flag = true;
                }
                else
                {
                    Console.WriteLine("Parsing failed. The input is not a valid integer.");
                }

                if (parse_id_flag == true)
                {

                    if (products.Count > 0)
                    {

                        foreach (ProductStruct product in products)
                        {

                            if (product.GetId() == id_product)
                            {


                                if (int.TryParse(sub[1].Trim(), out int quantity))
                                {

                                    if (quantity >= 0)
                                    {
                                        product.SetQuantity(quantity);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong input quantity");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Parsing failed. The input is not a valid integer.");
                                }


                                Console.WriteLine("Product is editted");
                                found_flag = true;
                                break;
                            }

                        }

                        if (found_flag == false)
                        {
                            Console.WriteLine("Product is not found");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No products");
                    }

                    Save save = new Save();
                    save.ExportToTextFile(products);
                    data.SetProducts(products);
                }
            }
        }

        public bool CheckType(string type)
        {
            switch (type)
            {
                case "handyman":
                    return true;

                default: return false;
            }
        }

        public string GetName()
        {
            return _name;
        }

        public string print()
        {
            return "update_quantity( id; quantity) - updates the product quantity";
        }
    }
}
