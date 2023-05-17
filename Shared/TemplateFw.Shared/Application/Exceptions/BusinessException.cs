using System;
using System.Collections.Generic;
using System.Linq;
using TemplateFwExample.Shared.Domain.Enums;

namespace TemplateFwExample.Shared.Application.Exceptions
{
    public class BusinessError
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
    public class BusinessException : Exception
    {
        public List<BusinessError> Errors { get; set; } = new List<BusinessError>();

        #region Constructor

        public BusinessException(params ErrorCodes[] errorCodes)
            : base()
        {
            Errors.AddRange(errorCodes.Select(e=>new BusinessError { ErrorCode = ((int)e).ToString(), ErrorMessage=e.ToString() }));
        }

        public BusinessException(string message)
            : base()
        {
            Errors.Add(new BusinessError { ErrorCode = ((int)ErrorCodes.BadRequest).ToString(), ErrorMessage = message });
        }

        #endregion
    }
}
