using System.Collections.Generic;
using PlayMath.API.Dtos;
using PlayMath.API.Dtos.AlgebraDtos;

namespace PlayMath.API.MathEngine
{
    public interface IAlgebra
    {
        List<TrinomialSolutionDto> Trinomial(string equation,int a = 1, int b = 1, int c = 0);
        List<QuadraticSolutionDto> Qudratic(int a = 1, int b = 1, int c = 0, int d = 0);
    }
}