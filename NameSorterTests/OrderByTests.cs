using Extensions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace NameSorterTests
{
    public class OrderByTests
    {
        [Test]
        public void NamesOrderedByLastNameThenFirst_EmptyCollection()
        {
            IEnumerable<string> emptyEnumerable = Enumerable.Empty<string>();
            Exception? ex = Assert.Throws<ArgumentNullException>(() => {emptyEnumerable.OrderByLastThenFirst(); });
            Assert.That(ex!.Message, Is.EqualTo("source cannot be empty. Please provide a valid collection to sort. (Parameter 'source')"));
        }

        [Test]
        public void NamesOrderedByLastNameThenFirst_Different_LastNames()
        {
            string[] unsortedNames = { "Janet Parsons", "Vaugh Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez" };

            IEnumerable<string> sortedNames = unsortedNames.OrderByLastThenFirst();

            Assert.That(sortedNames, Is.EqualTo(new List<string>
            {
                "Marin Alvarez", 
                "Adonis Julius Archer", 
                "Vaugh Lewis", 
                "Janet Parsons", 
                "Shelby Nathan Yoder"
            }));
        }

        [Test]
        public void NamesOrderedByLastNameThenFirst_Same_LastNames()
        {
            string[] unsortedNames = { "Ryan Lewis", "Vaugh Lewis", "Adonis Julius Lewis", "Shelby Nathan Lewis", "Marin Lewis" };

            IEnumerable<string> sortedNames = unsortedNames.OrderByLastThenFirst();

            Assert.That(sortedNames, Is.EqualTo(new List<string>
            {
                "Adonis Julius Lewis",
                "Marin Lewis",
                "Ryan Lewis",
                "Shelby Nathan Lewis",
                "Vaugh Lewis"
            }));
        }
    }
}
