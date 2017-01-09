using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrowanieRSA
{
    class klucz_e
    {
        int p = 557;
        int q = 661;
        public klucz_e()
        {
            zmienna_e = licz_klucz_e();
        }
        public int zmienna_e { get; }
        public int iloczyn_p_q()
        {
            int n = p * q;
            return n;
        }
        public int liczba_p_q()
        {
            int liczba = (p - 1) * (q - 1);
            return liczba;
        }
        public int licz_klucz_e()
        {
            int n = p * q;
            int a = Math.Max(p, q) + 1;
            int b = n - 1;
            int liczba = (p - 1) * (q - 1);
            //liczby pierwsze
            bool isPrime;
            List<int> primeNumbers = new List<int>(new int[] { 2 });
            for (int i = 3; i < 100; i++)
            {
                isPrime = true;
                for (int j = 0; j < primeNumbers.Count; j++)
                    if ((i % primeNumbers[j]) == 0)
                    {
                        isPrime = false;
                        break;
                    }
                if (isPrime) primeNumbers.Add(i);
            }

            int[] pierwsze = new int[primeNumbers.Count];
            primeNumbers.CopyTo(pierwsze);
            //liczymy e
            Random losuj = new Random();
            int zmienna_e;
            for (;;)
            {
                int bb = liczba;
                int z;
                z = losuj.Next(0, pierwsze.Length - 1);
                int zmienna = pierwsze[z];

                while (pierwsze[z] != bb)
                {
                    if (pierwsze[z] > bb)
                        pierwsze[z] -= bb;
                    else
                        bb -= pierwsze[z];
                }
                int zmienna1 = pierwsze[z];

                if (zmienna1 == 1 && zmienna > 1 && zmienna < n)
                {
                    zmienna_e = zmienna;
                    break;
                }
            }
            return zmienna_e;
        }
    }
}
