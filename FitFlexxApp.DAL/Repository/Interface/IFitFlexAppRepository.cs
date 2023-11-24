using FitFlexxApp.DAL.Entities;

namespace FitFlexApp.DAL.Repository.Interface
{
    public interface IFitFlexAppRepository
    {
        Task<IEnumerable<User>> GetUsersListAsync();
        Task<User?> GetSingleUserIncludePlanAsync(int userId);
    }
}
