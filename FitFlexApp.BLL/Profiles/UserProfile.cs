using AutoMapper;
using FitFlexApp.DTOs.Model;
using FitFlexxApp.DAL.Entities;

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
