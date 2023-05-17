using Microsoft.AspNetCore.Mvc.Rendering;
using TemplateFwExample.Dtos.Common;

namespace TemplateFwExample.Dashboard.Extensions
{
    public static class LookupExtensions
    {
        public static SelectList ToSelectList(this List<LookupDto> lokupList)
        {
            return new SelectList(lokupList, nameof(LookupDto.Id), nameof(LookupDto.Text));
        }
    }
}
