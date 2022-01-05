using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsMoodAnalyzer
{
    public  class ExceptionTest : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE, EMPTY_MESSAGE,
            NO_SUCH_FIELDS, NO_SUCH_METHOD,
            NO_SUCH_CLASS, OBJECT_CREATION_ISSUE
        }

        //Creating type varible of Exception type
        private readonly ExceptionType type;

        public ExceptionTest(ExceptionType Type, string message) : base(message)
        {
            this.type = Type;
        }

    }
}
