using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DictionaryReplacer.Core
{
    public class Dictionary
    {
        public static string ReplaceString(string input, Dictionary<string, string> replacements, bool caseSensitive = true)
        {
            foreach (var pair in replacements)
            {
                string pattern = @"\$" + Regex.Escape(pair.Key) + @"\$";
                RegexOptions options = caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
                input = Regex.Replace(input, pattern, pair.Value, options);
            }
            return input;
        }


    }
}
