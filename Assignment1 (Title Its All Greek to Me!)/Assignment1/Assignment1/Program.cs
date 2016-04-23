using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //pythagorean theorem c^2 = a^2 + b^2
            //thus c = square root(a^2 + b^2)
            Console.Write("Enter");
            float point1X2 = float.Parse(Console.ReadLine());
            Console.WriteLine();

            //float tan = point1X2 * point1X2;

            Console.Write("Enter");
            float point2Y2 = float.Parse(Console.ReadLine());
            Console.WriteLine();

            //float cos = point2Y2 * point2Y2;

            float tan = (float)Math.Sqrt(point1X2 * point1X2 + point2Y2 * point2Y2);

            Console.WriteLine("Answer + ", tan);
        }
    }
}