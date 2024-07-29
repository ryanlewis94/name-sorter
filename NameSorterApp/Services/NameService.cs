using Extensions;
using Interfaces;

namespace Services
{
    public class NameService : INameService
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<string>> ReadNamesAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), $"{nameof(filePath)} cannot be empty. Please provide a valid {nameof(filePath)} to read from.");
            }

            return await File.ReadAllLinesAsync(filePath);
        }

        /// <inheritdoc/>
        public async Task WriteNamesAsync(IEnumerable<string> names, string filePath)
        {
            if (names.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(names), $"{nameof(names)} cannot be empty. Please provide a valid list of {nameof(names)} to write to {nameof(filePath)}.");
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), $"{nameof(filePath)} cannot be empty. Please provide a valid {nameof(filePath)} to write to.");
            }

            await File.WriteAllLinesAsync(filePath, names);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
