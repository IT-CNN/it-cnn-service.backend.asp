using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Extensions;

public static class DictionnayExtensions
{
    public static Dictionary<string, List<string>> AddOrCreate(
            this Dictionary<string, List<string>> dictionnary,
            KeyValuePair<string, string> value)
    {
        if (dictionnary.TryGetValue(value.Key, out var val))
        {
            val.Add(value.Value);
            dictionnary[value.Key] = val;
        }
        else dictionnary.Add(value.Key, new List<string> { value.Value });
        return dictionnary;
    }
}
