using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public static class ExtensionMethods
    {
        public static TimeInterval Clone(this TimeInterval m)
        {
            if (m == null)
                return m;
            else
                return new TimeInterval(m);
        }

        public static String ToString(this int[] intArray, char dilimiter)
        {
            if (null == intArray) return null;

            char[] Dilimiter = new char[] { dilimiter };
            StringBuilder intString = new StringBuilder();
            bool notFirst = false;
            foreach (int seqNo in intArray)
            {
                if (notFirst)
                    intString.Append(dilimiter);
                intString.Append(seqNo.ToString());
                notFirst = true;
            }
            return intString.ToString();
        }

        /// <summary>
        /// Extract and return head of string and put the remaining of the string without the separated char the tail parameter to .
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sepChar"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        public static string ExtractHead(this string s, char sepChar, out string tail)
        {
            string head = null;
            string trimmedString = s.Trim();
            if (string.IsNullOrEmpty(trimmedString))
                tail = null;
            else
            {
                int sepCharIndex = trimmedString.IndexOf(sepChar);
                if (sepCharIndex == -1)
                {
                    head = trimmedString;
                    tail = null;
                }
                else
                {
                    head = trimmedString.Substring(0, sepCharIndex).TrimEnd();
                    tail = trimmedString.Substring(sepCharIndex + 1);
                }
            }
            return head;
        }

        public static int LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.AddMonths(1).Month, 1).AddDays(-1).Day;
        }

        public static bool IsLastDayOfMonth(this DateTime date)
        {
            return date.Month != date.AddDays(1).Month;
        }
    }
}
