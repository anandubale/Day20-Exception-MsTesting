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

        public string AnalyzeMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new ExceptionTest(ExceptionTest.ExceptionType.EMPTY_MESSAGE, "Mood Should not be Empty");
                }
                if (this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NULL_MESSAGE, "Mood Should Not Be NULL");
            }
        }

    }
}
