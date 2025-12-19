using TodoServerApp.Data.Interfaces;

namespace TodoServerApp.Data.Services
{
    public class MemoryDataService : IDataService
    {

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

        public Task<Profile> GetProfileByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> GetProfilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}