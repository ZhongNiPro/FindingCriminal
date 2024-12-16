using System;

namespace FindingCriminal
{
    // метод Марсальи, магические числа и переменные из математики 
    class NormalRandom : Random
    {
        public double PreviousSample { get; private set; } = double.NaN;

        protected override double Sample()
        {
            if (double.IsNaN(PreviousSample) == false)
            {
                double result = PreviousSample;
                PreviousSample = double.NaN;

                return result;
            }

            double u, v, s;

            do
            {
                u = 2 * base.Sample() - 1;
                v = 2 * base.Sample() - 1;
                s = u * u + v * v;
            }
            while (u <= -1 || v <= -1 || s >= 1 || s == 0);

            double r = Math.Sqrt(-2 * Math.Log(s) / s);

            PreviousSample = r * v;

            return r * u;
        }
    }
}
