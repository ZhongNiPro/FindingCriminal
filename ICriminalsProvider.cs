using System.Collections.Generic;

namespace FindingCriminal
{
    internal interface ICriminalsProvider
    {
         List<Criminal> CreateCriminals();
    }
}
