using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Picstapush.Data.PicstapushDb.Entities;
using Picstapush.Data.PicstapushDb.Repositories.Interfaces;
using Picstapush.Dto.Dtos;
using Picstapush.Dto.Interfaces;
using Picstapush.Utilities.MappingHelpers;
using Picstapush.Web.Configurations;
using Picstapush.Web.Helpers;

namespace Picstapush.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly JwtConfigurationOptions _jwtOptions;
        public TokenController(ITokenRepository tokenRepository, IUserRepository userRepository, JwtConfigurationOptions jwtOptions)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _jwtOptions = jwtOptions;
        }

        [HttpGet("refresh/{refreshToken}")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var token = await _tokenRepository.GetTokenByRefreshToken(refreshToken);
            if (token == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetUserById(token.UserId);
            var newToken = TokenCreator.CreateToken(user, _jwtOptions);
            newToken.UserId = user.Id;
            var tokenEntity = ObjectMapper.Map< TokenDto, Token, IToken>(newToken);
            await _tokenRepository.InsertToken(tokenEntity);

            return Ok(newToken);
        }
    }
}
