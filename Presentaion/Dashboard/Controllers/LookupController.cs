using Dashboard.Common.WebClientHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateFwExample.Dashboard.Auth;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Dtos;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Domain.GenericResponse;
using TemplateFwExample.Shared.Dtos.Collections;
using TemplateFwExample.Shared.Helpers;
using Microsoft.Extensions.Localization;
using TemplateFwExample.Resources;
using TemplateFwExample.Resources.Resources;
using Azure;
using static Dashboard.Common.WebClientHelpers.InternalApiDictionary;

namespace TemplateFwExample.Dashboard.Controllers
{
    [AllowAnonymous]
    public class LookupController : WebBaseController<LookupController>
    {
        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;

        
        [HttpGet]
        public async Task<JsonResult> ExampleCategories()
        {
            string url = ExampleCategoryUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> ExampleModels(int? exampleCategoryId = null, int? exampleStatusId = null)
        {
            string url = string.Format(ExampleModelUrls.GetLookup, exampleCategoryId, exampleStatusId);
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> ExampleStatuses()
        {
            string url = ExampleStatusUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }

    }
}
