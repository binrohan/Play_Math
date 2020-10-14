using System.Collections.Generic;
using PlayMath.API.Dtos;

namespace PlayMath.API.MathEngine
{
    public interface IMaths
    {
         List<TrinomialSolutionDto> FactorTrinomial(string equation,int a = 1, int b = 1, int c = 0);
    }
}