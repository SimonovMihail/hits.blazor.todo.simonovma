using TodoServerApp.Data;

namespace TodoServerApp.Data.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<Profile>> GetProfilesAsync();

        Task AddProfileAsync(Profile profile, List<int> interestIds);

        Task<IEnumerable<Interest>> GetInterestsAsync();

        Task<List<Message>> GetMessagesAsync(int user1Id, int user2Id);

        Task SendMessageAsync(Message message);
    }
}