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
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_METHOD, "Constructor is not Found");
                }
            }
            else
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_CLASS, "Class Not Found ");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalysers");
                object moodAnalyserObject = MoodAnalyzerFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalysers", "MoodAnalysers", message);
                MethodInfo AnalseMoodInfo = type.GetMethod(methodName);
                object mood = AnalseMoodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyzer MoodAnalysers = new MoodAnalyzer();
                Type type = typeof(MoodAnalyzer);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_FIELDS, "Message should not be null");
                }
                field.SetValue(MoodAnalysers, message);
                return message;
            }
            catch (NullReferenceException)
            {
                throw new ExceptionTest(ExceptionTest.ExceptionType.NO_SUCH_FIELDS, "Field is Not Found");
            }

        }
    }



}








        
    

