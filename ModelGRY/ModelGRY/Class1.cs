using System;

namespace ModelGRY
{
    public class Gra
    {
        //pola
        int zakresOd, zakresDo;
        int wylosowana;
        //historia gry

        //konstruktory
        public Gra(int a, int b)
        {
            zakresOd = Math.Min(a,b);
            zakresDo = Math.Max(b,a);
            wylosowana = Losuj(zakresOd, zakresDo);
        }
        //losowanie
        public static int Losuj(int min = 1, int max = 100)
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
    }
}
