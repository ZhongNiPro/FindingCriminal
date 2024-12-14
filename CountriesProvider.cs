using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FindingCriminal
{
    internal class CountriesProvider : ICountriesProvider
    {
        private static readonly string countriesFile = "Resources/Countries.txt";

        public List<string> ReceiveCountries()
        {
            List<string> countries = File.ReadAllLines(countriesFile).ToList();

            return File.ReadAllLines(countriesFile).ToList();
        }
    }
}
