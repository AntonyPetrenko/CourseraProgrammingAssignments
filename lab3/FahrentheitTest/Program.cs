using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrentheitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conversion from Fahrenheit to Celsius
            Console.Write("Enter temperature (Fahrenheit): ");
            float OriginalFahrenheit = float.Parse(Console.ReadLine());
            Console.WriteLine();

            //Conversion formula from Fahrenheit to Celsius
            float FahrenheitConvertedToCelsius = ((OriginalFahrenheit - 32) * 5) / 9;
            Console.Write("{1} Degrees Fahrenheit is {0} Celsius degrees. ", FahrenheitConvertedToCelsius, OriginalFahrenheit);
            Console.WriteLine();

            //Conversion from Celsius to Fahrenheit
            float CelsiusToFahrenheit = ((FahrenheitConvertedToCelsius * 9) / 5) + 32;
            Console.Write("{1} Degrees Celsius is {0} degrees Fahrenheit. \r\n", CelsiusToFahrenheit, FahrenheitConvertedToCelsius);
            Console.WriteLine();
        }
    }
}