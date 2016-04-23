using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {

            //prompt for Month of Birth
            Console.Write("In what Month were you born? ");
            string MonthOfBirth = Console.ReadLine();

            //prompt for and read level
            Console.Write("Enter day: ");
            int day = int.Parse(Console.ReadLine());

            //extract the first character of the gamertag
            //char firstLetterOfMonth = MonthOfBirth[0];

            //date and time
            //DateTime dateforbutton = DateTime.Now;
            //dateforbutton = dateforbutton.AddDays(-1);

            //Minus one day
            int minusday = (day -1);
            //Console.WriteLine();

            //print out values
            Console.WriteLine("Your Birthday is " + MonthOfBirth + " " + day);
            //Console.WriteLine("First Letter of Month " + firstLetterOfMonth);
            Console.WriteLine();
            Console.WriteLine("You'll receive an email reminder on " + MonthOfBirth + " " + minusday);
            Console.WriteLine("On the date of " + minusday +" " + MonthOfBirth + " you will receive 20% off!");
            Console.WriteLine();

            //read in csv string
            //Console.Write("Enter Name and percent (Name, Percect): ");
            //string csvString = Console.ReadLine();

            //find comma location
            //int commaLocation = csvString.IndexOf(',');

            //extract name and percent
            //string name = csvString.Substring(0, commaLocation);
            //float percent = float.Parse(csvString.Substring(commaLocation + 1));
            //print name and percent
            //Console.WriteLine("Name: " + name);
            //Console.WriteLine("Percent: " + percent);
            //Console.WriteLine();

            // ask for and get user answer
            //Console.Write("Pick up the shiny thing?(y, n): ");
            //char answer = Console.ReadLine()[0];

            // print appropriate message
            //if (answer == 'y' || answer == 'Y')
            //{
            //Console.WriteLine("You have the shiny object!");

            //}
            //else if (answer == 'n' || answer == 'N')
            // {
            // Console.WriteLine("You don't have a shiny object!");
            //}
            //else
            //{
            //Console.WriteLine("You are a n00b");
            //}
              
            //Console.WriteLine();

            //ask for and get user answer
            //Console.Write("Pick up the shiny thing? (y, n): ");
            //char answer = Console.ReadLine()[0];

            //print appropriate message
            //switch (answer)
            //{
                //case 'y':
                //case 'Y':
                   // Console.WriteLine("You have the shiny thing!");
                   // break;
               // case 'n':
                //case 'N':
                    //Console.WriteLine("You don't have the shiny thing!");
                    //break;
                //default:
                   // Console.WriteLine("You're a n00b");
                    //break;
           // }

               // Console.WriteLine();

        }
    }
}
