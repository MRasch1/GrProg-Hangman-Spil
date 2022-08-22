using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using GP___Hangman_Spil;

namespace Hangman_Spil
{
    class Program
    {
        /// Et program til at spille Hangman. 
        // 20-08-2022.
        //22-08-2022: Ændret variabler så de starter med småt. Lavet klasser til metoderne.

        static void Main(string[] args)
        {
            //Velkomst besked.
            Console.WriteLine("Velkommen til Hangman");
            Console.WriteLine("----------------------");

            Random random = new Random();
            ///Denne linje indeholder ordene som man skal gætte i spillet.
            ///Det er tilfældigt hvilket af ordene man får
            List<string> ordbog = new List<string> { "banan", "vandmelon", "jordbær", "brandbil", "politibil", "vandmand", "gorilla", "giraf" };
            //Denne linje sørger for at vælge et tilfældigt ord i ordbogen.
            int index = random.Next(ordbog.Count);
            string tilfældigtOrd = ordbog[index];
            //For hver karakter i det tilfældige ord så kommer der en tom linje.
            foreach (char x in tilfældigtOrd)
            {
                Console.Write("_ ");
            }

            int længdenAfOrdetSomSkalGættes = tilfældigtOrd.Length;
            int antalGangeForkert = 0;
            //Dette er til at huske hvilke bogstaver man har indtastet.
            List<char> nuværendeGættedeBogstaver = new List<char>();
            int nuværendeBogstaverRigtige = 0;

            while(antalGangeForkert != 6 && nuværendeBogstaverRigtige != længdenAfOrdetSomSkalGættes)
            {
                //En liste med de bogstaver som man har gættet i forvejen.
                Console.Write("\nBogstaver som er gættet indtil videre: ");
                foreach(char bogstav in nuværendeGættedeBogstaver)
                {
                    Console.Write(bogstav + " ");
                }
                //Spørger bruger om input.
                Console.Write("\nGæt et bogstav: ");
                char bogstavGættet = Console.ReadLine()[0];
                //Tjekker om bogstavet er allerede gættet
                if (nuværendeGættedeBogstaver.Contains(bogstavGættet))
                {
                    Console.Write("\r\nDu har allerede gættet dette bogstav.");
                    PrintHangmanClass.PrintHangman(antalGangeForkert);
                    nuværendeBogstaverRigtige = PrintOrdClass.PrintOrd(nuværendeGættedeBogstaver, tilfældigtOrd);
                    PrintLinjerClass.PrintLinjer(tilfældigtOrd);
                }
                else
                {
                    //Tjekker om bogstav er i ordet
                    bool rigtig = false;
                    for (int i = 0; i < tilfældigtOrd.Length; i++)
                    {
                        if (bogstavGættet == tilfældigtOrd[i])
                        { 
                            rigtig = true; 
                        }
                    }
                    ///Hvis man gætter rigtigt så udskriver den de bogstaver som man har gættet rigtigt.
                    ///Der bliver også vist den hængende mand.
                    ///Og der kommer linjer under de rigtige ord.
                    if (rigtig)
                    {
                        PrintHangmanClass.PrintHangman(antalGangeForkert);
                        nuværendeGættedeBogstaver.Add(bogstavGættet);
                        nuværendeBogstaverRigtige = PrintOrdClass.PrintOrd(nuværendeGættedeBogstaver, tilfældigtOrd);
                        Console.Write("\r\n");
                        PrintLinjerClass.PrintLinjer(tilfældigtOrd);
                    }
                    ///Hvis man gætter forkert kommer den hængende mand tættere på at blive fuldendt.
                    ///Der bliver også printet de andre ting så det er nemmere at følge med hvor langt man er nået
                    ///i spillet.
                    else
                    {
                        antalGangeForkert++;
                        nuværendeGættedeBogstaver.Add(bogstavGættet);
                        PrintHangmanClass.PrintHangman(antalGangeForkert);
                        nuværendeBogstaverRigtige = PrintOrdClass.PrintOrd(nuværendeGættedeBogstaver, tilfældigtOrd);
                        Console.Write("\r\n");
                        PrintLinjerClass.PrintLinjer(tilfældigtOrd);
                    }
                }
            }
            //Når spillet er færdigt får man denne tekst vist.
            Console.WriteLine("\r\nSpillet er ovre! Tak for denne gang");
        }


        

        

        
    }
}