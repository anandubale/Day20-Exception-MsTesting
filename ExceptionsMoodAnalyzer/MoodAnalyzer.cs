using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsMoodAnalyzer
{
    public class MoodAnalyzer // class with contructor and method which return some string.
    {
        private string message;

        public MoodAnalyzer(string Message)
        {
            this.message = Message;

        }

        public string AnalyzeMood()
        {
            if (this.message.Contains("Sad"))
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }

    }
}
