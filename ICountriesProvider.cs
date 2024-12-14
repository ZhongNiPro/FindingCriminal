using System.Collections.Generic;

namespace FindingCriminal
{
    internal interface ICountriesProvider
    {
        List<string> ReceiveCountries();
    }
}
