using BAL;
using DAL;

using Microsoft.AspNetCore.Mvc;
using Models;

namespace basicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("addUser")]
        public IActionResult AddUser(User user)
        {
            var result= _userService.AddUser(user);
            return Ok(result);

        }
    }
}
