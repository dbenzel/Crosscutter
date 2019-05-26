using System.Collections.Generic;
using System.Linq;

namespace Crosscutter.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Evaluates the equality operator on each supplied item, returning true if any are equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool IsIn<T>(this T source, params T[] items)
        {
            return items.Any(x => x.Equals(source));
        }

        /// <summary>
        /// Converts a single instance of any type into a one-element list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<T> AsList<T>(this T source)
        {
            return source == null ? new List<T>() : new List<T> { source };
        }
    }
}