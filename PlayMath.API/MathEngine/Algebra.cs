using System.Collections.Generic;
using System.Linq;
using PlayMath.API.Dtos;
using PlayMath.API.MathHelperClasses;

namespace PlayMath.API.MathEngine
{
    public class Algebra : IAlgebra
    {
        public List<TrinomialSolutionDto> Trinomial(string equation,int a = 1, int b = 1, int c = 0)
        {
            List<TrinomialSolutionDto> solution =  new List<TrinomialSolutionDto>();

            var terms =  equation.Split(new char[] {'+', '-'}).Select(t => t.Trim());


            // char v = 'x';

            // int a;
            // int b;
            // int c;

            int d = a * c;
            var factors = d.PrimeFactors();

            var pairFactor = AssitUtilities.MidTermFactorPair(factors, b, d);

            if(pairFactor[0] != 0 && pairFactor[1] != 0)
            { 
                solution.Add(new TrinomialSolutionDto()
                {
                    SolutionLine = AssitUtilities.PlusAndKill(true, false, a) + "x^2" 
                                    + AssitUtilities.PlusAndKill(false, false, pairFactor[0]) + "x" 
                                    + AssitUtilities.PlusAndKill(false, false, pairFactor[1]) + "x" 
                                    + AssitUtilities.PlusAndKill(false, true, c)
                                    .ToString(),
                    Description = "xxxxxxxx"
                });
            }
            else 
            {
                solution.Add(new TrinomialSolutionDto()
                {
                    SolutionLine = string.Empty,
                    Description = "There is no other factor but itselt!"
                });

                return solution;
            }

            int gcd1 = MathUtilities.GCD(new int[] {pairFactor[0], a});
            int gcd2 = MathUtilities.GCD(new int[] {pairFactor[1], c});

            solution.Add(new TrinomialSolutionDto()
            {
                SolutionLine = (AssitUtilities.PlusAndKill(true, false, gcd1) + "x(" 
                                + AssitUtilities.PlusAndKill(true, false, a/gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, pairFactor[0]/gcd1) + ")" 
                                + AssitUtilities.PlusAndKill(false, true, gcd2) + "(" 
                                + AssitUtilities.PlusAndKill(true, false, pairFactor[1]/gcd2) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, c/gcd2) + ")")
                                .ToString(),
                Description = "xxxxxxxx"
            });

            solution.Add(new TrinomialSolutionDto()
            {
                SolutionLine = ("(" 
                                + AssitUtilities.PlusAndKill(true, false, a/gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, pairFactor[0]/gcd1) + ")(" 
                                + AssitUtilities.PlusAndKill(true, false, gcd1) + "x" 
                                + AssitUtilities.PlusAndKill(false, true, gcd2) +")")
                                .ToString(),
                Description = "xxxxxxxx"
            });

            return solution;      
        }
    }
}