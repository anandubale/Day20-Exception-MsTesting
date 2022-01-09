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
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }


        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalysers");
                object moodAnalyserObject = MoodAnalyzerFactory.CreateMoodAnalyzerWithParameterizedConstructor("MoodAnalyser.MoodAnalysers", "MoodAnalysers", message);
                MethodInfo AnalseMoodInfo = type.GetMethod(methodName);
                object mood = AnalseMoodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }


        //UC 5

        public static object CreateMoodAnalyzerWithParameterizedConstructor(string Classname,string ConstructorName,string message)
        {

            Type type = typeof(MoodAnalyzer);
            if(type.Name.Equals(Classname) || type.FullName.Equals(Classname))
            {
                if (type.Name.Equals(ConstructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    Object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");

                }
            }
            else
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_CLASS, "Class Not Found");

            }


        }












        
    }
} 
