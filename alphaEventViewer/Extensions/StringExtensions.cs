using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphaEventViewer.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string obj)
        {
            return obj == null || obj.Length <= 0;
        }

        public static bool IsNotNullOrEmpty(this string obj)
        {
            return !obj.IsNullOrEmpty();
        }
    }
}
