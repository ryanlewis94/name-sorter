using Extensions;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace NameSorterApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please provide a single valid file path.");
                return;
            }

            string filePath = args[0];

            ServiceProvider serviceProvider = GetServiceProvider();
            INameService nameService = serviceProvider.GetService<INameService>()!;

            try
            {
                IEnumerable<string> unsortedNames = await nameService.ReadNamesAsync(filePath);

                IEnumerable<string> sortedNames = unsortedNames.OrderByLastThenFirst();

                await nameService.WriteNamesAsync(sortedNames, "sorted-names-list.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<INameService, NameService>()
                .BuildServiceProvider();
        }
    }
}
