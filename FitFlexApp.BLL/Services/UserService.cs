using AutoMapper;
using FitFlexApp.BLL.Services.Interface;
using FitFlexApp.DAL.Repository.Interface;
using FitFlexApp.DTOs.Model;

namespace FitFlexApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IFitFlexAppRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IFitFlexAppRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponseDTO<IEnumerable<UserDTO>>> GetUsersListAsync()
        {
            var serviceResponse = new ServiceResponseDTO<IEnumerable<UserDTO>>();
            var usersList = await _repository.GetUsersListAsync();
            serviceResponse.Data = _mapper.Map<IEnumerable<UserDTO>>(usersList);
            return serviceResponse;
        }

        public async Task<ServiceResponseDTO<UserIncludePlanDTO>> GetUserByIdIncludePlanAsync(int userId)
        {
            var serviceResponse = new ServiceResponseDTO<UserIncludePlanDTO>();
            var user = await _repository.GetSingleUserIncludePlanAsync(userId);

            if (user != null)
            {
                serviceResponse.Data = _mapper.Map<UserIncludePlanDTO>(user);
            }
            else
            {
                serviceResponse.Message = $"User with id {userId} was not found!";
                serviceResponse.Error = true;
                serviceResponse.StatusCode = 404;
            }
            return serviceResponse;
        }

    }
}
