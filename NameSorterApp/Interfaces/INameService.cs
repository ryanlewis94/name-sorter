using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface INameService
    {
        /// <summary>
        /// Reads the file and get's the collection of names
        /// </summary>
        /// <param name="filePath">A string containing the path of the file to be read</param>
        /// <returns>Collection of names from the supplied filePath</returns>
        /// <exception cref="ArgumentNullException">filePath cannot be empty</exception>
        Task<IEnumerable<string>> ReadNamesAsync(string filePath);

        /// <summary>
        /// Writes the collection of names to a file
        /// </summary>
        /// <param name="names">Collection of names</param>
        /// <param name="filePath">A string containing the path of the file to write to</param>
        /// <exception cref="ArgumentNullException">names cannot be empty</exception>
        /// <exception cref="ArgumentNullException">filePath cannot be empty</exception>
        Task WriteNamesAsync(IEnumerable<string> names, string filePath);
    }
}
