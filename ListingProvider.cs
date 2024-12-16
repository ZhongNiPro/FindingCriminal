using System.Collections.Generic;

namespace FindingCriminal
{
    internal class ListingProvider : IListingProvider
    {
        public List<string> GetNumberList(int firstValue, int lastValue)
        {
            List<string> valueList = new List<string>() { "<" + firstValue };

            for (int i = firstValue; i <= lastValue; i++)
            {
                valueList.Add(i.ToString());
            }

            valueList.Add(">" + lastValue);

            return valueList;
        }

        public List<string> GetStatusList()
        {
            List<string> statusList = new List<string>() { "free", "prisoned", "all" };

            return statusList;
        }
        public List<string> GetCountryList()
        {
            ICountriesProvider countries = new CountriesProvider();

            List<string> countriesList = new List<string>() { "all" };

            foreach (var country in countries.ReceiveCountries())
            {
                countriesList.Add(country);
            }

            return countriesList;
        }
    }
}
