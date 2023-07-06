using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyzerUsingParameterisedConstructor(string className,string constructorName,string message)
        {
            Type type = typeof(Mood);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo info = type.GetConstructor(new Type[] { typeof(string) });
                    object instance = info.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.No_Such_Class, "Class  Not Found");
                }
            }
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.No_Such_Method, "Constructor not found");
            }
        }

        public static object CreateMoodAnalyzer(string className,string constructorName)
        {
            string apttern = @"."+constructorName+"$";
            Match result = Regex.Match(className, apttern);

            if(result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();

                    Type type = assembly.GetType(className);

                    return Activator.CreateInstance(type);
                }
                catch (ArgumentNullException)
                {

                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.No_Such_Class, "Class  Not Found");
                }
            }
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.No_Such_Method, "Constructor not found");
            }
			
        }
    }
}
