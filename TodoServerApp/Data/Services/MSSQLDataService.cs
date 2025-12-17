using Microsoft.EntityFrameworkCore;
using TodoServerApp.Data.Interfaces;

namespace TodoServerApp.Data.Services
{
    public class MSSQLDataService(ApplicationDbContext context) : IDataService
    {
        public async Task<IEnumerable<Profile>> GetProfilesAsync()
        {
            return await context.Profiles.OrderByDescending(p => p.Id).ToArrayAsync();
        }

        public async Task AddProfileAsync(Profile profile)
        {
            profile.LastActive = DateTime.Now;
            await context.Profiles.AddAsync(profile);
            await context.SaveChangesAsync();
        }
    }
}