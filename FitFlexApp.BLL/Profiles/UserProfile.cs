using AutoMapper;
using FitFlexApp.DAL.Entities;
using FitFlexApp.DTOs.Model;

namespace FitFlexApp.BLL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserIncludePlanDTO>();
        }
    }
}
