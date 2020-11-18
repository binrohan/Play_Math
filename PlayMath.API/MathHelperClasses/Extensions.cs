using System;
using System.Collections.Generic;
using System.Linq;
using PlayMath.API.Dtos.PreAlgebraDtos;

namespace PlayMath.API.MathHelperClasses
{
    public static class Extensions
    {
        public static List<int> Divisors(this int n)
        {
            var factors =  new List<int>();

            n = Math.Abs(n);

            for(int i = 1; i <= n; ++i)
            {
                if(n%i == 0)
                {
                    factors.Add(i);
                }
            }

            return factors;
        }

        public static int GetMode(this IEnumerable<int> list)
        {
            int mode = default(int);
            
            if (list != null && list.Count() > 0)
            {
                
                Dictionary<int, int> counts = new Dictionary<int, int>();
                
                foreach (int element in list)
                {
                    if (counts.ContainsKey(element))
                        counts[element]++;
                    else
                        counts.Add(element, 1);
                }
                
                int max = 0;
                foreach (KeyValuePair<int, int> count in counts)
                {
                    if (count.Value > max)
                    {
                        mode = count.Key;
                        max = count.Value;
                    }
                }
            }
            return mode;
        }

        public static List<int> PrimeFactors(this int number)
        {
            var primes = new List<int>();

            for(int div = 2; div<=number; div++){

                while(number%div==0){

                    primes.Add(div);
                    number = number / div;
                }
            }
            return primes;
        }
    }
}