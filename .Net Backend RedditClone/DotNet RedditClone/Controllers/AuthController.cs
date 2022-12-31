using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DotNet_RedditClone.DTO.UserDTO;
using DotNet_RedditClone.Model.Enum;
using DotNet_RedditClone.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DotNet_RedditClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            _configuration = configuration;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("GetMe")]
        [Authorize]
        public async Task<ActionResult<User>> GetMe()
        {
            string username = _userService.GetMyUsername();
            
            User user = await _userService.FindFirstByUsername(username);
            GetSingleUserDTO userDto = _mapper.Map<User, GetSingleUserDTO>(user);
            
            return Ok(userDto);
        }

        [HttpGet]
        [Route("MyRole")]
        [Authorize]
        public ActionResult<string> GetMyRole()
        {
            string role = _userService.GetMyRole();

            return Ok(role);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Register(UserRegisterDTO userRegisterDTO)
        {
            CreatePasswordHash(userRegisterDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User newUser = new User();

            newUser.Username = userRegisterDTO.Username;
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.Avatar = "No Avatar";
            newUser.Email = userRegisterDTO.Email;
            newUser.DateOfRegistration = DateTime.Now;
            newUser.Description = "No Description";
            newUser.DisplayName = userRegisterDTO.DisplayName;
            newUser.Role = ERole.User;
            
            await _userService.RegisterUser(newUser);

            return Ok(userRegisterDTO);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDTO userLoginDTO)
        {
            User foundUser = await _userService.FindFirstByUsername(userLoginDTO.Username);

            if (foundUser == null)
            {
                return BadRequest("User Not Found");
            }
            
            if (!VerifyPasswordHash(userLoginDTO.Password, foundUser.PasswordHash, foundUser.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(foundUser);

            return Ok(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, (user.Role).ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
