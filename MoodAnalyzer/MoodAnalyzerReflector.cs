﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class MoodAnalyzerReflector
    {
        public static string Reflector(string methodName, string message)
        {
            try
            {
                //Type type = typeof(MoodAnalyzer.Mood);
                Type type = Type.GetType("MoodAnalyzer.Mood");

                //Mood moodInstance = (Mood)Activator.CreateInstance(type);
                object moodAnalyzerObject = MoodAnalyzerFactory.CreateMoodAnalyzerUsingParameterisedConstructor("MoodAnalyzer.Mood", "Mood", message);

                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodObj = methodInfo.Invoke(moodAnalyzerObject, null);
                return moodObj.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.No_Such_Method, "No Such method found");
            }
        }
    }
}
