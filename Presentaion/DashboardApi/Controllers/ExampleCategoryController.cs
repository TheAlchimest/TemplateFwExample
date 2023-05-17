using Microsoft.AspNetCore.Mvc;
using TemplateFwExample.Application.Services;
using TemplateFwExample.DashboardApi.Controllers.Base;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Dtos;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Domain.GenericResponse;
using TemplateFwExample.Shared.Dtos.Collections;
using TemplateFwExample.Domain.Models;

namespace TemplateFwExample.DashboardApi.Controllers
{

    // [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ExampleCategoryController : ApiControllerBase<ExampleCategoryController>
    {
        private readonly IExampleCategoryService exampleCategoryService;

        public ExampleCategoryController(ILogger<ExampleCategoryController> logger, IExampleCategoryService ExampleCategoryService)
            : base(logger)
        {
            exampleCategoryService = ExampleCategoryService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("create")]
        public async Task<ApiResponse> Create(ExampleCategoryDto dto)
        {
            return await ApiResponse(() => exampleCategoryService.CreateAsync(dto), OperationTypes.Add);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("update")]
        public async Task<ApiResponse> Update(ExampleCategoryDto dto)
        {
             return await ApiResponse(() => exampleCategoryService.UpdateAsync(dto), OperationTypes.Update);
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<ExampleCategoryDto>> GetById(int id)
        {
            return await GenericApiResponse(() => exampleCategoryService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<ExampleCategoryInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => exampleCategoryService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<ExampleCategoryInfoDto>>> GetAll(ExampleCategoryFilter filter)
        {
            return await GenericApiResponse(() => exampleCategoryService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<ExampleCategoryInfoDto>>> GetPagedList(ExampleCategoryFilter filter)
        {
            return await GenericApiResponse(() => exampleCategoryService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => exampleCategoryService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("lookup")]
        public async Task<GenericApiResponse<List<LookupDto>>> GetLookup()
        {
            return await GenericApiResponse(() => exampleCategoryService.GetLookupAsync(), OperationTypes.GetList);
        }
        
    }
}
