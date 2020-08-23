using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Picstapush.Data.PicstapushDb.Repositories.Interfaces;
using Picstapush.Utilities.AuthenticationHelpers;
using Picstapush.Utilities.MappingHelpers;
using Dtos = Picstapush.Dto;
using Db = Picstapush.Data.PicstapushDb.Entities;

namespace Picstapush.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(Dtos.Dtos.UserDto user)
        {
            var hashedPassword = PasswordHelper.HashPassword(user.Password);
            user.Password = hashedPassword;
            var dbUser = ObjectMapper.Map<Dtos.Dtos.UserDto, Db.User, Dtos.Interfaces.IPicstapushUser>(user);
            dbUser.DateCreated = DateTime.Now;
            var insertedUser = await _userRepository.InsertUser(dbUser);
            return Ok(insertedUser);
        }
    }
}
