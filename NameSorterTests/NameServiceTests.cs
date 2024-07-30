using NUnit.Framework;
using Services;
using Assert = NUnit.Framework.Assert;

namespace NameSorterTests
{
    public class NameServiceTests
    {
        //[Test]
        //public async Task ReadNamesAsync()
        //{
        //    var nameService = new NameService();
        //    IEnumerable<string> namesList = await nameService.ReadNamesAsync("unsorted-names-list.txt");

        //    Assert.That(namesList, Is.EqualTo(new List<string>
        //    {
        //        "Janet Parsons", 
        //        "Vaugh Lewis", 
        //        "Adonis Julius Archer", 
        //        "Shelby Nathan Yoder", 
        //        "Marin Alvarez", 
        //        "London Lindsey", 
        //        "Beau Tristan Bentley",
        //        "Leo Gardner",
        //        "Hunter Uriah Mathew Clarke",
        //        "Mikayla Lopez",
        //        "Frankie Conner Ritter"
        //    }));
        //}

        [Test]
        public void ReadNamesAsync_EmptyFilePath()
        {
            var nameService = new NameService();

            Exception? ex = Assert.ThrowsAsync<ArgumentNullException>(() => nameService.ReadNamesAsync(string.Empty));
            Assert.That(ex!.Message, Is.EqualTo("filePath cannot be empty. Please provide a valid filePath to read from. (Parameter 'filePath')"));
        }

        [Test]
        public async Task WriteNamesAsync()
        {
            var nameService = new NameService();
            var unsortedNameList = new List<string>
            {
                "Janet Parsons",
                "Vaugh Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter"
            };

            await nameService.WriteNamesAsync(unsortedNameList, "sorted-names-list.txt");

            Assert.That(File.Exists("sorted-names-list.txt"));
            Assert.That(await nameService.ReadNamesAsync("sorted-names-list.txt"), Is.EqualTo(unsortedNameList));
        }

        [Test]
        public void WriteNamesAsync_EmptyCollection()
        {
            var nameService = new NameService();

            Exception? ex = Assert.ThrowsAsync<ArgumentNullException>(() => nameService.WriteNamesAsync(Enumerable.Empty<string>(), "sorted-names-list.txt"));
            Assert.That(ex!.Message, Is.EqualTo("names cannot be empty. Please provide a valid list of names to write to filePath. (Parameter 'names')"));
        }

        [Test]
        public void WriteNamesAsync_EmptyFilePath()
        {
            var nameService = new NameService();

            Exception? ex = Assert.ThrowsAsync<ArgumentNullException>(() => nameService.WriteNamesAsync(new List<string>{"test"}, string.Empty));
            Assert.That(ex!.Message, Is.EqualTo("filePath cannot be empty. Please provide a valid filePath to write to. (Parameter 'filePath')"));
        }
    }
}
