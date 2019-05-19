using System;

namespace ModelGRY
{
    public class Gra
    {
        //inner types
        public enum odpowiedz {ZaMalo = -1, Trafiono = 0, ZaDuzo = 1};
        public enum State { Trwa, Poddana, Odgadnieta};
        //pola
        public State StanGry { get;private set; }
        public readonly int zakresOd, zakresDo;
        private readonly int wylosowana;
        //historia gry
        public int licznikruchow { get; private set; }=0;

        public int? Wylosowana
        {
            get
            {
                //IF gra poddana lub zakonczona
                if (StanGry != State.Trwa)
                    return wylosowana;
                else
                    return null;
            }
            //set{}
        }


        //konstruktory
        public Gra(int a, int b)
        {
            zakresOd = Math.Min(a,b);
            zakresDo = Math.Max(b,a);
            wylosowana = Losuj(zakresOd, zakresDo);
            StanGry = State.Trwa;
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

        public odpowiedz Ocena(int propozycja)
        {
            licznikruchow++;
            if (propozycja < wylosowana)
                return odpowiedz.ZaMalo;
            else if (propozycja > wylosowana)
                return odpowiedz.ZaDuzo;
            else
            {
                StanGry = State.Odgadnieta;
                return odpowiedz.Trafiono;
            }
            
        }

        public void Poddaj()
        {
            StanGry = State.Poddana;
        }

    }
}
