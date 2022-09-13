using System.Text.RegularExpressions;

namespace Youi_Automation_Tests.Src.Util
{
    public static class StringExtrensions
    {
        public static bool ContainsIgnoreCase(this string @this, string value) => @this.ToLower().Contains(value.ToLower());
        public static string StripNonNumeric(this string @this) => Regex.Replace(@this, "[^\\d.]+", "");
    }
}
