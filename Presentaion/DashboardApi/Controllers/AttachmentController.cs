using TemplateFw.Admins.InternalApi.Controllers.Base;
using TemplateFw.Application.Services.Integration;
using TemplateFw.Clients.Dtos;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TemplateFw.Admins.InternalApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AttachmentController : ApiControllerBase<AttachmentController>
    {
        private readonly IAttachmentService _integrationService;

        public AttachmentController(ILogger<AttachmentController> logger, IAttachmentService integrationService)
            :base(logger)
        {
            this._integrationService = integrationService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("upload")]
        public async Task<ApiResponse> Upload(AttachmentDto attachment)
        {
            return await GenericApiResponse(() => _integrationService.Upload(attachment),OperationTypes.Upload);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("download/{attachmentId}")]
        public async Task<ApiResponse> Download(string attachmentId)
        {
            attachmentId = StringCipher.Decrypt(attachmentId);
            return await GenericApiResponse(() => _integrationService.Download(attachmentId), OperationTypes.Download);
        }
      
    }
}
