using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
    {

        public static object CreateMoodAnalyzer(string className)
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
    }
}
