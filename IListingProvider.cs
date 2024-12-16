using System.Collections.Generic;

namespace FindingCriminal
{
    internal interface IListingProvider
    {
        List<string> GetNumberList(int firstValue, int lastValue);
        List<string> GetStatusList();
        List<string> GetCountryList();
    }
}
