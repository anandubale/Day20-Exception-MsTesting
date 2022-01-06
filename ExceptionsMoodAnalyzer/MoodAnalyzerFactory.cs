using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;


namespace ExceptionsMoodAnalyzer
{
    public class MoodAnalyzerFactory
    {   
        public static object CreateMoodAnalyse(String ClassName, String constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(ClassName, pattern);


            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyzeType = executing.GetType(ClassName);
                    return Activator.CreateInstance(moodAnalyzeType);

                }
                catch (ArgumentNullException)
                {
                    throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }   
            }
            else
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
            }

            
        }
    }
} 
