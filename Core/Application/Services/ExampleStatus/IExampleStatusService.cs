using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFwExample.Dtos;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;

namespace TemplateFwExample.Application.Services
{
    public interface IExampleStatusService
    {
        Task<bool> CreateAsync(ExampleStatusDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<ExampleStatusInfoDto>> GetAllAsync(ExampleStatusFilter filter);
        Task<PagedList<ExampleStatusInfoDto>> GetAllInfoPagedAsync(ExampleStatusFilter filter);
        Task<ExampleStatusInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ExampleStatusDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ExampleStatusDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(ExampleStatusFilter filter);
    }
}