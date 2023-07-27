using System.Collections.Generic;
using System.IO;

namespace Shopping_cart.Product_Operation
{
    public class Save
    {
        public void ExportToTextFile(List<ProductStruct> data)
        {
            string FileName = "save.txt";
            using (StreamWriter writer = new StreamWriter(FileName))
            {

                foreach (ProductStruct item in data)
                {
                    writer.WriteLine(item.ToSave());
                }


            }
        }

    }
}
