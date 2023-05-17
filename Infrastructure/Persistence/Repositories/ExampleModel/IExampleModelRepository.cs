using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFwExample.Domain.Models;
using TemplateFwExample.Dtos;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;

namespace TemplateFwExample.Persistence.IRepositories
{
    public interface IExampleModelRepository
    {
        Task<bool> CreateAsync(ExampleModelDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ExampleModelInfoDto>> GetAllAsync(ExampleModelFilter filter);
        Task<PagedList<ExampleModelInfoDto>> GetAllInfoPagedAsync(ExampleModelFilter filter);
        Task<ExampleModelInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ExampleModelDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ExampleModelDto dto);
    }
}