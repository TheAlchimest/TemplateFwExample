using AutoMapper;
using CITC.Dashboard.Domain.Dtos.FAQ;
using CITC.Dashboard.Domain.Models.FAQ;

namespace CITC.Dashboard.ApplicationServices.Mapping
{
    public class DashboardProfile : Profile
    {
        public DashboardProfile()
        {
            CreateMap<FaqDto, Faq>();
        }
    }
}
