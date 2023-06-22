namespace MoodAnalyzer
{
    public class Program
    {
        public static string Happy_Mood = "I am in Happy Mood";
        public static string Sad_Mood = "I am in Sad Mood";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer \n");

            Mood moodSad = new Mood(Sad_Mood);
            moodSad.AnalyzeMood();
        }
    }
}