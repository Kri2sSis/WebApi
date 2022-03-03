using Microsoft.AspNetCore.Mvc;
using WebApi.Core;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersServices _usersServices;

        public UserController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationConfiguration pagination,
                                             [FromQuery] FilterConfiguration filter)
        {
            var users = await _usersServices.Get(pagination, filter);
            return Ok(users);
        }

        

        [HttpGet("{UserId}")]
        public async Task<IActionResult> Get([FromRoute]string userId)
        {
            var users = await _usersServices.Get(userId);

            return Ok(users);
        }

    }
}
