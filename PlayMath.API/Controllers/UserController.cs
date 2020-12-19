using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Data;
using PlayMath.API.Helpers;

namespace PlayMath.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase{
        private readonly IMapper _mapper;
        private readonly IPlayMathRepository _repo;
        public UserController (IPlayMathRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _repo.GetUserAsync(id);

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(UserParams userParams)
        {
            var users = await _repo.GetUsersAsync(userParams);

            return Ok(users);
        }
    }
}