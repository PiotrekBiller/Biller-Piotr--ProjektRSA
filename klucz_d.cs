using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SzyfrowanieRSA
{
    public class klucz_d
    {
        klucz_e e = new klucz_e();
        public int licz_klucz_d(int klucze, int liczba)
        {
            Console.WriteLine("Klucze: {0}, liczba: {1}", klucze, liczba);
            int e1 = klucze;
            int pom = liczba;
            int zmienna_d;
            for (int x = 0; ; x++)
            {

                BigInteger licz = (x * e1) % pom;
                if (licz == 1 && licz > 0)
                {
                    zmienna_d = x;
                    break;
                }
            }

            return zmienna_d;
        }
    }
}
