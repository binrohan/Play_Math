using System.Collections.Generic;

namespace PlayMath.API.Helpers
{
    public static class Extensions
    {
        public static List<int> PrimeFactorsExcluded(this int n)
        {
            var factors =  new List<int>();

            for(int i = 2; i < n; ++i)
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