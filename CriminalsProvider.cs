﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FindingCriminal
{
    internal class CriminalsProvider : ICriminalsProvider
    {
        private readonly string namesFile;
        private readonly string surnamesFile;

        private Random random;
        private NormalRandom normalRandom;

        internal CriminalsProvider()
        {
            namesFile = "Resources/Names.txt";
            surnamesFile = "Resources/Surnames.txt";

            random = new Random();
            normalRandom = new NormalRandom();
        }

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
                bool isPrisoned = random.Next(statesNumber) == 0;
                string name = GetStringValue(names);
                string surname = GetStringValue(surnames, isSurname: true);
                string country = GetStringValue(countries);

                int heightExpectation = 182;
                int height = GetIntNormalRandomValue(heightExpectation);
                int heightWeightRatio = 95;
                int weightExpectation = height - heightWeightRatio;
                int weight = GetIntNormalRandomValue(weightExpectation);

                Criminal criminal = new Criminal($"{textInfo.ToTitleCase(name)} {textInfo.ToTitleCase(surname)}", country, height, weight, isPrisoned);

                criminals.Add(criminal);
            }

            return criminals;
        }

        private string GetStringValue(List<string> list, bool isSurname = false)
        {
            string value = list[random.Next(list.Count)];

            if (isSurname == true && value.Last() == 'a')
            {
                value = value.Remove(value.Length - 1);
            }

            return value;
        }

        private int GetIntNormalRandomValue(int expectation)
        {
            int deviation = 12;

            double value = normalRandom.NextDouble() * deviation + expectation;

            return (int)value;
        }
    }
}
