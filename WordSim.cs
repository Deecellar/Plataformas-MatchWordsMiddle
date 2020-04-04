namespace Plataformas
{
    public class WordSim
    {
        public double PercentageOfSimilitude { get; set; }
        public bool IsBetweenWords { get; set; }
        public string Word { get; set; }
        public int IndexOfWord { get; set; }
        public WordSim(string word)
        {
            Word = word;
            IsBetweenWords = false;
            PercentageOfSimilitude = 0;
        }
    }
}