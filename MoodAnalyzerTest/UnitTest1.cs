using MoodAnalyzer;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Mood mood = new Mood();
            string expectectResult = "Sad";

            //Act
            string result = mood.AnalyzeMood("I am in sad Mood");

            //Assert
            Assert.AreEqual(expectectResult,result);

        }
    }
}