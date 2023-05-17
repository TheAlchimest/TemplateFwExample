using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TemplateFw.Admins.InternalApi.Controllers.Base;
using TemplateFw.Application.Services.User;

namespace TemplateFw.Admins.InternalApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ApiControllerBase<UserController>
    {
        private readonly IUserFavoritService _service;

        public UserController(ILogger<UserController> logger, IUserFavoritService service)
           : base(logger)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("SetFavoritService/{serviceId}")]
        public async Task<bool> SetFavoritService(int serviceId)
        {
            return await _service.SetFavoritService(serviceId);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("RemoveFavoritService/{serviceId}")]
        public async Task<bool> RemoveFavoritService(int serviceId)
        {
            return await  _service.RemoveFavoritService(serviceId);
        }
    }
}
