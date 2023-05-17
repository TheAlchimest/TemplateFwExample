using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFwExample.Dtos;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;

namespace TemplateFwExample.Application.Services
{
    public interface IExampleCategoryService
    {
        Task<bool> CreateAsync(ExampleCategoryDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<ExampleCategoryInfoDto>> GetAllAsync(ExampleCategoryFilter filter);
        Task<PagedList<ExampleCategoryInfoDto>> GetAllInfoPagedAsync(ExampleCategoryFilter filter);
        Task<ExampleCategoryInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ExampleCategoryDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ExampleCategoryDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(ExampleCategoryFilter filter);
    }
}