using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDDTest1.Task.Task_2
{
    public class StringProcessor
    {
        public string ToLowerCase(string input)
        {
            return input?.ToLower();
        }
        public string Sanitize(string input)
        {
            if (string . IsNullOrEmpty(input))
            {
                return input;
            }
            return Regex.Replace(input, "[^a-zA-Z0-9]", "");
        }
        //bool AreEqual(string input1, string input2
        public bool AreEqual(string input1, string input2)
        {
            if (input1 == null || input2 == null)
            {
                return false;
            }
            string sanitized1 = ToLowerCase(Sanitize(input1));
            string sanitized2 = ToLowerCase(Sanitize(input2));
            return sanitized1 == sanitized2;
        }
    }
}
