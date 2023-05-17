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
    public class ExampleModelController : ApiControllerBase<ExampleModelController>
    {
        private readonly IExampleModelService exampleModelService;

        public ExampleModelController(ILogger<ExampleModelController> logger, IExampleModelService ExampleModelService)
            : base(logger)
        {
            exampleModelService = ExampleModelService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("create")]
        public async Task<ApiResponse> Create(ExampleModelDto dto)
        {
            return await ApiResponse(() => exampleModelService.CreateAsync(dto), OperationTypes.Add);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("update")]
        public async Task<ApiResponse> Update(ExampleModelDto dto)
        {
             return await ApiResponse(() => exampleModelService.UpdateAsync(dto), OperationTypes.Update);
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<ExampleModelDto>> GetById(int id)
        {
            return await GenericApiResponse(() => exampleModelService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<ExampleModelInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => exampleModelService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<ExampleModelInfoDto>>> GetAll(ExampleModelFilter filter)
        {
            return await GenericApiResponse(() => exampleModelService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<ExampleModelInfoDto>>> GetPagedList(ExampleModelFilter filter)
        {
            return await GenericApiResponse(() => exampleModelService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => exampleModelService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("lookup")]
        public async Task<GenericApiResponse<List<LookupDto>>> GetLookup(int? exampleCategoryId = null, int? exampleStatusId = null)
        {
            return await GenericApiResponse(() => exampleModelService.GetLookupAsync(exampleCategoryId, exampleStatusId), OperationTypes.GetList);
        }
        
    }
}
