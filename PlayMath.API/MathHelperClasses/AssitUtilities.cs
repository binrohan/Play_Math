using System.Collections.Generic;
using PlayMath.API.models.MathModel;

namespace PlayMath.API.MathHelperClasses
{
    public static class AssitUtilities
    {
        public static int[] MidTermFactorPair(List<int> factors, int midNum, int lastNum)
        {
            int[] factorPair = new int[2];
            for(int i = 0; i < factors.Count; i++)
            {
                for(int j = 0; j < factors.Count; ++j)
                {
                    if (factors[i] + factors[j] == midNum && factors[i] * factors[j] == lastNum)
                    {
                        factorPair[0] = factors[i];
                        factorPair[1] = factors[j];
                    }
                    else if (factors[i] - factors[j] == midNum && factors[i] * -factors[j] == lastNum)
                    {
                        factorPair[0] = factors[i];
                        factorPair[1] = -factors[j];
                    }
                    else if (-factors[i] + factors[j] == midNum && -factors[i] * factors[j] == lastNum)
                    {
                        factorPair[0] = -factors[i];
                        factorPair[1] = factors[j];
                    }
                    else if (-factors[i] - factors[j] == midNum && -factors[i] * -factors[j] == lastNum)
                    {
                        factorPair[0] = -factors[i];
                        factorPair[1] = -factors[j];
                    }
                }
            }

            return factorPair;
        }

        public static string PlusAndKill(bool isFirstNumber, bool isConstant, int number)
        {
            if (isFirstNumber == true && number > 0 && number != 1)
                return "" + number;
            if (isFirstNumber == true && number < 0 && number != 1)
                return "" + number;
            else if (isFirstNumber == false && number > 0 && number != 1)
                return "+" + number;
            else if (isFirstNumber == true && number == 1 && isConstant == true)
                return "" + number;
            else if (isFirstNumber == false && number == 1 && isConstant == false)
                return "+";
            else if (isFirstNumber == false && number == 1 && isConstant == true)
                return "+" + number;
            else if (isFirstNumber == false && number == -1 && isConstant == true)
                return "+" + number;
            else if (isFirstNumber == true && number == 1)
                return "";
            else if (isFirstNumber == false && number == 1)
                return "+";
            else if (number < 0 && number != -1)
                return number.ToString();
            else if (number == -1)
                return "-";
            else if (number == 0)
                return "+"+number;
            else
                return "[PlayMath_Prototype/MathAssistUtility/PlusGenerator]";
        }

        public static string Fraction(int n, int d)
        {
            /*
            CASES:
            -5 / -2 = 5/2
            -5 / 2 = -5 / 2
            5 / -2 = 5 / -2
            5 / 2 = 5/2
            -5/-1 = 5
            -5 / 1 = -5
            5 / -1 = -5
            5 / 1 = 5
            */
            if(d == 1)
            {
                return n.ToString();
            }
            else if(d == -1)
            {
                return (-1 * n).ToString();
            }
            else if(n < 0 && d < 0)
            {
                return ((-1 * n) + "/" + (-1 * d)).ToString();
            }

            return (n + "/" + d).ToString();
        }

        public static string Katakati(int n, int d)
        {
            int x = MathUtilities.GCD(n, d);
            if(x != -1)
            {
                n /= x;
                d /= x;
            }
 
            return Fraction(n, d);
        }

        public static List<PrimeCounts> PrimeCounts(this List<int> factors)
        {
            List<PrimeCounts> primeCounts = new List<PrimeCounts>();
            List<int> prime = new List<int>();    
        
            Dictionary<int, int> counts = new Dictionary<int, int>();
                
            foreach (int element in factors)                
            {
                if (counts.ContainsKey(element))
                    counts[element]++;
                else
                    counts.Add(element, 1);
            }  

            foreach (KeyValuePair<int, int> item in counts)
            {
                primeCounts.Add( new PrimeCounts() { Primes = item.Key, Counts = item.Value });
            }

            return primeCounts;       
        }
    }
}

