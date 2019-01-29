using System.Text.RegularExpressions;

namespace Organizations.Extensions
{
    public static class Extensions
    {
        public static string Between(this string str, string firstString, string lastString)
        {
            string final;
            int pos1 = str.IndexOf(firstString) + firstString.Length;
            int pos2 = str.IndexOf(lastString);
            final = str.Substring(pos1, pos2 - pos1);
            return final;
        }

        public static int NthIndexOf(this string target, string value, int n)
        {
            Match m = Regex.Match(target, "((" + Regex.Escape(value) + ").*?){" + n + "}");

            if (m.Success)
                return m.Groups[2].Captures[n - 1].Index;
            else
                return -1;
        }
    }
}