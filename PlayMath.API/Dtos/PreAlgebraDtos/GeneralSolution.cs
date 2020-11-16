using System.Collections.Generic;
using PlayMath.API.models.MathModel;

namespace PlayMath.API.Dtos.PreAlgebraDtos
{
    public class GeneralSolution
    {
        public List<int> Numbers { get; set; }
        public List<NumAndSpliteArray> SpliteArray { get; set; }
        public int Result { get; set; }
    }
}