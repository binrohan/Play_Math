using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Dtos;
using PlayMath.API.Dtos.AlgebraDtos;
using PlayMath.API.MathEngine;

namespace PlayMath.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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

        [HttpPost("square")]
        public List<TrinomialSolutionDto> Square(Square square)
        {

            var solution = _algebra.Square(square.A, square.B);

            return (solution);
        }

        [HttpPost("cube")]
        public List<TrinomialSolutionDto> Cube(Square square)
        {

            var solution = _algebra.Cube(square.A, square.B);

            return (solution);
        }

        [HttpPost("ab")]
        public List<TrinomialSolutionDto> AMinusB(Square square)
        {

            var solution = _algebra.AMinusB(square.A, square.B);

            return (solution);
        }
    }
}