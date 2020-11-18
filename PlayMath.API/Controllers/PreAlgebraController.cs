using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Dtos.PreAlgebraDtos;
using PlayMath.API.MathEngine;

namespace PlayMath.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreAlgebraController : ControllerBase
    {
        private readonly IPreAlgebra _preAlgebra;
        public PreAlgebraController(IPreAlgebra preAlgebra)
        {
            _preAlgebra = preAlgebra;
        }

        [HttpPost("mode")]
        public ModeSolution Mode(Mode mode)
        {
            var solution = _preAlgebra.Mode(mode.Numbers);
            return solution;
        }

        [HttpPost("gcd")]
        public GeneralSolution GreatestCommonDenominator(NumSteam numbers)
        {
            var solution = _preAlgebra.GreatestCommonDenominator(numbers.Numbers);

            return solution;
        }

        [HttpPost("factor/{number}")]
        public PrimeFactorSolution PrimeFactor(int number)
        {
            var solution =  _preAlgebra.PrimeFactor(number);

            return solution;
        }
    }
}