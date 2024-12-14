namespace FindingCriminal
{
    internal class Criminal
    {
        internal Criminal(string name, string nationality, int height, int weight, bool isPrisoned)
        {
            Name = name;
            Nationality = nationality;
            Height = height;
            Weight = weight;
            IsPrisoned = isPrisoned;
        }

        internal string Name { get; private set; }
        internal string Nationality { get; private set; }
        internal int Height { get; private set; }
        internal int Weight { get; private set; }
        internal bool IsPrisoned { get; private set; }
    }
}
