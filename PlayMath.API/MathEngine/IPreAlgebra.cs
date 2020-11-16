using PlayMath.API.Dtos.PreAlgebraDtos;

namespace PlayMath.API.MathEngine
{
    public interface IPreAlgebra
    {
         ModeSolution Mode(string numbers);

         GeneralSolution GreatestCommonDenominator(string numbers);
    }
}