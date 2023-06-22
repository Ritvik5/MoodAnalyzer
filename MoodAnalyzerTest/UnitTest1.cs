using MoodAnalyzer;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        //TestCase1.1 --- Return Sad
        [TestMethod]
        public void Given_Mood_Sad_Should_Return_Sad()
        {
            Mood mood = new Mood("I am in Sad Mood");

            string result = mood.AnalyzeMood();

            Assert.AreEqual("SAD", result);
        }

        //TestCase1.2 --- Return Happy
        [TestMethod]
        public void Given_Mood_Happy_Should_Return_Happy()
        {
            Mood mood = new Mood("I am in Happy Mood");


            string result = mood.AnalyzeMood();

            Assert.AreEqual("HAPPY", result);
        }
    }
}