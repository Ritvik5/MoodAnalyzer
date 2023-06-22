using MoodAnalyzer;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly MoodAnalyzer.Mood mood;

        public UnitTest1()
        {
            mood = new MoodAnalyzer.Mood();
        }
        //TestCase1.1 --- Return Sad
        [TestMethod]
        public void Given_Mood_Sad_Should_Return_Sad()
        {
            //Arrange
            string expectectResult = "Sad";

            //Act
            string result = mood.AnalyzeMood("I am in sad Mood");

            //Assert
            Assert.AreEqual(expectectResult,result);

        }

        [TestMethod]
        public void Given_Mood_Happy_Should_Return_Happy()
        {
            string expectedresult = "Happy";

            string result = mood.AnalyzeMood("I am in Happy Mood");

            Assert.AreEqual(expectedresult,result);
        }
    }
}