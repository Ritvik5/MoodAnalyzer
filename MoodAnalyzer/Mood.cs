using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class Mood
    {
        string message;
        public string className;
        public string constructorName;

        public Mood(string className,string constructorName)
        {
        }
        public Mood() 
        {
        }
        public Mood(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {

            try
            {
                if(this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.EmptyMessage, "Mood should not be empty");
                }
                if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch(NullReferenceException) 
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NullMessage, "Mood should not be null");
            }
        }
    }
}
