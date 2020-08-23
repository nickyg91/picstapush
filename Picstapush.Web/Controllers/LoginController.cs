using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Picstapush.Data.PicstapushDb.Entities;
using Picstapush.Data.PicstapushDb.Repositories.Interfaces;
using Picstapush.Dto.Dtos;
using Picstapush.Dto.Interfaces;
using Picstapush.Utilities.AuthenticationHelpers;
using Picstapush.Utilities.MappingHelpers;
using Picstapush.Web.Configurations;
using Picstapush.Web.Helpers;
using Picstapush.Web.Models;
using User = Picstapush.Data.PicstapushDb.Entities.User;

namespace Picstapush.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtConfigurationOptions _jwtOptions;
        private readonly ITokenRepository _tokenRepository;
        public LoginController(IUserRepository userRepository, JwtConfigurationOptions jwtOptions, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _jwtOptions = jwtOptions;
            _tokenRepository = tokenRepository;
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
            var token = TokenCreator.CreateToken(user, _jwtOptions);

            var tokenEntity = ObjectMapper.Map<TokenDto, Token, IToken>(token);
            tokenEntity.UserId = user.Id;
            await _tokenRepository.InsertToken(tokenEntity);

            return Ok(token);
        }

        [HttpGet("logout/{userId:int}")]
        public async Task<IActionResult> Logout(int userId)
        {
            await _tokenRepository.RemoveTokensByUser(userId);
            return Ok();
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword()
        {
            return Ok();
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword()
        {
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount(CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload detected.");
            }

            var hashedPassword = PasswordHelper.HashPassword(model.Password);

            var user = new User
            {
                DateCreated = DateTime.Now,
                Email = model.Email,
                Password = hashedPassword,
                Username = model.Username
            };

            try
            {
                var userId = await _userRepository.InsertUser(user);
                var insertedUser = await _userRepository.GetUserById(userId);
                return Ok(ObjectMapper.Map<User, UserDto, IPicstapushUser>(insertedUser));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
