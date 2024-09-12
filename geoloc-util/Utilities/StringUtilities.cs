using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoloc_util.Utilities
{
    internal class StringUtilities
    {
        public static string ReplaceSubstring(string str, string match, string replace)
        {
            if (str == null)
                return null;
            StringBuilder sb = new StringBuilder(str);
            sb.Replace(match, replace);
            return sb.ToString();
        }
    }
}
