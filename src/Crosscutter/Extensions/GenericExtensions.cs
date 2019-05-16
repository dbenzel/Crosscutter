using System.Linq;

namespace Crosscutter.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsIn<T>(this T source, params T[] items)
        {
            return items.Any(x => x.Equals(source));
        }
    }
}