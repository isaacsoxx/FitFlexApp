using FitFlexApp.DAL.Context;
using FitFlexApp.DAL.Entities;
using FitFlexApp.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FitFlexApp.DAL.Repository
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

        public async Task<bool> CreateSingleUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSingleUserAsync(User user)
        {
            _context.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
