using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Picstapush.Data.PicstapushDb.Repositories.Interfaces;
using Picstapush.Utilities.AuthenticationHelpers;
using Picstapush.Utilities.MappingHelpers;
using Picstapush.Web.Models;
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
    }
}
