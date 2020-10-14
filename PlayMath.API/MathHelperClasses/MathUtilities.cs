using System;
using System.Linq;

namespace PlayMath.API.MathHelperClasses
{
    public static class MathUtilities
    {
        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }
    }
}