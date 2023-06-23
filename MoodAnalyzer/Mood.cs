﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class Mood
    {
        string message;
        public Mood(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {

            try
            {
                if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch(Exception) 
            {
                return "HAPPY";
            }
        }
    }
}
