using FitFlexApp.DAL.Entities;

namespace FitFlexApp.DAL.Repository.Interface
{
    public interface IFitFlexAppRepository
    {
        Task<IEnumerable<User>> GetUsersListAsync();
        Task<User?> GetSingleUserIncludePlanAsync(int userId);
        Task<bool> CreateSingleUserAsync(User user);
        Task<bool> UpdateSingleUserAsync(User user);
    }
}
