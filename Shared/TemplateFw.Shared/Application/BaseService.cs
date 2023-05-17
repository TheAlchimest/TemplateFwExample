using AutoMapper;
using System;
using TemplateFwExample.Shared.Domain.Interfaces;

namespace TemplateFwExample.Shared.Application.Services
{

    public class BaseService
    {
        #region Fields
        protected readonly IMapper _mapper;
        protected readonly IUserInfoService _userInfoService;
        #endregion

        #region Constructor
        public BaseService(IMapper mapper, IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }
        #endregion

        #region SetCreationData
        // currentDate for mutible insertion or master detail entities
        public void SetCreationData(IAgregateEntity entity, DateTime? currentDate = null)
        {
            var username = _userInfoService.GetCurrentUserName();
            if (!string.IsNullOrEmpty(username))
            {
                entity.CreatedBy = (username.Length > 30) ? username.Substring(0, 29) : username;
            }
            entity.CreationDate = (currentDate.HasValue) ? currentDate.Value : DateTime.Now;
            entity.IsAvailable = true;
        }
        #endregion


        #region SetModificationData
        //currentDate for mutible insertion or master detail entities
        public void SetModificationData(IAgregateEntity entity, DateTime? currentDate = null)
        {
            var username = _userInfoService.GetCurrentUserName();
            entity.LastModifiedBy = (username.Length > 30) ? username.Substring(0, 29) : username;
            entity.LastModificationDate = (currentDate.HasValue) ? currentDate.Value : DateTime.Now;
        }
        #endregion
    }
}
