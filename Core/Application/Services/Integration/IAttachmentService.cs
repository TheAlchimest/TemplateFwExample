using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateFw.Application.Services.Integration
{
    public interface IAttachmentService
    {
        Task<string> Upload(AttachmentDto attachmentDto);
        Task<DownloadDto> Download(string attachmentId);
    }
}
