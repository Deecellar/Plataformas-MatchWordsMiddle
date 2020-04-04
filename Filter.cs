using System.Collections.Generic;
using System.Linq;
namespace Plataformas
{
    public class Filter
    {
        public string WordToLookFor { get; set; }
        private JacardIndex jacard;
        public List<WordSim> Matchs { get; set; }

        public Filter(string wordToLookFor)
        {
            WordToLookFor = wordToLookFor;
            jacard = new JacardIndex(2);
            Matchs = new List<WordSim>();
        }

        public void Find(string cadena)
        {

            string[] words = cadena.Split(" ");
            int pos = cadena.Length;
            for (int i = words.Length - 1; i >= 0; i--)
            {
                WordSim temp = new WordSim(words[i]);
                double sim = jacard.Similarity(temp.Word, WordToLookFor);
                pos -= i != 0 ? temp.Word.Length + 1 : temp.Word.Length;

                if ((i - 1) >= 0 && (i + 1) <= words.Length)
                {
                    temp.IsBetweenWords = true;
                }
                temp.PercentageOfSimilitude = sim;
                temp.IndexOfWord = pos + cadena.Substring(pos).IndexOf(temp.Word);
                Matchs.Add(temp);
            }
        }
    }
}