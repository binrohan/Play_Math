using System;
using System.Collections.Generic;
using System.Linq;
using PlayMath.API.Dtos.PreAlgebraDtos;
using PlayMath.API.MathHelperClasses;
using PlayMath.API.models.MathModel;

namespace PlayMath.API.MathEngine
{
    public class PreAlgebra : IPreAlgebra
    {
        public GeneralSolution GreatestCommonDenominator(string numbers)
        {
            GeneralSolution solution = new GeneralSolution();

            List<NumAndSpliteArray> spliteArray = new List<NumAndSpliteArray>();

            solution.Numbers = numbers.Split(',').Select(int.Parse).ToList();

            foreach (var num in solution.Numbers)
            {
                spliteArray.Add(new NumAndSpliteArray {
                   Number = num,
                   SpliteArray = num.Divisors()
                });
            }

            solution.SpliteArray = spliteArray;

            solution.Result = MathUtilities.GCD(solution.Numbers);     

            return solution;
        }

        public ModeSolution Mode(string numbers)
        {
            ModeSolution solution =  new ModeSolution();

            solution.Numbers = numbers.Split(',').Select(int.Parse).ToList();

            solution.Result =  solution.Numbers.GetMode();

            return solution;
        }

        public PrimeFactorSolution PrimeFactor(int number)
        {
            PrimeFactorSolution solution = new PrimeFactorSolution();
            
            solution.Factors = number.PrimeFactors();

            solution.PrimeCounts = solution.Factors.PrimeCounts();

            return solution;
        }
    }
}