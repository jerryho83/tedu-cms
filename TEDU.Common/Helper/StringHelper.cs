using System.Text;
using System.Text.RegularExpressions;

namespace TEDU.Common.Helper
{
    public static class StringHelper
    {
        public static string ToUnsignString(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            input = input.Replace(".", "-");
            input = input.Replace(" ", "-");
            input = input.Replace(",", "-");
            input = input.Replace(";", "-");
            input = input.Replace(":", "-");
            input = input.Replace("  ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            while (str2.Contains("--"))
            {
                str2 = str2.Replace("--", "-").ToLower();
            }
            return str2;
        }

        public static string OptimizeLength(this string input, int lenght = 40)
        {
            if (!string.IsNullOrEmpty(input) && input.Length > lenght)
            {
                string[] parts = input.Split(' ');
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < parts.Length; i++)
                {
                    if (sb.Length + parts[i].Length > lenght)
                        break;

                    sb.Append(' ');
                    sb.Append(parts[i]);
                }

                sb.Append("...");

                return sb.ToString();
            }
            else
            {
                return input;
            }
        }
    }
}