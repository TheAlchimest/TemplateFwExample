using Dashboard.Common.WebClientHelpers;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Dtos.Announces;
using TemplateFw.Shared.Domain.GenericResponse;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.AnnouncesUrls;
using Api = Dashboard.Common.WebClientHelpers;
namespace TemplateFw.Admin.Dashboard.InternalApiConsumer
{
    public class AnnounceConsumer 
    {
        RequestUrlHelper api = ApiRequestHelper.Dashboard;
        public async Task<ApiResponse> Save(AnnounceRequestDto dto)
        {
           return  await api.PostAsync<ApiResponse>(Urls.Save, dto);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<VwAnnounceFullData>> GetInfoById(int id)
        {
            return await api.GetAsync<GenericApiResponse<VwAnnounceFullData>>(Urls.Save, dto);

            await api.PostAsync<ApiResponse>(InternalApiDictionary.AnnouncesUrls.Save, dto);

        }


        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<AnnounceResponseDto>> GetById(int id)
        {
            return await GenericApiResponse(() => _service.GetByIdAsync(id), OperationTypes.GetOne);
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<PagedList<VwAnnounceFullData>>> GetAll(AnnounceGridFilter filter)
        {
            return await GenericApiResponse(() => _service.GetPagedListAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => _service.DeleteAsync(id), OperationTypes.Delete);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("activate/{id}")]
        public async Task<ApiResponse> Activate(int id)
        {
            return await ApiResponse(() => _service.ActivateAsync(id), OperationTypes.Activate);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("deactivate/{id}")]
        public async Task<ApiResponse> Deactivate(int id)
        {
            return await ApiResponse(() => _service.DeactivateAsync(id), OperationTypes.Deactivate);
        }

    }
}
