
using System.Threading.Tasks;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Dtos.Announces;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services.Announces
{
    public interface IAnnounceService
    {
        Task<PagedList<VwAnnounceFullData>> GetPagedListAsync(AnnounceGridFilter filter);
        Task<bool> SaveAsync(AnnounceRequestDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ActivateAsync(int id);
        Task<bool> DeactivateAsync(int id);

        Task<VwAnnounceFullData> FullDataByIdAsync(int id, EnumLanguage lang);
        Task<AnnounceResponseDto> GetByIdAsync(int id);
    }
}
