﻿using System;
using System.IO;

namespace Hangman_proba
{
    class Program
    {
        static string[] SelectPair()
            // zwraca [] w formacie [panstwo, stolica]
            // TODO: sprawdzic czy plik istnieje przed rozpoczeciem
            // TODO: jakos poprawic trimming
            // TODO: uogolnic sciezke do pliku z danymi
        {
            string filePath = "../../../countries_and_capitals.txt";
            string chosenPairStr = "";
            using (TextReader tr = new StreamReader(filePath))
            {
                Random rnd = new Random();
                var allWords = tr.ReadToEnd().Split(new[] { '\n', '\r', }, StringSplitOptions.RemoveEmptyEntries);
               
                chosenPairStr = allWords[rnd.Next(0, allWords.Length - 1)];
            }
            string[] chosenPair = chosenPairStr.Split('|');
            chosenPair[0] = chosenPair[0].Trim(' ');
            chosenPair[1] = chosenPair[1].Trim(' ');

            return chosenPair;

        }

        static string WordToDashes(string word)
            // zwraca string z "_" zamiast literek
        {
            string result = "";
            for (int i = 0; i < word.Length; i++)
            {
                result += "_";
            }
            return result;
        }

        static string UpdateDash(string dash, string litera, string solution)
            // zwraca 'zadashowany' string uzupelniony o podana litere
        {
            string result = "";
            char letter = litera.ToLower()[0];

            for (int i = 0; i < dash.Length; i++)
            {
                char x = solution.ToLower()[i];
                if (x == letter)
                {
                    result += solution[i];
                }
                else
                {
                    result += dash[i];
                }
            }

            return result;
        }


        static void Main(string[] args)
        {
            int lifeCount = 5;
            string[] Pair = SelectPair();
            string toGuess = Pair[1];
            string toGuessDashed = WordToDashes(toGuess);
            string toGuessHint = Pair[0];
            string notInWord = "";

            while (lifeCount > 0)
            {
                Console.WriteLine($"Haslo: {toGuessDashed} Pkt. zycia: {lifeCount} Litery ktorych nie ma: [{notInWord}]");
                // Console.WriteLine($"haslo: {toGuess}");
                string choice = "";
                do
                {
                    Console.Write("[1] - zgaduj litere [2] - zgaduj cale haslo Wybor[1/2]: ");

                    choice = Console.ReadLine();
                } while (!(choice.Equals("1") || choice.Equals("2")));

                if (choice.Equals("1"))
                {
                    Console.Write("Podaje litere [wczytuje pierwszy podany znak]:");
                    string letter = Console.ReadLine();
                    if (toGuess.ToLower().Contains(letter.ToLower()))
                    {
                        toGuessDashed = UpdateDash(toGuessDashed, letter, toGuess);
                    }
                    else
                    {
                        lifeCount -= 1;
                        notInWord += letter + ", ";
                    }

                }
                else
                {
                    Console.Write("Podaj slowo:");
                    string word = Console.ReadLine();
                    if (toGuess.ToLower().Equals(word.ToLower()))
                    {
                        break;
                    }
                    else
                    {
                        lifeCount -= 2;
                    }
                }

            }

            if (lifeCount <= 0)
            {
                Console.WriteLine($"Gra przegrana! Szukane haslo to: {toGuess}");
            }
            else
            {
                Console.WriteLine("Gratulacje !");
            }

            
            
        }
    }
}
