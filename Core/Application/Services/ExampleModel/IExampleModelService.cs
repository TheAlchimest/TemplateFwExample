using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFwExample.Dtos;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;

namespace TemplateFwExample.Application.Services
{
    public interface IExampleModelService
    {
        Task<bool> CreateAsync(ExampleModelDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<ExampleModelInfoDto>> GetAllAsync(ExampleModelFilter filter);
        Task<PagedList<ExampleModelInfoDto>> GetAllInfoPagedAsync(ExampleModelFilter filter);
        Task<ExampleModelInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ExampleModelDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ExampleModelDto dto);
        Task<List<LookupDto>> GetLookupAsync(int? exampleCategoryId = null, int? exampleStatusId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(ExampleModelFilter filter);
    }
}