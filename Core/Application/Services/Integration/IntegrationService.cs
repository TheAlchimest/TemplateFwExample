using TemplateFw.Application.Services.ActionLogs;
using TemplateFw.Clients.Dtos;
using TemplateFw.Integration.Clients;
using TemplateFw.Shared.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using static TemplateFw.Domain.Models.ActionLog;

namespace TemplateFw.Application.Services.Integration
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentManager _attachmentManager;

        public AttachmentService(IUserRegisteredNumbersService userRegisteredNumbersService, IUserInfoService userInfoService,
            IMoiService moiService, IAttachmentManager attachmentManager, IAddressService addressService,
            IActionLogService actionLogService, IHttpContextAccessor httpContextAccessor)
        {
            this._attachmentManager = attachmentManager;
        }


        public async Task<string> Upload(AttachmentDto attachmentDto)
        {
            var result = await _attachmentManager.Upload(attachmentDto);
            if (result.Status)
            {
                return result.Data;
            }

            return default;
        }

        public async Task<DownloadDto> Download(string attachmentId)
        {
            var result = await _attachmentManager.Download(attachmentId);
            if (result.Status)
            {
                return result.Data;
            }

            return default;
        }
    }
}
