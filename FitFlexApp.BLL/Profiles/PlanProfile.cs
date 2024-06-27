using AutoMapper;
using FitFlexApp.DAL.Entities;
using FitFlexApp.DTOs.Model;
using FitFlexApp.DTOs.Request;

namespace FitFlexApp.BLL.Profiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<TrainingPlan, PlanDTO>();
            CreateMap<PlanDTO, TrainingPlan>();
        }
    }
}
