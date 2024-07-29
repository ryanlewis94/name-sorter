
using System.Linq;

namespace Extensions
{
    public static class IsNullOrEmptyExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
    }
}
