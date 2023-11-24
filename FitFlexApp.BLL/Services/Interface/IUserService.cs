using FitFlexApp.DTOs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFlexApp.BLL.Services.Interface
{
    public interface IUserService
    {
        Task<ServiceResponseDTO<IEnumerable<UserDTO>>> GetUsersListAsync();
        Task<ServiceResponseDTO<UserIncludePlanDTO>> GetUserByIdIncludePlanAsync(int userId);
    }
}
