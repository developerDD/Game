using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        class Karta : IComparable<Karta>
        {
            public string velu { set; get; }
            public string mast { set; get; }

            public int ves { set; get; }

            public Karta(string vel, string _mast, int _ves)
            {
                velu = vel;
                mast = _mast;
                ves = _ves;
            }

            public int CompareTo(Karta obj)
            {
                if (this.ves > obj.ves)
                {
                    return 1;
                }
                if (this.ves < obj.ves)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        class KolodaKard
        {
            public List<Karta> koloda { set; get; }
            string[] mas = { "чирва", "буба", "креста", "пика" };
            string[] mas1 = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            public KolodaKard()
            {
                koloda = new List<Karta>(36);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < mas1.Length; j++)
                    {
                        koloda.Add(new Karta(mas1[j], mas[i], j));
                    }
                }
                Rend_koloda();
            }
            void Rend_koloda()
            {
                Random rnd = new Random();
                for (int i = 0; i < koloda.Count; i++)
                {
                    Karta t = koloda[0];
                    koloda.RemoveAt(0);
                    koloda.Insert(rnd.Next(koloda.Count), t);
                }
            }
        }

        class Playr
        {
            public List<Karta> kartu { set; get; }

            public Playr()
            {
                kartu = new List<Karta>();
            }

            public int Srav(Playr obj)
            {
                return this.kartu[0].CompareTo(obj.kartu[0]);
            }

        }

        static void Main(string[] args)
        {
            KolodaKard k = new KolodaKard();
            Playr dima = new Playr();
            for (int i = 0; i < 12; i++)
            {
                dima.kartu.Add(k.koloda[i]);
            }



            foreach (var item in dima.kartu)
            {
                Console.WriteLine(item.mast + " " + item.velu + " " + item.ves);
            }


        }
    }

}