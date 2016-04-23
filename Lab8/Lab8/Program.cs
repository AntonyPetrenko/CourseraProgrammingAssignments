using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {

            string textToEnter = "<Pyramid Slot Number><BlockLetter><Whether or not the block should be lit>"; 
            Console.SetCursorPosition((Console.WindowWidth - textToEnter.Length) / 2, Console.CursorTop);
            Console.WriteLine(textToEnter);
            Console.WriteLine("Enter below: Number, BlockLetter and either True or False (example: 15, M, True)");
            string infoString = Console.ReadLine();
            Console.WriteLine();


            //find commaLocation location
            int commaLocation = infoString.IndexOf(',');

            //extract comma location
            string PyramidNumber = infoString.Substring(0, commaLocation);
            string BlockLetter = infoString.Substring(3, commaLocation);
            string TrueOrFalse = infoString.Substring(6);
            Console.WriteLine();

            //print number blockletter and true or false
            Console.WriteLine("Number: " + PyramidNumber);
            Console.WriteLine("BlockLetter: " + BlockLetter);
            Console.WriteLine("Should the block be lit? " + TrueOrFalse);
            Console.WriteLine();
        }
    }
}
