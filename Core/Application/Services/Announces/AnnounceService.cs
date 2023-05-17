using AutoMapper;
using System.Threading.Tasks;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Dtos.Announces;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Shared.Application.Exceptions;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.Interfaces;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services.Announces
{
    public class AnnounceService : BaseService, IAnnounceService
    {
        private readonly IAnnounceRepository _repository;
        public AnnounceService(IAnnounceRepository repository,
            IMapper mapper, IUserInfoService userInfoService) : base(mapper, userInfoService)
        {
            _repository = repository;
        }

        public async Task<bool> SaveAsync(AnnounceRequestDto model)
        {
            if (model.Id == 0)
            {
                return await CreateAsync(model);
            }
            else
            {
                return await EditAsync(model);
            }
        }

        private async Task<bool> CreateAsync(AnnounceRequestDto model)
        {
            var entity = _mapper.Map<Announce>(model);
            SetCreationData((IAgregateEntity)entity);
            entity = await _repository.InsertAsync(entity);
            if (model.IsEnabled)
                return await ActivateAsync(entity.Id);
            return true;
        }

        private async Task<bool> EditAsync(AnnounceRequestDto dto)
        {
            var result = await _repository.UpdateAsync(dto, _userInfoService.GetCurrentUserName());
            if (dto.IsEnabled)
                return await ActivateAsync(dto.Id);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id, _userInfoService.GetCurrentUserName());
        }

        public async Task<bool> ActivateAsync(int id)
        {
            return await _repository.ActivateAsync(id, _userInfoService.GetCurrentUserName());
        }
        public async Task<bool> DeactivateAsync(int id)
        {
            return await _repository.DeactivateAsync(id, _userInfoService.GetCurrentUserName());
        }


        public async Task<VwAnnounceFullData> FullDataByIdAsync(int id, EnumLanguage lang)
        {
            var entity = await _repository.FullDataByIdAsync(id, lang);

            if (entity is null)
            {
                throw new BusinessException(ErrorCodes.NotFound);
            }

            return entity;
        }

        public async Task<AnnounceResponseDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new BusinessException(ErrorCodes.NotFound);
            }

            var dto = _mapper.Map<AnnounceResponseDto>(entity);
            return dto;
        }

        public async Task<PagedList<VwAnnounceFullData>> GetPagedListAsync(AnnounceGridFilter filter)
        {
            return await _repository.GetPagedListAsync(filter);
        }
    }
}
