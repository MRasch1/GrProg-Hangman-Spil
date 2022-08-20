using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;


namespace Hangman_Spil
{
    class Program
    {
        /// Et program til at spille Hangman. 
        // 20-08-2022.

        static void Main(string[] args)
        {
            //Velkomst besked.
            Console.WriteLine("Velkommen til Hangman");
            Console.WriteLine("----------------------");

            Random random = new Random();
            ///Denne linje indeholder ordene som man skal gætte i spillet.
            ///Det er tilfældigt hvilket af ordene man får
            List<string> Ordbog = new List<string> { "banan", "vandmelon", "jordbær", "brandbil", "politibil", "vandmand", "gorilla", "giraf" };
            //Denne linje sørger for at vælge et tilfældigt ord i ordbogen.
            int index = random.Next(Ordbog.Count);
            string TilfældigtOrd = Ordbog[index];
            //For hver karakter i det tilfældige ord så kommer der en tom linje.
            foreach (char x in TilfældigtOrd)
            {
                Console.Write("_ ");
            }

            int LængdenAfOrdetSomSkalGættes = TilfældigtOrd.Length;
            int AntalGangeForkert = 0;
            //Dette er til at huske hvilke bogstaver man har indtastet.
            List<char> NuværendeGættedeBogstaver = new List<char>();
            int NuværendeBogstaverRigtige = 0;

            while(AntalGangeForkert != 6 && NuværendeBogstaverRigtige != LængdenAfOrdetSomSkalGættes)
            {
                //En liste med de bogstaver som man har gættet i forvejen.
                Console.Write("\nBogstaver som er gættet indtil videre: ");
                foreach(char Bogstav in NuværendeGættedeBogstaver)
                {
                    Console.Write(Bogstav + " ");
                }
                //Spørger bruger om input.
                Console.Write("\nGæt et bogstav: ");
                char BogstavGættet = Console.ReadLine()[0];
                //Tjekker om bogstavet er allerede gættet
                if (NuværendeGættedeBogstaver.Contains(BogstavGættet))
                {
                    Console.Write("\r\nDu har allerede gættet dette bogstav.");
                    PrintHangman(AntalGangeForkert);
                    NuværendeBogstaverRigtige = PrintOrd(NuværendeGættedeBogstaver, TilfældigtOrd);
                    PrintLinjer(TilfældigtOrd);
                }
                else
                {
                    //Tjekker om bogstav er i ordet
                    bool rigtig = false;
                    for (int i = 0; i < TilfældigtOrd.Length; i++)
                    {
                        if (BogstavGættet == TilfældigtOrd[i])
                        { 
                            rigtig = true; 
                        }
                    }
                    ///Hvis man gætter rigtigt så udskriver den de bogstaver som man har gættet rigtigt.
                    ///Der bliver også vist den hængende mand.
                    ///Og der kommer linjer under de rigtige ord.
                    if (rigtig)
                    {
                        PrintHangman(AntalGangeForkert);
                        NuværendeGættedeBogstaver.Add(BogstavGættet);
                        NuværendeBogstaverRigtige = PrintOrd(NuværendeGættedeBogstaver, TilfældigtOrd);
                        Console.Write("\r\n");
                        PrintLinjer(TilfældigtOrd);
                    }
                    ///Hvis man gætter forkert kommer den hængende mand tættere på at blive fuldendt.
                    ///Der bliver også printet de andre ting så det er nemmere at følge med hvor langt man er nået
                    ///i spillet.
                    else
                    {
                        AntalGangeForkert++;
                        NuværendeGættedeBogstaver.Add(BogstavGættet);
                        PrintHangman(AntalGangeForkert);
                        NuværendeBogstaverRigtige = PrintOrd(NuværendeGættedeBogstaver, TilfældigtOrd);
                        Console.Write("\r\n");
                        PrintLinjer(TilfældigtOrd);
                    }
                }
            }
            //Når spillet er færdigt får man denne tekst vist.
            Console.WriteLine("\r\nSpillet er ovre! Tak for denne gang");
        }


        ///Metoden her udskriver bogstaverne som man har gættet rigtigt.
        ///Hvis man ikke gætter et bogstav som er i ordet så udskrives der ingenting.
        static int PrintOrd(List<char>GættedeBogstaver, string TilfældigtOrd)
        {
            int Tæller = 0;
            int RigtigeBogstaver = 0;
            Console.Write("\r\n");
            ///foreach som tjekker karaktere i ordet som man skal gætte.
            foreach(char c in TilfældigtOrd)
            {
                //Hvis man gætter rigtigt indsætter den et bogstav.
                if (GættedeBogstaver.Contains(c))
                {
                    Console.Write(c + " ");
                    RigtigeBogstaver++;
                }
                //Hvis man gætter forkert så indsætter den noget blankt.
                else
                {
                    Console.Write(" ");
                }
                Tæller++;
            }
            return RigtigeBogstaver;
        }

        ///Denne metode er til at sætte linjer under de bogstaver man har gættet.
        static void PrintLinjer(string TilfældigtOrd)
        {
            Console.Write("\r");
            foreach (char c in TilfældigtOrd)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                //Et specialtegn som bliver til en linje under de bogstaver man har gættet korrekt.
                Console.Write("\u0305 ");
            }
        }

        static void PrintHangman(int Forkert)
            ///Denne her metode er til at printe den hængende mand ud 
            ///Jo mere forkert man er jo mere af ham bliver printet ud.
        {
            if (Forkert == 0)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     ");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (Forkert == 1)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (Forkert == 2)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|     |");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (Forkert == 3)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|    /|");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (Forkert == 4)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|    /|\\");
                Console.WriteLine("|");
                Console.WriteLine("====");
            }
            else if (Forkert == 5)
            {
                Console.WriteLine("\n+-----+");
                Console.WriteLine("|     0");
                Console.WriteLine("|    /|\\");
                Console.WriteLine("|    /");
                Console.WriteLine("====");
            }
            //Hele manden er nu tilstede.
            else if (Forkert == 6)
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