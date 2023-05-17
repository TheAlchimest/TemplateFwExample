using Dashboard.Common.WebClientHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using TemplateFwExample.Dashboard.Auth;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Dtos;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Domain.GenericResponse;
using TemplateFwExample.Shared.Dtos.Collections;
using TemplateFwExample.Shared.Helpers;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.ExampleCategoryUrls;

namespace TemplateFwExample.Dashboard.Controllers
{
    //[Authorize(Roles = RoleProvider.ExampleCategory)]
    public class ExampleCategoryController : WebBaseController<ExampleCategoryController>
    {
        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;
        private readonly ExampleCategoryDtoInsertValidator _insertValidator;
        private readonly ExampleCategoryDtoUpdateValidator _updateValidator;

        public  ExampleCategoryController(ExampleCategoryDtoInsertValidator validator, ExampleCategoryDtoUpdateValidator updateValidator)
        {
            _insertValidator = validator;
            _updateValidator = updateValidator;
        }

    #region Add
    [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                ViewBag.ActionUrl = "/exampleCategory/create";
                return View("Save");
    }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                id = StringCipher.Decrypt(id);
                string url = string.Format(Urls.GetOne, id);
                var apiResult = await _api.GetAsync<GenericApiResponse<ExampleCategoryDto>>(url);
                ViewBag.ActionUrl = "/exampleCategory/update";
                ViewBag.IsUpdateMode = true;
                return ReturnViewResponse(apiResult, OperationTypes.GetContent, "Save");
            }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }

        }

        #endregion

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExampleCategoryDto dto)
        {
            try
            {
                var validationResult = _insertValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return ReturnBadRequest(validationResult);
                }
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Create, dto);
                return ReturnJsonResponse(apiResult, OperationTypes.Add);
            }
            catch (System.Exception ex)
            {
                return ReturnJsonException(ex, OperationTypes.Add);
            }

        }
        #endregion

        #region Update
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ExampleCategoryDto dto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return ReturnBadRequest(validationResult);
                }
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Update, dto);
                return ReturnJsonResponse(apiResult, OperationTypes.Update);
            }
            catch (System.Exception ex)
            {
                return ReturnJsonException(ex, OperationTypes.Update);
            }
        }
        #endregion

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ExampleCategoryFilter filter = new ExampleCategoryFilter();
            var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<ExampleCategoryInfoDto>>>(Urls.GetPaged, filter);
            return ReturnViewResponse(apiResult, OperationTypes.GetContent);
        }
        #endregion

        #region IndexContent

        [HttpGet]
        public async Task<IActionResult> IndexContent([FromQuery] ExampleCategoryFilter filter)
        {
            var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<ExampleCategoryInfoDto>>>(Urls.GetPaged, filter);
            return ReturnViewResponse(apiResult, OperationTypes.GetContent);
        }
        #endregion



        #region Delete

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ReturnBadRequest(OperationTypes.Delete);
                }
                string url = string.Format(Urls.Delete, id);
                var apiResult = await _api.PostAsync<ApiResponse>(url, id);
                return ReturnJsonResponse(apiResult, OperationTypes.Delete);
            }
            catch (System.Exception ex)
            {

                return ReturnJsonException(ex, OperationTypes.Delete);
            }

}
        #endregion


        #region Lookup
        
        [HttpGet]
        public async Task<JsonResult> Lookup()
        {
            string url = Urls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
        #endregion

    }
}
