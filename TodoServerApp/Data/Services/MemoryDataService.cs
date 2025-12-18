using TodoServerApp.Data.Interfaces;

namespace TodoServerApp.Data.Services
{
    public class MemoryDataService : IDataService
    {
        private static IEnumerable<Profile> profiles = new List<Profile>
        {
            new() { Id = 1, Name = "Алиса", Age = 21, City = "Москва", Bio = "Ищу программиста", LastActive = DateTime.Now },
            new() { Id = 2, Name = "Боб", Age = 25, City = "Питер", Bio = "Люблю Blazor", LastActive = DateTime.Now.AddDays(-1) },
            new() { Id = 3, Name = "Ева", Age = 23, City = "Казань", Bio = "Просто смотрю", LastActive = DateTime.Now.AddHours(-5) }
        };

        public Task AddProfileAsync(Profile profile, List<int> interestIds)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Interest>> GetInterestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetMessagesAsync(int user1Id, int user2Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Profile>> GetProfilesAsync()
        {
            await Task.Delay(1000);
            return await Task.FromResult(profiles);
        }

        public Task SendMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}