using System;

namespace Nauka_testy
{
    class Program
    {
        static string wordToDashes(string word)
        {
            string wynik = "";
            for (int i = 0; i < word.Length; i++)
            {
                wynik += "_";
            }
            return wynik;
        }

        static string UpdateDash(string dash, string litera, string rozwiazanie)
        {
            string wynik = "";

            for (int i = 0; i < dash.Length; i++)
            {
                char iks = rozwiazanie[i];
                char litera1 = litera[0];
                bool czy = iks == litera1;
                if (czy)
                {
                    wynik += litera1;
                }
                else
                {
                    wynik += dash[i];
                }

            }
            Console.WriteLine($"nowy do wyswietlenia to {wynik}");
            return wynik;
        }

        static void Main(string[] args)
        {
            string wordToGuess = "Warszawa";
            string hint = "Polska";
            string a = wordToDashes(wordToGuess);
            string notInWord = "";
            int lifeCount = 5;

            while (lifeCount > 0)
            {
                if (a.Equals(wordToGuess))
                    { Console.WriteLine("WD!");
                    break;
                }

                Console.WriteLine($"Haslo: {a} Ilosc pkt. zycia: {lifeCount} Tych nie ma:{notInWord}");
                Console.Write("Podaj litere:");
                
                string litera = Console.ReadLine();

                if (wordToGuess.Contains(litera))
                {
                    // Console.WriteLine("Litera jest !");
                    a = UpdateDash(a, litera, wordToGuess);
                }
                else
                {
                    lifeCount -= 1;
                    Console.WriteLine("Litera nie ma litera !");
                    notInWord += litera;
                }
            }
        }
    }
}
