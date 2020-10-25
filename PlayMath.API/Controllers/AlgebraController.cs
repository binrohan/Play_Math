using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Dtos;
using PlayMath.API.Dtos.AlgebraDtos;
using PlayMath.API.MathEngine;

namespace PlayMath.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class AlgebraController : ControllerBase {
        private readonly IAlgebra _algebra;
        public AlgebraController (IAlgebra algebra) {
            _algebra = algebra;
        }

        [HttpPost ("trinomial")]
        public List<TrinomialSolutionDto> Trinomial (Trinomial trinomial) {

            // input: Ax^2 + Bx + C: x^2 + 7x + 12
            // steps:
            // step 0: separate common factors(f) from all three terms 
            // step 1: A * C = D : 1 * 12 = 12
            // step 2: prime factor D : !1, 2, 3, 4, 6, !12
            // step 3: Finding the right pair of prime factor D : 3, 4
            // step 4: Splite the middle term : 3x + 4x = 7x
            // step 5: Separate common factors
            // step 6: Separate common terms
            // Ouputs:
            // if f != 1 then f(dx^2 + ex + g)
            // Ax^2 + ax + bx + C; a + b = B : x^2 + 4x + 3x + 12
            // x(Ax + a) + x(Ax + a) : x(x + 4) + 3(x + 4)
            // (Ax + a)(x + x) : (x + 4)(x + 3)

            var solution = _algebra.Trinomial (trinomial.Equation, trinomial.A, trinomial.B, trinomial.C);

            return (solution);
        }

        [HttpPost("quadratic")]

        public List<QuadraticSolutionDto> Quadratic (Quadratic quadratic){
            
            var solution = _algebra.Qudratic (quadratic.A, quadratic.B, quadratic.C, quadratic.D);

            return (solution);
        }
    }
}