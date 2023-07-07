using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class MoodAnalyzerCustomException : Exception
    {
        public enum ExceptionType
        {
            NullMessage,
            EmptyMessage,
            No_Such_Class,
            No_Such_Method,
            No_Such_Constructor,
            No_Such_Field,
            Object_Creation_Issue
        }

        private readonly ExceptionType type;

        public MoodAnalyzerCustomException(ExceptionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
}
