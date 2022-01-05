using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionsMoodAnalyzer;

namespace TestProject1ExceptionMoodAnalyzer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSadMoodShouldReturnSad()
        {
            //Arrange
            string expected = "HAPPY"; //
            string message = "I am in Happy Mood";
            MoodAnalyzer moodAnalyze = new MoodAnalyzer(message); //create instance or object of that class.


            //Act
            string mood = moodAnalyze.AnalyzeMood();   //calling of method using instance 

            //Assert
            Assert.AreEqual(expected, mood);   //check if expected == output of method of class  


        }
    }
}
