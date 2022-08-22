using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP___Hangman_Spil
{
    internal class PrintHangmanClass
    {
         public static void PrintHangman(int forkert)
        ///Denne her metode er til at printe den hængende mand ud 
        ///Jo mere forkert man er jo mere af ham bliver printet ud.
        {
            if (forkert == 0)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     ");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (forkert == 1)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (forkert == 2)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|     |");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (forkert == 3)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|    /|");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (forkert == 4)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|    /|\\");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (forkert == 5)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|    /|\\");
                Console.WriteLine("|    /");
                Console.WriteLine("====");
            }
            //Hele manden er nu tilstede.
            else if (forkert == 6)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|    /|\\");
                Console.WriteLine("|    / \\");
                Console.WriteLine("====");
            }
        }
    }
}
