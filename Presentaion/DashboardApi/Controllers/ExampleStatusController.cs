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
    public class ExampleStatusController : ApiControllerBase<ExampleStatusController>
    {
        private readonly IExampleStatusService exampleStatusService;

        public ExampleStatusController(ILogger<ExampleStatusController> logger, IExampleStatusService ExampleStatusService)
            : base(logger)
        {
            exampleStatusService = ExampleStatusService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("create")]
        public async Task<ApiResponse> Create(ExampleStatusDto dto)
        {
            return await ApiResponse(() => exampleStatusService.CreateAsync(dto), OperationTypes.Add);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("update")]
        public async Task<ApiResponse> Update(ExampleStatusDto dto)
        {
             return await ApiResponse(() => exampleStatusService.UpdateAsync(dto), OperationTypes.Update);
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<ExampleStatusDto>> GetById(int id)
        {
            return await GenericApiResponse(() => exampleStatusService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<ExampleStatusInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => exampleStatusService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<ExampleStatusInfoDto>>> GetAll(ExampleStatusFilter filter)
        {
            return await GenericApiResponse(() => exampleStatusService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<ExampleStatusInfoDto>>> GetPagedList(ExampleStatusFilter filter)
        {
            return await GenericApiResponse(() => exampleStatusService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => exampleStatusService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("lookup")]
        public async Task<GenericApiResponse<List<LookupDto>>> GetLookup()
        {
            return await GenericApiResponse(() => exampleStatusService.GetLookupAsync(), OperationTypes.GetList);
        }
        
    }
}
