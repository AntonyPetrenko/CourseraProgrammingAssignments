using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
	/// <summary>
	/// Demonstrates classes and objects
	/// </summary>
    class Program
    {
		/// <summary>
		/// Demonstrates use of Deck and Card objects
		/// </summary>
		/// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // create a new deck and print the contents of the deck
            Deck deck = new Deck();

            //print deck empty information
            Console.WriteLine("Empty: " + deck.Empty);

            //deck.Print();

            //tell deck to shuffle itself
            //deck.Shuffle();

            //cut the deck
            //deck.Cut(26);

            //take top card and print info
            Card card = deck.TakeTopCard();
            Console.WriteLine(card.Rank + " of " + card.Suit);

            //take another top card and print info
            card = deck.TakeTopCard();
            Console.WriteLine(card.Rank + " of " + card.Suit);

            //Console.WriteLine();
            //deck.Print();

            Console.WriteLine();

            // shuffle the deck and print the contents of the deck

            // take the top card from the deck and print the card rank and suit

            // take the top card from the deck and print the card rank and suit


        }
    }
}
