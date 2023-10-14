using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netangularlogin.Core.Entities;
using netangularlogin.DTO;

namespace netangularlogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
 
        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
 
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Ok("User Doest Not Exist");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return BadRequest("Please check Credential try again...!");
 
            return new UserDTO
            {
                Email = user.Email,
                DisplayName = user.DisplayName
            };
 
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> register(RegisterDTO registerDto)
        {
            var user = new Users
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
                  
            };
 
            var result = await _userManager.CreateAsync(user, registerDto.Password);
 
            if (!result.Succeeded) return BadRequest("Please check...!");
 
            return new UserDTO
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email
            };
        }

        [HttpGet("getuser")]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            IList<Users> users = await _userManager.Users.ToListAsync();

            IList<UserDTO> userDTOls = new List<UserDTO>();
            //Covert Users to UserDTO List
            foreach (Users user in users)
            {
                UserDTO userDTO = new UserDTO
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email
                };
                userDTOls.Add(userDTO);
            }
            return Ok(userDTOls);
        }

        [HttpGet("getuser/{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            Users user = await _userManager.FindByIdAsync(id);

            UserDTO userDTO = new UserDTO
            {
                DisplayName = user.DisplayName,
                Email = user.Email
            };
            return Ok(userDTO);
        }

        [HttpPut("updateuser/{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(string id, RegisterDTO UpdateUserDTO)
        {
            Users user = await _userManager.FindByIdAsync(id);

            user.DisplayName = UpdateUserDTO.DisplayName;
            user.Email = UpdateUserDTO.Email;

            var result = await _userManager.UpdateAsync(user);
            result = await _userManager.RemovePasswordAsync(user);
            
            result = await _userManager.AddPasswordAsync(user, UpdateUserDTO.Password);
            if (result.Succeeded)
            {
                UserDTO resultUser = new UserDTO
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email
                };
                return Ok(resultUser);
            }
            else
            {
                return BadRequest("Please check...!");
            }
        }
    }
}