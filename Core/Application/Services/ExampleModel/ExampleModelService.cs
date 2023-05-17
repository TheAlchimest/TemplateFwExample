using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFwExample.Domain.Models;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Dtos;
using TemplateFwExample.Persistence.IRepositories;
using TemplateFwExample.Shared.Application.Exceptions;
using TemplateFwExample.Shared.Application.Services;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;
using System.Linq;

namespace TemplateFwExample.Application.Services
{
    public class ExampleModelService : BaseService, IExampleModelService
    {
        #region Fields
        private readonly IExampleModelRepository _repository;
        #endregion

        #region Constructor
        public ExampleModelService(IExampleModelRepository repository, IMapper mapper, IUserInfoService userInfoService) : base(mapper, userInfoService)
        {
            _repository = repository;
        }
        #endregion

        #region CreateAsync
        public async Task<bool> CreateAsync(ExampleModelDto dto)
        {
            string user = _userInfoService.GetCurrentUserName();
            dto.CreatedBy = user;
            return await _repository.CreateAsync(dto);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(ExampleModelDto dto)
        {
            string user = _userInfoService.GetCurrentUserName();
            dto.ModifiedBy = user;
            return await _repository.UpdateAsync(dto);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            return await _repository.DeletePermanentlyAsync(id);
        }
        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id)
        {
            string user = _userInfoService.GetCurrentUserName();
            return await _repository.DeleteVirtuallyAsync(id, user);
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<ExampleModelDto> GetOneByIdAsync(int id)
        {
            var entity = await _repository.GetOneByIdAsync(id);
            if (entity is null)
            {
                throw new BusinessException(ErrorCodes.NotFound);
            }
            return entity;
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<ExampleModelInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang)
        {
            var entity = await _repository.GetInfoByIdAsync(id, lang);
            if (entity is null)
            {
                throw new BusinessException(ErrorCodes.NotFound);
            }
            return entity;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<ExampleModelInfoDto>> GetAllAsync(ExampleModelFilter filter)
        {
            var list = await _repository.GetAllAsync(filter);
            return list;
        }
        #endregion



        #region GetAllInfoPagedAsync
        public async Task<PagedList<ExampleModelInfoDto>> GetAllInfoPagedAsync(ExampleModelFilter filter)
        {
            return await _repository.GetAllInfoPagedAsync(filter);
        }
        #endregion

        #region GetLookupAsync
        public async Task<List<LookupDto>> GetLookupAsync(int? exampleCategoryId = null, int? exampleStatusId = null)
        {
            var filter = new ExampleModelFilter
            {
                ExampleCategoryId = exampleCategoryId,
				ExampleStatusId = exampleStatusId
            };
            return await GetAllAsLookupAsync(filter);
        }
        public async Task<List<LookupDto>> GetAllAsLookupAsync(ExampleModelFilter filter)
        {
            var list = await GetAllAsync(filter);
            return list.Select(e => new LookupDto(e.ExampleModelId,e.Title)).ToList();
        }
        #endregion
    }
}
