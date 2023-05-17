using Microsoft.AspNetCore.Mvc;
using TemplateFw.Dashboard.Controllers;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;

namespace TemplateFw.Dashboard.Extensions
{
    public static class ControllersExtensions
    {

        public static JsonResult ReturnJsonxResponse<T>(this OperatinResultController controller, GenericApiResponse<T> apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = new GenericWebResponse<T>();
            response.PopulateResponse(apiResult, operation, controller.Localizer);
            return controller.Json(response);
        }
        public static JsonResult ReturnJsonResponse(this OperatinResultController controller, ApiResponse apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = new WebResponse();
            response.PopulateResponse(apiResult, operation, controller.Localizer);
            return controller.Json(response);
        }
    }
}
