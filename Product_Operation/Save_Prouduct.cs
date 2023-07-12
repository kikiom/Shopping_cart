using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart.Product_Operation
{
    internal class Save_Prouduct
    {
            static void ExportToTextFile<T>(this IEnumerable<T> data, string FileName, char ColumnSeperator)
            {
                using (var sw = File.CreateText(FileName))
                {
                    var plist = typeof(T).GetProperties().Where(p => p.CanRead && (p.PropertyType.IsValueType || p.PropertyType == typeof(string)) && p.GetIndexParameters().Length == 0).ToList();
                    if (plist.Count > 0)
                    {
                        var seperator = ColumnSeperator.ToString();
                        sw.WriteLine(string.Join(seperator, plist.Select(p => p.Name)));
                        foreach (var item in data)
                        {
                            var values = new List<object>();
                            foreach (var p in plist) values.Add(p.GetValue(item, null));
                            sw.WriteLine(string.Join(seperator, values));
                        }
                    }
                }
            }

    }
}
