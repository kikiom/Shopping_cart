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

            int id = int.Parse(sub[0].Trim());
            string field_name = sub[1].Trim();

            if (products.Count > 0)
            {

                foreach (ProductStruct product in products)
                {

                    if (product.GetId() == id)
                    {
                        switch (field_name)
                        {
                            case "name":

                                product.SetName(sub[2].Trim());
                                break;
                            case "price":

                                if (double.Parse(sub[2].Trim()) >= 0)
                                {
                                    product.SetPrice(double.Parse(sub[2].Trim()));
                                }
                                else
                                {
                                    Console.WriteLine("Wrong input price");
                                }

                                break;
                            case "quantity":

                                if (int.Parse(sub[2].Trim()) > 0)
                                {
                                    product.SetQuantity(int.Parse(sub[2].Trim()));
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

                                break;
                            case "description":
                                product.SetDescription(sub[2].Trim());
                                break;
                            default:
                                Console.WriteLine("incorect field name");
                                break;

                        }
                        found_flag = true;
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
            Save_Prouduct save = new Save_Prouduct();
            save.ExportToTextFile(products);
            data.SetProducts(products);

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
