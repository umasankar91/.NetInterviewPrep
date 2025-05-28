using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        /* Easier way to write this
         *     DateTime dt = DateTime.ParseExact(s, "hh:mm:sstt", CultureInfo.InvariantCulture);
                return dt.ToString("HH:mm:ss");
         */


        string[] b = s.Split(":");
        string a = string.Empty;

        if (s.Contains("PM") && !s.StartsWith("12"))
        {
            string newTime = (Convert.ToInt16(b[0]) + 12).ToString();
            a = s.Replace($"{b[0]}:", $"{newTime}:");
        }
        else if (s.Contains("AM") && s.StartsWith("12"))
        {
            a = s.Replace("12:", "00:");
        }
        else
            a = s;

        return a.Substring(0, s.Length - 2);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        // textWriter.WriteLine(result);

        // textWriter.Flush();
        // textWriter.Close();
    }
}
