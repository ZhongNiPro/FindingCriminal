using System.Collections.Generic;

namespace FindingCriminal
{
    internal class ListingProvider : IListingProvider
    {
        public List<string> GetHeightList()
        {
            List<string> heightList = new List<string>() { "<150" };

            int minHeight = 150;
            int maxHeight = 210;

            for (int i = minHeight; i <= maxHeight; i++)
            {
                heightList.Add(i.ToString());
            }

            heightList.Add(">210");

            return heightList;
        }

        public List<string> GetWeightList()
        {
            List<string> weightList = new List<string>() { "<50" };

            int minWeight = 50;
            int maxWeight = 130;

            for (int i = minWeight; i <= maxWeight; i++)
            {
                weightList.Add(i.ToString());
            }

            weightList.Add(">130");

            return weightList;
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
