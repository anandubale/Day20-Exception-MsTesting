using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsMoodAnalyzer
{
    public class MoodAnalyzer // class with contructor and method which return some string.
    {
        public string message;
       
        public MoodAnalyzer(string Message)
        {
            this.message = Message;

        }   
        //I have added This Constructr to avoid NO paramerterizerd Constrctor.
        public MoodAnalyzer()
        {

        }

        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new ExceptionTest(ExceptionTest.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else if (this.message.Contains("Happy"))
                {
                    return "HAPPY";
                }
                else if (this.message.Contains("Any"))
                {
                    return "HAPPY";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NULL_MESSAGE, "Message should not be null");
            }
        }

    }
}
