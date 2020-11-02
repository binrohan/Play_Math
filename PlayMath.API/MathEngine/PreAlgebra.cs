using System;
using System.Linq;
using PlayMath.API.Dtos.PreAlgebraDtos;
using PlayMath.API.MathHelperClasses;

namespace PlayMath.API.MathEngine
{
    public class PreAlgebra : IPreAlgebra
    {
        public ModeSolution Mode(string numbers)
        {
            ModeSolution solution =  new ModeSolution();

            solution.Numbers = numbers.Split(',').Select(int.Parse).ToList();

            solution.Result =  solution.Numbers.GetMode();

            return solution;
        }
    }
}