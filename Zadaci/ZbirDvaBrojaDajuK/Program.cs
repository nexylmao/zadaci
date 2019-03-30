using System;
using System.Collections;
using System.Diagnostics;

namespace ZbirDvaBrojaDajuK
{
    public class Resenja
    {
        /*
         * Resenje za pozitivne brojeve
         * Pamtimo da li postoji uopste broj izmedju 0 i zbir.
         * Ukoliko njegov komplement postoji, vratimo true.
         * Ukoliko ne, a on sam nije zapamcen u nizu, onda 
         */
        public static bool PostojiZbir(uint[] niz, uint zbir)
        {
            BitArray counter = new BitArray(new bool[zbir + 1]);
            foreach (var broj in niz)
            {
                if (((int)zbir - broj) < 0)
                {
                    continue;
                }
                
                if (counter[(int)(zbir - broj)])
                {
                    return true;
                }

                if (broj < zbir && !(counter[(int)broj]))
                {
                    counter[(int)broj] = true;
                }
            }

            return false;
        }

        public static bool PostojiZbir(int[] niz, int zbir)
        {
            var min = Int32.MaxValue;
            var max = Int32.MinValue;

            foreach (var broj in niz)
            {
                if (broj < min)
                {
                    min = broj;
                }

                if (broj > max)
                {
                    max = broj;
                }
            }
            
            BitArray counter = new BitArray(new bool[max - min + 1]);
            foreach (var broj in niz)
            {
                if ((zbir - broj) - min < 0)
                {
                    continue;
                }
                
                if (counter[(zbir - broj) - min])
                {
                    return true;
                }

                if (!(counter[broj - min]))
                {
                    counter[broj - min] = true;
                }
            }

            return false;
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            uint[] test1 = {12, 70, 49, 5, 42};
            uint test1zbir = 54;

            stopwatch.Start();

            bool postoji = Resenja.PostojiZbir(test1, test1zbir);
            Console.WriteLine("Da li zbir postoji? => {0}", postoji);
            
            stopwatch.Stop();
            Console.WriteLine("Program executed in {0}ms", stopwatch.Elapsed.Milliseconds);
            
            Console.ReadKey(true);
        }
    }
}