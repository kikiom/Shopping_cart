using Shopping_cart.Logger_Operations;
using System;
using System.Collections.Generic;

namespace Shopping_cart.Product_Operation
{
    public class Edit_Prouduct : IOperation
    {
        private string _name = "edit_product";
        public string GetName()
        {
            return _name;
        }
        public void Bat(Data data, string args)
        {
            Logger.Log(data, "debug", "Enter edit_product");

            bool found_flag = false;
            List<ProductStruct> products = data.GetProducts();

            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id     sub1 = field_name     sub2 = info


            if (sub.Length == 3)
            {
                bool parse_id_flag = false;
                bool parse_info_flag = false;
                int id_product = 0;
                string field_name = sub[1].Trim();

                if (int.TryParse(sub[0].Trim(), out int parsed_id))
                {
                    id_product = parsed_id;
                    parse_id_flag = true;
                }
                else
                {
                    Console.WriteLine("Parsing failed. The input is not a valid integer.");
                    Logger.Log(data, "error", "Parsing failed. The input is not a valid integer.");

                }

                if (parse_id_flag == true)
                {

                    if (products.Count > 0)
                    {

                        foreach (ProductStruct product in products)
                        {

                            if (product.GetId() == id_product)
                            {

                                switch (field_name)
                                {

                                    case "name":

                                        product.SetName(sub[2].Trim());
                                        Console.WriteLine("Product is editted");
                                        Logger.Log(data, "info", "Product is editted");
                                        break;

                                    case "price":

                                        if (double.TryParse(sub[2].Trim(), out double price))
                                        {

                                            if (price >= 0)
                                            {
                                                product.SetPrice(price);
                                                Console.WriteLine("Product is editted");
                                                Logger.Log(data, "info", "Product is editted");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong input price");
                                                Logger.Log(data, "warn", "Wrong input price");

                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Parsing failed. The input is not a valid integer.");
                                            Logger.Log(data, "error", "Parsing failed. The input is not a valid integer.");

                                        }


                                        break;

                                    case "quantity":

                                        if (int.TryParse(sub[2].Trim(), out int quantity))
                                        {

                                            if ( quantity >= 0)
                                            {
                                                product.SetQuantity(quantity);
                                                Console.WriteLine("Product is editted");
                                                Logger.Log(data, "info", "Product is editted");
                                            }
                                            /*else if (int.Parse(sub[2].Trim()) == 0)
                                            {
                                                IOperation delete = new Remove_Prouduct();
                                                delete.Bat(data, id.ToString());
                                            }*/
                                            else
                                            {
                                                Console.WriteLine("Wrong input quantity");
                                                Logger.Log(data, "warn", "Wrong input quantity");

                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Parsing failed. The input is not a valid integer.");
                                            Logger.Log(data, "error", "Parsing failed. The input is not a valid integer.");

                                        }

                                        break;

                                    case "description":

                                        product.SetDescription(sub[2].Trim());
                                        Console.WriteLine("Product is editted");
                                        Logger.Log(data, "info", "Product is editted");
                                        break;

                                    default:

                                        Console.WriteLine("incorect field name");
                                        Logger.Log(data, "error", "Incorect field name in edit_product");

                                        break;

                                }
                                

                                found_flag = true;
                                break;
                            }

                        }

                        if (found_flag == false)
                        {
                            Console.WriteLine("Product is not found");
                            Logger.Log(data, "info", "Product is not found");

                        }

                    }
                    else
                    {
                        Console.WriteLine("No products");
                        Logger.Log(data, "warn", "No products");
                    }

                    Save save = new Save();
                    save.ExportToTextFile(products);
                    data.SetProducts(products);

                }
                else
                {
                    Logger.Log(data, "warn", "One parse has failed in add_product");

                }
            }
            else 
            { 
                Console.WriteLine("Not enough arguments");
                Logger.Log(data, "error", "Not enough arguments");

            }
            Logger.Log(data, "debug", "Exit edit_product");

        }

        public string print()
        {
            return "edit_product( id ; feild ; new data) - eidt the specified product";
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
