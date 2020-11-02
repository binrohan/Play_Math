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
    }
}