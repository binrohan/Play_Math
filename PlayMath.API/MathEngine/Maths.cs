using System;
using System.Linq;
using System.Text.RegularExpressions;
using PlayMath.API.Helpers;

namespace PlayMath.API.MathEngine
{
    public class Maths : IMaths
    {
        public void FactorTrinomial(string equation,int a = 1, int b = 1, int c = 0)
        {
            var terms =  equation.Split(new char[] {'+', '-'}).Select(t => t.Trim());


            char v = 'x';

            // int a;
            // int b;
            // int c;

            int d = a * c;
            var factors = d.PrimeFactorsExcluded();

            
           
            foreach (var term in terms)
            {
                System.Console.WriteLine("*******************************************************************" + term);
            }
        }
    }
}