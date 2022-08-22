using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP___Hangman_Spil
{
    internal class PrintLinjerClass
    {
        ///Denne metode er til at sætte linjer under de bogstaver man har gættet.
        public static void PrintLinjer(string tilfældigtOrd)
        {
            Console.Write("\r");
            foreach (char c in tilfældigtOrd)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                //Et specialtegn som bliver til en linje under de bogstaver man har gættet korrekt.
                Console.Write("\u0305 ");
            }
        }
    }
}
