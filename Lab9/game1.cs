using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9B
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("****************************");
            Console.WriteLine();
            Console.Write("Menu:");
            Console.WriteLine();
            Console.WriteLine("1. - New Game" +
            Environment.NewLine + "2. - Load Game " +
            Environment.NewLine + "3. - Options" +
            Environment.NewLine + "4. - Quit");
            Console.Write("**************************** \r\n");
            Console.WriteLine();
            Console.Write("Enter a number from the menu ");
            char answer = Console.ReadLine()[0];

            switch (answer)
            {
                case '1':
                    Console.WriteLine("New Game...");
                    break;
                case '2':
                    Console.WriteLine("Loading Game...");
                    break;
                case '3':
                    Console.WriteLine("Options loading...");
                    break;
                case '4':
                    Console.Write("Are you sure you want to quit?(y,n) ");
                    break;
                default:
                    Console.WriteLine("Numbers One to Four Only!!");
                    break;
 


            }

            Console.WriteLine();

            }
    }
}
