using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TemplateFwExample.Utilities.Helpers
{
    public static class StringHelper
    {
        public static List<EdetorLine> GetStringLines(string source)
        {
            var result = new List<EdetorLine>();

            if (string.IsNullOrEmpty(source))
                return result;
            var items = source.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();
            var currentParentItem = new EdetorLine();
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item))
                    continue;

                if (item.StartsWith("-"))
                    currentParentItem.SubItems.Add(item.Replace("-", ""));
                else
                {
                    currentParentItem = new EdetorLine();
                    currentParentItem.SubItems = new List<string>();
                    currentParentItem.Item = item;
                    result.Add(currentParentItem);
                }
            }
            return result;
        }

        public static List<string> GetStringLinesString(string source)
        {
            if (string.IsNullOrEmpty(source))
                return new List<string>();
            return source.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();
        }

        public static int WordCount(this string str)
        {
            string[] userString = str.Split(new char[] { ' ', '.', '?' },
                                        StringSplitOptions.RemoveEmptyEntries);
            int wordCount = userString.Length;
            return wordCount;
        }
        public static int TotalCharWithoutSpace(this string str)
        {
            int totalCharWithoutSpace = 0;
            string[] userString = str.Split(' ');
            foreach (string stringValue in userString)
            {
                totalCharWithoutSpace += stringValue.Length;
            }
            return totalCharWithoutSpace;
        }

        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static string TrimAndReduce(this string str)
        {
            return ConvertWhitespacesToSingleSpaces(str).Trim();
        }

        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
        public static string SubstringByMax(this string value, int length)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string returnVal = ConvertWhitespacesToSingleSpaces(value).Trim();
                int maxLength = length;
                if (length > returnVal.Length)
                {
                    maxLength = returnVal.Length;
                    return returnVal;
                }
                else
                {
                    return returnVal.Substring(0, maxLength) + " ...";
                }

            }
            return value;
        }
    }

    public class EdetorLine
    {
        public string Item { get; set; }
        public List<string> SubItems { get; set; }
    }
}
