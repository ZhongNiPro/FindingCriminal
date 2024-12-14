using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FindingCriminal
{
    internal class CriminalsProvider : ICriminalsProvider
    {
        private static Random s_random = new Random();
        private static NormalRandom s_normalRandom = new NormalRandom();

        private static readonly string namesFile = "Resources/Names.txt";
        private static readonly string surnamesFile = "Resources/Surnames.txt";

        public List<Criminal> CreateCriminals()
        {
            List<Criminal> criminals = new List<Criminal>();
            ICountriesProvider countriesProvider = new CountriesProvider();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            List<string> names = File.ReadAllLines(namesFile).ToList();
            List<string> surnames = File.ReadAllLines(surnamesFile).ToList();
            List<string> countries = countriesProvider.ReceiveCountries();

            int limitRecords = 1000;
            int statesNumber = 2;

            for (int i = 0; i < limitRecords; i++)
            {
                bool isPrisoned = s_random.Next(statesNumber) == 0;
                string name = GetStringValue(names);
                string surname = GetStringValue(surnames, isSurname: true);
                string country = GetStringValue(countries);

                int heightExpectation = 182;
                int height = GetIntValue(heightExpectation);
                int heightWeightRatio = 95;
                int weightExpectation = height - heightWeightRatio;
                int weight = GetIntValue(weightExpectation);

                Criminal criminal = new Criminal($"{textInfo.ToTitleCase(name)} {textInfo.ToTitleCase(surname)}", country, height, weight, isPrisoned);

                criminals.Add(criminal);
            }

            return criminals;
        }

        private string GetStringValue(List<string> list, bool isSurname = false)
        {
            string value = list[s_random.Next(list.Count)];

            if (isSurname == true && value.Last() == 'a')
            {
                value = value.Remove(value.Length - 1);
            }

            return value;
        }

        private int GetIntValue(int expectation)
        {
            int deviation = 12;

            double value = s_normalRandom.NextDouble() * deviation + expectation;

            return (int)value;
        }
    }
}
