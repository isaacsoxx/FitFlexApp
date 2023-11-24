using AutoMapper;
using FitFlexApp.DTOs.Model;
using FitFlexxApp.DAL.Entities;

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
