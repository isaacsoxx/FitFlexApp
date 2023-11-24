using AutoMapper;
using FitFlexApp.DAL.Entities;
using FitFlexApp.DTOs.Model;

namespace FitFlexApp.BLL.Profiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<Plan, PlansDTO>();
        }
    }
}
