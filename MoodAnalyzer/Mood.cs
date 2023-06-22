using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class Mood
    {
        public string AnalyzeMood(string mood)
        {
            if (mood.ToLower().Contains("sad"))
            {
                Console.WriteLine("Sad");
                return "Sad";
            }
            else
            {
                Console.WriteLine("Happy");
                return "Happy";
            }
        }
    }
}
