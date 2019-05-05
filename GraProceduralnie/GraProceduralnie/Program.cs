using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMonolitycznie
{
    class Program
    {
        /// <summary>
        /// Generuje liczbe pseudolosowa z podanego zakresu włącznie z krańcami
        /// </summary>
        /// <param name="min">dowolna liczba całkowita</param>
        /// <param name="max">dowolna liczba calkowita</param>
        ///<returns>liczba calkowita z podanego zakresu</returns>

        static int Losuj(int min = 1, int max = 100)
        {
            Random generator = new Random();
            if (min > max)
            {
                int tmp = min;
                min = max;
                max = tmp;
            }

            return generator.Next(min, max + 1);
        }

        /// <summary>
        /// Wczytaj liczbe z konsoli lub znak X
        /// </summary>
        /// <returns>Liczba całkowita odpowiadająca podanej wartości na konsoli</returns>
        /// <exception cref="OperationCanceledException">gdy wprowadzono 'x' lub 'X'</exception>

        static int WczytajLiczbe(string prompt = "Podaj liczbę (lub X aby zakończyć): ")
        {
            int propozycja = 0;

            while (true)
            {
                Console.Write(prompt);
                string tekst = Console.ReadLine();

                if (tekst.ToLower() == "x")
                    throw new OperationCanceledException("Wprowadzono X");

                try
                {
                    propozycja = Convert.ToInt32(tekst);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie podano liczby! Spróbuj jeszcze raz.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Liczba nie mieści się w rejestrze! Spróbuj jeszcze raz.");
                    continue;
                }
            }

            return propozycja;
        }

        static String Ocena(int propozycja)
        {
            if (propozycja < wylosowana)
                return "za mało";
            else if (propozycja > wylosowana)
                return "za dużo";
            else
                return "trafiono";
        }
        static int wylosowana = 0;

        static void Main(string[] args)
        {
            // 1. Komputer losuje liczbę
            int min = WczytajLiczbe("Podaj zakres - min: ");
            int max = WczytajLiczbe("Podaj zakres - max: ");

            wylosowana = Losuj(min, max);
            Console.WriteLine($"Wylosowana liczba od {min} do {max}. \n Odgadnij jaka");
#if(DEBUG)
            Console.WriteLine(wylosowana);
#endif
            //wykonywanie
            bool trafiono = false;
            do
            {
                int propozycja = 0;
                try
                {
                    propozycja = WczytajLiczbe("Podaj swoja propozycje (lub X aby sie poddac):");
                    Console.WriteLine($"Przyjalem wartosc {propozycja}");
                }
                catch(OperationCanceledException)
                {
                    Console.WriteLine("Koniec");
                    return;
                }

                string wynik = Ocena(propozycja);
                Console.WriteLine(wynik);
                if (wynik == "trafiono")
                {
                    break;
                }
            } while (trafiono!=true);
            Console.WriteLine("Koniec Gry");
        }
    }
}