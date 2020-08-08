using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Picstapush.Data.PicstapushDb.Entities;
using Picstapush.Data.PicstapushDb.Repositories.Interfaces;
using Picstapush.Utilities.AuthenticationHelpers;
using Picstapush.Web.Configurations;
using Picstapush.Web.Models;

namespace Picstapush.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtConfigurationOptions _jwtOptions;
        public LoginController(IUserRepository userRepository, JwtConfigurationOptions jwtOptions)
        {
            _userRepository = userRepository;
            _jwtOptions = jwtOptions;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Login(AuthenticateUserModel model)
        {
            var user = await _userRepository.FindUserByUsername(model.Username);

            if (user == null)
            {
                return NotFound();
            }

            var doesPasswordMatch = PasswordHelper.MatchPassword(user.Password, model.Password);

            if (!doesPasswordMatch)
            {
                return Forbid();
            }

            //generate a token
            var token = GenerateJwt(user);
            return Ok(token);
        }

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword()
        {
            return Ok();
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword()
        {
            return Ok();
        }

        private TokenModel GenerateJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Signature));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(_jwtOptions.ExpiresIn));
            
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var tokenModel = new TokenModel
            {
                ExpiresAt = token.ValidTo,
                Token = tokenString,
                RefreshToken = Guid.NewGuid().ToString("N")
            };
            return tokenModel;
        }
    }
}
