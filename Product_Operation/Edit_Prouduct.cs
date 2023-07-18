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
            List<ProductStruct> products = data.GetProducts();
            char[] separator = { ';' };
            string[] sub = args.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //sub0 = id     sub1 = field_name     sub2 = info
            int id = int.Parse(sub[0].Trim());
            string field_name = sub[1].Trim();
            foreach (ProductStruct product in products)
            {
                if (product.GetId() == id)
                {
                    switch(field_name)
                    {
                        case "name":
                            product.SetName(sub[2].Trim());
                            break;
                        case "price":
                            product.SetPrice(double.Parse(sub[2].Trim()));
                            break;
                        case "quantity":
                            product.SetQuantity(int.Parse(sub[2].Trim()));
                            break;
                        case "description":
                            product.SetDescription(sub[2].Trim());
                            break;
                        default:
                            Console.WriteLine("incorect field name");
                            break;

                    }

                }

            }

            Save_Prouduct save = new Save_Prouduct();
            save.ExportToTextFile(products);
            data.SetProducts(products);
        
        }

        public string print()
        {
            return "edit_product - eidt the specified product";
        }

    }
}
