using System.Collections.Generic;

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
                return "+" + number;
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
    }
}