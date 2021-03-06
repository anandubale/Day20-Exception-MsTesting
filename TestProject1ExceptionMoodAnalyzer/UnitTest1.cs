using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionsMoodAnalyzer;

namespace TestProject1ExceptionMoodAnalyzer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(null)]   //give null input to class(string message ==> null)
        public void GivenSadMoodShouldReturnSad(string message)
        {
            //Arrange

            string expected = "HAPPY"; //
            //string message = "I am in Happy Mood";
            MoodAnalyzer moodAnalyze = new MoodAnalyzer(message); //create instance or object of that class.


            //Act
            string mood = moodAnalyze.AnalyzeMood();   //calling of method using instance 

            //Assert
            Assert.AreEqual(expected, mood);   //check if expected == output of method of class  


        }
        //Test Case 3.2 Given empty Mood should throw MoodException indicating Empty Mood.
        //Given-When-Then
        [TestMethod]
        public void Given_Empty_Should_Throw_MoodAnalysisException_Indication_EmptyMood()
        {

            try
            {
                string message = "";
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
                string mood = moodAnalyzer.AnalyzeMood();

            }
            catch (ExceptionTest e)
            {
                Assert.AreEqual("Mood Should not be Empty", e.Message);
            }
        }
        //it passes expected == e.message

        //Test Case 3.3 Given Null Mood should throw MoodException indicating Null Mood.
        //Given-When-Then
        [TestMethod]
        public void Given_Null_Should_Throw_MoodAnalysisException_Indication_NullMood()
        {

            try
            {
                string message = null;
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
                string mood = moodAnalyzer.AnalyzeMood();

            }
            catch (ExceptionTest e)
            {
                Assert.AreEqual("Mood Should Not Be NULL", e.Message);
            }
        }

        //Test Case 4.1
        [TestMethod]
        public void Given_Mood_Analsis_Class_Name_Should_return_Object()
        {
            string message = null;
            object expected = new MoodAnalyzer(message);
            object obj = MoodAnalyzerFactory.CreateMoodAnalyse("ExceptionsMoodAnalyzer.MoodAnalyzer", "MoodAnalyzer");
            //To check object we have created are same or not

            expected.Equals(obj);


            //NOT CHECKING STRING ARE eQUAL OR NOT 
            //Assert.AreEqual(expected, obj);
        }
        //TestCase 5.1

        [TestMethod]
        public void Given_Mood_Analsis_Class_Name_Should_return_Object_using_Parameterized_Consrtuctor()
        {

            object expected = new MoodAnalyzer("HAPPY");
            object obj = MoodAnalyzerFactory.CreateMoodAnalyzerWithParameterizedConstructor("ExceptionsMoodAnalyzer.MoodAnalyzer", "MoodAnalyzer", "Happy");
            //To check object we have created are same or not

            expected.Equals(obj); 

        }
            
        //TestCase 6.1
        [TestMethod]

        public void GiveHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyzerFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }


        //TestCase 7.1

        [TestMethod]
        public void Given_HAPPYMessag_WithReflector_should_ReturnHAPPY()
        {
            string result = MoodAnalyzerFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }




    }
}
