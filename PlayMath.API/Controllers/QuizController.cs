using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Data;

namespace PlayMath.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class QuizController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly IPlayMathRepository _repo;
        public QuizController (IPlayMathRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }
    }
}