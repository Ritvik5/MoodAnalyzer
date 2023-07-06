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

        //TestCase2.1 -- Null mood Exception
        //[TestMethod]
        //public void GivenNullMood_ShouldReturn_Happy()
        //{
        //    //Arrange
        //    string input = null;
        //    Mood mood = new Mood(input);

        //    //Act
        //    string result = mood.AnalyzeMood();

        //    //Assert
        //    Assert.AreEqual("HAPPY", result);
        //}

        //TestCase3.1 -- Custom Exception
        [TestMethod]
        public void GivenEmptyMood_ShouldThrow_Exception()
        {
            try
            {
                string message = "";
                Mood moodAnalyse = new Mood(message);
                string mood = moodAnalyse.AnalyzeMood();
            }
            catch (MoodAnalyzerCustomException exeption)
            {
                Assert.AreEqual("Mood should not be empty", exeption.Message);
            }
        }

        [TestMethod]
        public void GivenNullMood_ShouldThrow_Exception()
        {
            try
            {
                string message = null;
                Mood moodAnalyse = new Mood(message);
                string mood = moodAnalyse.AnalyzeMood();
            }
            catch (MoodAnalyzerCustomException exeption)
            {
                Assert.AreEqual("Mood should not be null", exeption.Message);
            }
        }

        //--TetsCase4.1 -- Checking object
        [TestMethod]
        public void GivenMoodClassName_ShouldReturn_MoodObject()
        {
            //Arrange
            object expected = new Mood();

            //Act
            object result = MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyzer.Mood","Mood");

            //Assert
            expected.Equals(result);
        }

        //TestCase4.2 --Wrong class name
        [TestMethod]
        public void GivenImproperClassName_ShouldThrow_MoodAnalyzerCustomException()
        {
            string expected = "Class  Not Found";
            try
            {
                object result = MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyzer.Wmood", "Mood");
            }
            catch (MoodAnalyzerCustomException exception)
            {

                Assert.AreEqual(expected, exception.Message);
            }
        }

        //TestCase4.2 --Wrong class name
        [TestMethod]
        public void GivenImproperConstructorName_ShouldThrow_MoodAnalyzerCustomException()
        {
            string expected = "Constructor not found";
            try
            {
                object result = MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyzer.Mood", "WMood");
            }
            catch (MoodAnalyzerCustomException exception)
            {

                Assert.AreEqual(expected, exception.Message);
            }
        }
        [TestMethod]
        public void GivenMoodClassName_ShouldReturnMoodObject_UsingParameterisedConstructor()
        {
            //Arrange
            object expected = new Mood("HAPPY");

            //Act
            object result = MoodAnalyzerFactory.CreateMoodAnalyzerUsingParameterisedConstructor("MoodAnalyzer.Mood", "Mood", "HAPPY");

            //Assert
            expected.Equals(result);
        }
    }
}