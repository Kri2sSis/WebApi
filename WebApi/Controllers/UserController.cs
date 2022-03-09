using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersServices _usersServices;
        private readonly IMapper _mapper;

        public UserController(IUsersServices usersServices, IMapper mapper)
        {
            _usersServices = usersServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterRequest filterRequest)
        {
            var users = await _usersServices.Get(filterRequest);
            
            return Ok(_mapper.Map<Core.Repositories.User[], Contracts.User[]>(users));
        }

        

        [HttpGet("{UserId}")]
        public async Task<IActionResult> Get([FromRoute]string userId)
        {
            var users = await _usersServices.Get(userId);
            
            return Ok(_mapper.Map<Core.Repositories.User, Contracts.User>(users));
        }

    }
}
