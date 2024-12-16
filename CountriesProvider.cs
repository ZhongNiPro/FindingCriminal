using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FindingCriminal
{
    internal class CountriesProvider : ICountriesProvider
    {
        private readonly string _countriesFile;
        private readonly List<string> _countries;

        public CountriesProvider()
        {
            _countriesFile = "Resources/Countries.txt";
            _countries = File.ReadAllLines(_countriesFile).ToList();
        }

        public List<string> ReceiveCountries()
        {
            return _countries.ToList();
        }
    }
}
