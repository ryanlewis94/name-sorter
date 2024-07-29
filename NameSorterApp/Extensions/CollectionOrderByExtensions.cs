namespace Extensions
{
    public static class CollectionOrderByExtensions
    {
        public static IEnumerable<string> OrderByLastThenFirst(this IEnumerable<string> source)
        {
            if (source.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(source), $"{nameof(source)} cannot be empty. Please provide a valid collection to sort.");
            }

            IEnumerable<string> sortedCollection = source.ToArray()
                .OrderBy(x => x.Split().Last())
                .ThenBy(y => y.Split().First());

            return sortedCollection;
        }
    }
}
