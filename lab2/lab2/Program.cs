using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Age = 28;

            Console.WriteLine("Age: " + Age);

            Console.WriteLine();
            
            //declare integer variable and constant
            const int MAX_SCORE = 100;
            int score = 45;

            //calculate MAX_SCORE and Score
            float percent = (float) MAX_SCORE / score;
          

            Console.Write("percent:" + percent);
           

            Console.WriteLine();
        }
    }
}
