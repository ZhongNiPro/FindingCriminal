using System.Collections.Generic;

namespace FindingCriminal
{
    internal interface IListingProvider
    {
        List<string> GetHeightList();
        List<string> GetWeightList();
        List<string> GetStatusList();
        List<string> GetCountryList();
    }
}
