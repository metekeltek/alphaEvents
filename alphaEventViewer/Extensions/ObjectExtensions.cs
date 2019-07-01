using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphaEventViewer.Extensions
{
    public static class ObjectExtensions
    {
        public static bool CanConvertTo<T>(this object obj)
        {
            if (typeof(T) == typeof(Guid))
            {
                try
                {
                    Guid.Parse(obj.ToString());
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            if (typeof(T) == typeof(DateTime))
            {
                try
                {
                    Convert.ToDateTime(obj.ToString());
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            if (typeof(T) == typeof(int))
            {
                try
                {
                    Convert.ToInt32(obj.ToString());
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            if (typeof(T) == typeof(bool))
            {
                try
                {
                    Convert.ToBoolean(obj.ToString());
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            if (typeof(T) == typeof(decimal))
            {
                try
                {
                    Convert.ToDecimal(obj.ToString());
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
