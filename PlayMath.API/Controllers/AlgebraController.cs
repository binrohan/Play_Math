using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Dtos;
using PlayMath.API.Dtos.AlgebraDtos;
using PlayMath.API.MathEngine;

namespace PlayMath.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgebraController : ControllerBase
    {
        private readonly IAlgebra _algebra;
        public AlgebraController(IAlgebra algebra)
        {
            _algebra = algebra;
        }

        [HttpPost("trinomial")]
        public List<TrinomialSolutionDto> Trinomial(Trinomial trinomial)
        {

 
            var solution = _algebra.Trinomial(trinomial.Equation, trinomial.A, trinomial.B, trinomial.C);

            return (solution);
        }

        [HttpPost("quadratic")]

        public List<QuadraticSolutionDto> Quadratic(Quadratic quadratic)
        {

            var solution = _algebra.Qudratic(quadratic.A, quadratic.B, quadratic.C, quadratic.D);

            return (solution);
        }
    }
}