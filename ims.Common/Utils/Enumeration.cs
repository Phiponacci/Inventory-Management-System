using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ims.Common.Utils;

public class Enumeration<TEnum> where TEnum : Enumeration<TEnum>
{
    public static List<string> GetModules()
    {
        var fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);
        var constFields = fields.Where(f => f.IsLiteral && !f.IsInitOnly);
        var modules = constFields.Select(f => f.GetValue(null)).OfType<string>().ToList();
        return modules;
    }
}
