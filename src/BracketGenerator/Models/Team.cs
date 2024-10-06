namespace BracketGenerator.Models
{
    public class Team
    {
        public string Name { get; set; }
        public int Seed { get; set; }
        public int Points { get; set; }

        public Team(string name, int seed)
        {
            Name = name;
            Seed = seed;
            Points = 0;
        }

        public string Print()
        {
            return "Team : " + Name + " & Seed : " + Seed + " & Points : " + Points;
        }
    }
}