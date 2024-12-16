using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FindingCriminal
{
    internal class CountriesProvider : ICountriesProvider
    {
        private readonly string countriesFile;
        private readonly List<string> countries;

        public CountriesProvider()
        {
            countriesFile = "Resources/Countries.txt";
            countries = File.ReadAllLines(countriesFile).ToList();
        }

        public List<string> ReceiveCountries()
        {
            return countries.ToList();
        }
    }
}
