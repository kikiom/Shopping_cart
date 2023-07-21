using System;
using System.Collections.Generic;

namespace Shopping_cart.Product_Operation
{
    internal class Edit_Prouduct : IOperation
    {
        private string _name = "edit_product";
        public string GetName()
        {
            return _name;
        }
        public void Bat(Data data, string args)
        {
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
                                        break;

                                    case "price":

                                        if (double.TryParse(sub[2].Trim(), out double price))
                                        {

                                            if (price >= 0)
                                            {
                                                product.SetPrice(price);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong input price");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Parsing failed. The input is not a valid integer.");
                                        }
                                        

                                        break;

                                    case "quantity":

                                        if (int.TryParse(sub[0].Trim(), out int quantity))
                                        {

                                            if ( quantity > 0)
                                            {
                                                product.SetQuantity(quantity);
                                            }
                                            /*else if (int.Parse(sub[2].Trim()) == 0)
                                            {
                                                IOperation delete = new Remove_Prouduct();
                                                delete.Bat(data, id.ToString());
                                            }*/
                                            else
                                            {
                                                Console.WriteLine("Wrong input quantity");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Parsing failed. The input is not a valid integer.");
                                        }

                                        break;

                                    case "description":

                                        product.SetDescription(sub[2].Trim());
                                        break;

                                    default:

                                        Console.WriteLine("incorect field name");
                                        break;

                                }

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
