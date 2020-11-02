using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayMath.API.MathHelperClasses
{
    public static class Extensions
    {
        public static List<int> PrimeFactors(this int n)
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
            // Initialize the return value
            int mode = default(int);
            // Test for a null reference and an empty list
            if (list != null && list.Count() > 0)
            {
                // Store the number of occurences for each element
                Dictionary<int, int> counts = new Dictionary<int, int>();
                // Add one to the count for the occurence of a character
                foreach (int element in list)
                {
                    if (counts.ContainsKey(element))
                        counts[element]++;
                    else
                        counts.Add(element, 1);
                }
                // Loop through the counts of each element and find the 
                // element that occurred most often
                int max = 0;
                foreach (KeyValuePair<int, int> count in counts)
                {
                    if (count.Value > max)
                    {
                        // Update the mode
                        mode = count.Key;
                        max = count.Value;
                    }
                }
            }
            return mode;
        }
    }
}