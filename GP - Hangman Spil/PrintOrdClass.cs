using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP___Hangman_Spil
{
    internal class PrintOrdClass
    {
        ///Metoden her udskriver bogstaverne som man har gættet rigtigt.
        ///Hvis man ikke gætter et bogstav som er i ordet så udskrives der ingenting.
       public static int PrintOrd(List<char> gættedeBogstaver, string tilfældigtOrd)
        {
            int tæller = 0;
            int rigtigeBogstaver = 0;
            Console.Write("\r\n");
            ///foreach som tjekker karaktere i ordet som man skal gætte.
            foreach (char c in tilfældigtOrd)
            {
                //Hvis man gætter rigtigt indsætter den et bogstav.
                if (gættedeBogstaver.Contains(c))
                {
                    Console.Write(c + " ");
                    rigtigeBogstaver++;
                }
                //Hvis man gætter forkert så indsætter den noget blankt.
                else
                {
                    Console.Write(" ");
                }
                tæller++;
            }
            return rigtigeBogstaver;
        }
    }
}
