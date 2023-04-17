using MediaAPI.Data;
using Shared;

namespace MediaAPI.services
{
    public interface IDatabaseService
    {
        MultiMediaAppContext Context { get; }

        Task<List<User>> GetUserList();
        Task PostUserAsync(User user);
    }
}