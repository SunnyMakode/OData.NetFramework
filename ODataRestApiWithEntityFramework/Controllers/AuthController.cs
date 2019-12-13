using System;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.IdentityModel.Tokens;
using OData.InternalDataService.Interface;
using ODataRestApiWithEntityFramework.DTOs;
using OData.Business.DomainClasses;

namespace ODataRestApiWithEntityFramework.Controllers
{
    public class AuthController : ODataController
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        [ODataRoute("Signup")]
        public async Task<IHttpActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            userDto.Username = userDto.Username;

            if (await _authRepository.IsUserExist(userDto.Username))
            {
                return BadRequest("profile already exist");
            }

            var userToCreate = new User
            {
                Username = userDto.Username
            };

            var createdUser = _authRepository.Register(userToCreate, userDto.Password);

            return Ok(201);
        }

        [HttpPost]
        [ODataRoute("Login")]
        public async Task<IHttpActionResult> Login(UserDto userDto)
        {
            var userFromRepo = await _authRepository.Login(userDto.Username, userDto.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username.ToString())
                };

            var tokenFromConfig = ConfigurationManager.AppSettings["SecretTokenKey"];

            var secretKey = new SymmetricSecurityKey(Encoding
                .UTF8.GetBytes(tokenFromConfig));

            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var result = new
            {
                token = tokenHandler.WriteToken(token)
            };

            return Json(result);
        }
    }
}
