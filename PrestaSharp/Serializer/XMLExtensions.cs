using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Serializer
{
    public static class XMLExtensions
    {
        internal static object? ChangeType(this object? source, Type newType) => Convert.ChangeType(source, newType);
    }
}
