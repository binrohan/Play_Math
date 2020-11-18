using System.Collections.Generic;
using PlayMath.API.models.MathModel;

namespace PlayMath.API.Dtos.PreAlgebraDtos
{
    public class PrimeFactorSolution
    {
        public List<int> Factors { get; set; }
        public List<PrimeCounts> PrimeCounts { get; set; }
    }
}