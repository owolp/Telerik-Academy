//04. Print a Deck
//Description
//Write a program that reads a card sign(as a char) from the console and generates and prints all possible cards from a standard deck of 52 cards up to the card with the given sign
//(without the jokers). The cards should be printed using the classical notation(like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
//    The card faces should start from 2 to A.
//    Print each card face in its four possible suits: clubs, diamonds, hearts and spades.
//Input
//    On the only line, you will receive the sign of the card to which, including, you should print the cards in the deck.
//Output
//    The output should follow the format bellow(assume our input is 5): 2 of spades, 2 of clubs, 2 of hearts, 2 of diamonds 3 of spades, 3 of clubs, 3 of hearts, 3 of diamonds...
//5 of spades, 5 of clubs, 5 of hearts, 5 of diamonds
//Constraints
//    The input character will always be a valid card sign.
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace PrintDeck
{
    class PrintDeck

    {
        static void Main()
        {
            string cardSign = Console.ReadLine().ToUpper();
            int length;

            switch (cardSign)
            {
                case "J":
                    length = 11;
                    break;
                case "Q":
                    length = 12;
                    break;
                case "K":
                    length = 13;
                    break;
                case "A":
                    length = 14;
                    break;
                default:
                    length = int.Parse(cardSign);
                    break;
            }


            for (int i = 2; i <= length; i++)
            {
                var answer = "{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds";
                switch (i)
                {
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        Console.WriteLine(answer, i);
                        break;
                    case 11:
                        Console.WriteLine(answer, "J");
                        break;
                    case 12:
                        Console.WriteLine(answer, "Q");
                        break;
                    case 13:
                        Console.WriteLine(answer, "K");
                        break;
                    case 14:
                        Console.WriteLine(answer, "A");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
