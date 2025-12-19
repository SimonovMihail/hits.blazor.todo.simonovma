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

        public async Task<List<Message>> GetMessagesAsync(int user1Id, int user2Id)
        {
            return await context.Messages
                .Include(m => m.Sender)   // подгружает имена, чтобы знать, кто пишет
                .Include(m => m.Receiver)
                .Where(m =>
                    (m.SenderId == user1Id && m.ReceiverId == user2Id) || // я писал ему
                    (m.SenderId == user2Id && m.ReceiverId == user1Id)    // он писал мне
                )
                .OrderBy(m => m.Created) // сортируем по времени (сначала старые, естесна)
                .ToListAsync();
        }

        public async Task SendMessageAsync(Message message)
        {
            message.Created = DateTime.Now; // ставим текущее время
            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();
        }

        public async Task<Profile> GetProfileByUserIdAsync(string userId)
        {
            // ищем профиль, у которого UserId совпадает с переданным
            return await context.Profiles
                .Include(p => p.Interests) // не забываем интересы
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}