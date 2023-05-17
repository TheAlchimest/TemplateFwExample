using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TemplateFwExample.Shared.Application.Exceptions;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Domain.GenericResponse;

namespace TemplateFwExample.DashboardApi.Controllers.Base
{
    [ApiController]
    public abstract class ApiControllerBase<TController> : ControllerBase
        where TController : ApiControllerBase<TController>
    {
        private readonly ILogger<TController> _logger;

        public string CurrentUserName => this.User?.Identity?.Name;

        protected bool IsArabic {
            get {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                return rqf.RequestCulture.Culture.Name.ToLower().Contains("ar");
            }
        }
        protected EnumLanguage CurrentLanguage {
            get {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                return (IsArabic) ? EnumLanguage.Arabic : EnumLanguage.English;
            }
        }
        protected ApiControllerBase(ILogger<TController> logger)
        {
            _logger = logger;
        }


        protected async Task<ApiResponse> ApiResponse<T>(Func<Task<T>> funcCall, OperationTypes operation = OperationTypes.Unknown)
        {
            try
            {
                var result = funcCall == null ? default : await funcCall.Invoke();
                var response = new ApiResponse
                {
                    Status = true
                };
                if (typeof(T) == typeof(bool))
                {
                    response.Status = Convert.ToBoolean(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return HandleException<T>(ex, operation);
            }
        }
        protected async Task<GenericApiResponse<T>> GenericApiResponse<T>(Func<Task<T>> funcCall, OperationTypes operation = OperationTypes.Unknown)
        {
            try
            {
                var result = funcCall == null ? default : await funcCall.Invoke();
                var response = new GenericApiResponse<T>
                {
                    Data = result,
                    Status = true
                };
                if (typeof(T) == typeof(bool))
                {
                    response.Status = Convert.ToBoolean(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return HandleException<T>(ex, operation);
            }
        }

        protected GenericApiResponse<T> GenericApiResponse<T>(Func<T> funcCall, OperationTypes operation = OperationTypes.Unknown)
        {
            try
            {
                var result = funcCall == null ? default : funcCall.Invoke();
                var response = new GenericApiResponse<T>
                {
                    Data = result,
                    Status = true
                };
                return response;
            }
            catch (Exception ex)
            {
                return HandleException<T>(ex, operation);
            }
        }

        protected ApiResponse ApiResponse(Action actionCall, OperationTypes operation = OperationTypes.Unknown)
        {
            return GenericApiResponse(() =>
            {
                actionCall();
                return new object();
            });
        }


        private GenericApiResponse<T> HandleException<T>(Exception ex, OperationTypes operation)
        {
            if (ex is BusinessException businessException)
            {
                return HandleBusinessException<T>(businessException, operation);
            }
            else
            {
                return HandleRunTimeException<T>(ex, operation);
            }
        }
        private GenericApiResponse<T> HandleBusinessException<T>(BusinessException businessException, OperationTypes operation)
        {
            GenericApiResponse<T> result = new GenericApiResponse<T>();
            result.Status = false;
            result.StatusCode = HttpStatusCode.BadRequest;
            if (businessException.Errors.Count > 0)
            {
                result.Errors.AddRange(businessException.Errors.Select(e => new CommonError
                {
                    ErrorCode = e.ErrorCode,
                    ErrorMessage = e.ErrorMessage
                }));
            }
            return result;
        }

        private GenericApiResponse<T> HandleRunTimeException<T>(Exception ex, OperationTypes operation)
        {
            GenericApiResponse<T> result = new GenericApiResponse<T>();
            result.Status = false;
            result.StatusCode = HttpStatusCode.InternalServerError;
            result.Errors.Add(new CommonError
            {
                ErrorCode = ((int)operation + 1000).ToString()
                //ErrorMessage = e.ErrorMessage
            });
            //log exception
            Task.Run(() => _logger.LogError(ex, ex.Message));
            return result;
        }
    }
}