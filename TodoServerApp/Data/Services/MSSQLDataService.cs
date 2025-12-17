using Microsoft.EntityFrameworkCore;
using TodoServerApp.Data.Interfaces;

namespace TodoServerApp.Data.Services
{
    public class MSSQLDataService(ApplicationDbContext context) : IDataService
    {
        public async Task<IEnumerable<Profile>> GetProfilesAsync()
        {
            return await context.Profiles
                .Include(p => p.Interests)
                .OrderByDescending(p => p.Id)
                .ToArrayAsync();
        }

        public async Task AddProfileAsync(Profile profile, List<int> interestIds)
        {
            profile.LastActive = DateTime.Now;

            await context.Profiles.AddAsync(profile);

            if (interestIds != null && interestIds.Count > 0)
            {
                foreach (var id in interestIds)
                {
                    var interestFromDb = await context.Interests.FindAsync(id);
                    if (interestFromDb != null)
                    {
                        profile.Interests.Add(interestFromDb);
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Interest>> GetInterestsAsync()
        {
            return await context.Interests.ToArrayAsync();
        }
    }
}