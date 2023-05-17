using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFwExample.Domain.Models;
using TemplateFwExample.Dtos;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;

namespace TemplateFwExample.Persistence.IRepositories
{
    public interface IExampleCategoryRepository
    {
        Task<bool> CreateAsync(ExampleCategoryDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ExampleCategoryInfoDto>> GetAllAsync(ExampleCategoryFilter filter);
        Task<PagedList<ExampleCategoryInfoDto>> GetAllInfoPagedAsync(ExampleCategoryFilter filter);
        Task<ExampleCategoryInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ExampleCategoryDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ExampleCategoryDto dto);
    }
}