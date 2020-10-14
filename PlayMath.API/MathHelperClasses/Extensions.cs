using System.Collections.Generic;

namespace PlayMath.API.MathHelperClasses
{
    public static class Extensions
    {
        public static List<int> PrimeFactors(this int n)
        {
            var factors =  new List<int>();

            for(int i = 1; i <= n; ++i)
            {
                if(n%i == 0)
                {
                    factors.Add(i);
                }
            }

            return factors;
        }
    }
}