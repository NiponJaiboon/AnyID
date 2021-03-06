﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace iSabaya
{
    public static class ClassExtender
    {
        public static IList<T> Take<T>(this IList<T> list, int startIndex, int elementCount)
        {
            IList<T> result = new List<T>();
            int listCount = list.Count;
            while (elementCount-- > 0 && startIndex < listCount)
            {
                result.Add(list.ElementAt<T>(startIndex++));
            }
            return result;
        }

        public static bool MarkMenuAsAccessible(this IList<UseCase> roots, UseCase menu)
        {
            bool found = false;

            foreach (UseCase m in roots)
            {
                if (m.ID == menu.ID)
                {
                    m.Show = true;
                    found = true;
                    break;
                }
                else if (m.Children.MarkMenuAsAccessible(menu))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public static String GetAllMessages(this Exception ex, int maxLength = 4000)
        {
            return GetAllMessages(ex, maxLength, "\n");
        }

        public static String GetAllMessages(this Exception ex, int maxLength, String connective)
        {
            StringBuilder msgBuilder = new StringBuilder();
            bool notFirst = false;
            int length = 0;
            while (ex != null && length + ex.Message.Length + 1 <= maxLength)
            {
                if (notFirst)
                {
                    notFirst = true;
                    msgBuilder.Append(connective);
                }
                length = ex.Message.Length + 1;
                msgBuilder.Append(ex.Message);
                ex = ex.InnerException;
            }

            return msgBuilder.ToString();
        }

        public static bool IsNullOrEmpty(this TimeInterval t)
        {
            return null == t || t.IsEmpty;
        }
    }
}
