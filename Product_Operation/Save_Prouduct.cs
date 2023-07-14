using System.Collections.Generic;
using System.IO;

namespace Shopping_cart.Product_Operation
{
    internal class Save_Prouduct
    {
        public void ExportToTextFile(List<ProductStruct> data)
        {
            string FileName = "C:\\Users\\zlati\\Source\\Repos\\Shopping_cart\\save.txt";
            using (StreamWriter writer = new StreamWriter(FileName))
            {

                foreach (ProductStruct item in data)
                {
                    writer.WriteLine(item.ToString());
                }


            }
        }

    }
}
