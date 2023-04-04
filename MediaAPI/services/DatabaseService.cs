using Shared;

namespace MediaAPI.services
{
    public class DatabaseService : IDatabaseService
    {
        public MultiMediaAppContext Context { get; }
        public DatabaseService(MultiMediaAppContext context)
        {
            Context = context;
        }


        public async Task PostUserAsync(User user)
        {
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
        }

        public async Task<List<User>> GetUserList()
        {
            return Context.Users.ToList();
        }

        public async Task<User> GetUser(string username)//needs testing
        {
            return Context.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public async Task<Category> GetCategory(string name)//test it
        {
            return Context.Categories.Where(u => u.Category1 == name).FirstOrDefault();
        }

        internal void AddMedia(Media newMedia)//test it
        {
           Context.Media.Add(newMedia);
        }

        public Media GetMedia(string blobName)//test it
        {
            return Context.Media.Where(u => u.MediaKey == blobName).FirstOrDefault();
        }

        internal void AddMediaCategory(MediaCategory mediaCat)//test it
        {
            Context.MediaCategories.Add(mediaCat);
        }
    }
}
