using Microsoft.AspNetCore.Http;
using TemplateFwExample.Shared.Configuration;

namespace TemplateFwExample.Shared.Application.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SystemConfiguration _systemConfiguration;

        public UserInfoService(IHttpContextAccessor httpContextAccessor, SystemConfiguration systemConfiguration)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._systemConfiguration = systemConfiguration;
        }

        public string GetCurrentUserName()
        {
            var result = _httpContextAccessor.HttpContext.Request.Headers["user"];
            if (string.IsNullOrEmpty(result)) result = "Not Known User";
            return result;
        }
    }
}
