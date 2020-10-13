using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Dtos;
using PlayMath.API.MathEngine;

namespace PlayMath.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class MathsController : ControllerBase {
        private readonly IMaths _maths;
        public MathsController (IMaths maths) {
            _maths = maths;
        }

        [HttpPost]
        public async Task<IActionResult> Post (Factorize factorize) {

            var equation = factorize.Trinomial;
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

            _maths.FactorTrinomial(factorize.Trinomial, factorize.A, factorize.B, factorize.C);

            return Ok (equation);
        }
    }
}