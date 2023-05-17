using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFwExample.Domain.Models;
using TemplateFwExample.Dtos;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;

namespace TemplateFwExample.Persistence.IRepositories
{
    public interface IExampleStatusRepository
    {
        Task<bool> CreateAsync(ExampleStatusDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ExampleStatusInfoDto>> GetAllAsync(ExampleStatusFilter filter);
        Task<PagedList<ExampleStatusInfoDto>> GetAllInfoPagedAsync(ExampleStatusFilter filter);
        Task<ExampleStatusInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ExampleStatusDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ExampleStatusDto dto);
    }
}