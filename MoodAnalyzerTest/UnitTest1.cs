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

        //TestCase4.3 --Wrong Constructor name
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
        //TestCase5.1 --Using Parameterised Custructor
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

        //TestCase5.2 --Using Parameterised Custructor passing wrong class name
        [TestMethod]
        public void GivenWrongMoodClassName_ShouldReturnMoodObject_UsingParameterisedConstructor()
        {
            //Arrange
            string expected = "Class  Not Found";

            try
            {
                //Act
                object result = MoodAnalyzerFactory.CreateMoodAnalyzerUsingParameterisedConstructor("MoodAnalyzer.WMood", "Mood", "HAPPY");
            }
            catch(MoodAnalyzerCustomException exception)
            {
                //Assert
                Assert.AreEqual (expected, exception.Message);
            }
        }

        //TestCase5.3 --Using Parameterised Custructor passing wrong constructor name
        [TestMethod]
        public void GivenWrongMoodConstructorName_ShouldReturnMoodObject_UsingParameterisedConstructor()
        {
            //Arrange
            string expected = "Constructor not found";

            try
            {
                //Act
                object result = MoodAnalyzerFactory.CreateMoodAnalyzerUsingParameterisedConstructor("MoodAnalyzer.Mood", "WMood", "HAPPY");
            }
            catch (MoodAnalyzerCustomException exception)
            {
                //Assert
                Assert.AreEqual(expected, exception.Message);
            }
        }

        //TestCase7.1-Given Happy message should return HAPPY mood
        [TestMethod]
        public void GivenHappyMessageUsingReflection_ShouldReturn_HappyMood()
        {
            string result = MoodAnalyzerReflector.Reflector("AnalyzeMood", "I am in Happy Mood");

            Assert.AreEqual("HAPPY", result);
        }

        //TestCase7.2 -- Passing wrong method name
        [TestMethod]
        public void GivenWrongMethodNameUsingReflection_ShouldReturn_NoSuchMethod()
        {
            string expected = "No Such method found";
            try
            {
                string result = MoodAnalyzerReflector.Reflector("Analyze", "I am in Happy Mood");

            }
            catch(MoodAnalyzerCustomException exception)
            {
                //expected.Equals(exception.Message);
                Assert.AreEqual("No Such method found", exception.Message);
            }
            
        }

        //TestCase8.1--Set the Field value
        [TestMethod]
        public void GivenHappyMessageUsingReflector_ShouldReturn_HappyMessage()
        {
            string result = MoodAnalyzerReflector.ChangeMood("message", "I am in Happy Mood");
            Assert.AreEqual("HAPPY", result);
        }

        //TestCase8.2 -- Setting Improper Field Value 
        [TestMethod]
        public void GivenImproperFieldValue_ShouldReturn_NoSuchField()
        {
            string expected = "Field Not Found";
            try
            {
                string result = MoodAnalyzerReflector.ChangeMood("Wmessage", "I am in Happy Mood");
            }
            catch(MoodAnalyzerCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        //TestCase8.2 -- Setting Null Message 
        [TestMethod]
        public void GivenNullMessage_ShouldReturn_NoSuchField()
        {
            string expected = "Message should not be null";
            try
            {
                string result = MoodAnalyzerReflector.ChangeMood("message", null);
            }
            catch (MoodAnalyzerCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}