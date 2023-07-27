using Shopping_cart.Logger_Operations;
using System;
using System.Collections.Generic;

namespace Shopping_cart.Product_Operation
{
    public class Remove_Prouduct : IOperation
    {
        string _name = "remove_product";
        public void Bat(Data data, string args)
        {
            Logger.Log(data, "debug", "Enter remove_product");

            bool found_flag =false;
            List<ProductStruct> products = data.GetProducts();
            int i = 0, index =0;

            if (int.TryParse(args.Trim(),out int id))
            {
                if (products.Count > 0)
                {
                    foreach (ProductStruct product in products)
                    {

                        if (product.GetId() == id)
                        {
                            index = i;
                            found_flag = true;
                        }
                        i++;
                    }

                    if (found_flag == true)
                    {
                        products.RemoveAt(index);

                        Console.WriteLine("Product remove");
                        Logger.Log(data, "info", "Product remove");
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
                Console.WriteLine("Parsing failed. The input is not a valid integer.");
                Logger.Log(data, "error", "Parsing failed. The input is not a valid integer.");

            }
            Logger.Log(data, "debug", "Exit remove_product");

        }

        public bool CheckType(string type)
        {
            switch (type)
            {
                case "admin":
                    return true;

                case "client":
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
            return "remove_product( id ) - removes a product";
        }
    }
}
