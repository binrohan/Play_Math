using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayMath.API.Data;
using PlayMath.API.Dtos;
using PlayMath.API.Helpers;
using PlayMath.API.Models;

namespace PlayMath.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly IPlayMathRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public UserController (IPlayMathRepository repo, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager) {
            _roleManager = roleManager;
            _userManager = userManager;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetUser (string id) {
            var userFromRepo = await _repo.GetUserAsync (id);

            var user = _mapper.Map<UserToReturnDto>(userFromRepo);

             user.Roles = await _userManager.GetRolesAsync(userFromRepo);

            return Ok (user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers ([FromQuery] UserParams userParams) {
            var usersFromRepo = await _repo.GetUsersAsync (userParams);

            var users = _mapper.Map<IEnumerable<UserToReturnDto>>(usersFromRepo);

            foreach (var user in users)
            {
                var userTemp = await _userManager.FindByEmailAsync(user.Email);
                var roles = await _userManager.GetRolesAsync(userTemp);
                user.Roles = roles;
            }

            return Ok (new {users, userParams.Length});
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateUser (string id, UserToUpdateDto userToUpdate) {
            var user = await _repo.GetUserAsync (id);

            if (id.Equals (userToUpdate.Id))
                BadRequest ("You are not permitted");

            _mapper.Map (userToUpdate, user);

            if (await _repo.SaveAll ()) {
                return Ok (user);
            }

            throw new Exception ("Article failed to update");
        }

        [HttpPost ("editRoles/{uId}")]
        public async Task<IActionResult> EditRoles (string uId, RoleEditDto roleEdit) {
            var user = await _userManager.FindByIdAsync (uId);

            var userRoles = await _userManager.GetRolesAsync (user);

            var selectedRoles = roleEdit.RoleNames;

            selectedRoles = selectedRoles ?? new string[] { };
            var result = await _userManager.AddToRolesAsync (user, selectedRoles.Except (userRoles));

            if (!result.Succeeded)
                return BadRequest ("Failed to add to roles");

            result = await _userManager.RemoveFromRolesAsync (user, userRoles.Except (selectedRoles));

            if (!result.Succeeded)
                return BadRequest ("Failed to remove the roles");

            return Ok (await _userManager.GetRolesAsync (user));
        }
    }
}