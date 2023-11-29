using AutoMapper;
using FitFlexApp.DAL.Entities;
using FitFlexApp.DTOs.Model;
using FitFlexApp.DTOs.Request;

namespace FitFlexApp.BLL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserIncludePlanDTO>();
            CreateMap<UserIncludePlanDTO, User>();
            CreateMap<UserRequestDto, User>();
        }
    }
}
