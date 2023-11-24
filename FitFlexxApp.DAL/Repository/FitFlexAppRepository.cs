using FitFlexApp.DAL.Repository.Interface;
using FitFlexxApp.DAL.Context;
using FitFlexxApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitFlexxApp.DAL.Repository
{
    public class FitFlexAppRepository : IFitFlexAppRepository
    {
        private readonly FitFlexAppContext _context;
        public FitFlexAppRepository(FitFlexAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<User>> GetUsersListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetSingleUserIncludePlanAsync(int userId)
        {
            return await _context.Users.Include(u => u.Plans).Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
