using Microsoft.EntityFrameworkCore;
using Shared;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
        public Task<User> GetUserByUsername(string v)
        {
            return Context.Users.FirstAsync(x => x.Username == v);
        }


        public async Task PostMediaAsync(Media media)
        {
            await Context.Media.AddAsync(media);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Media>> GetAllMedia()
        {
            return Context.Media.ToList();
        }

        public List<Media> GetAllUserMedia(int v)
        {
            return Context.Media.Where(w => w.UserId == v).ToList();
        }

        public async Task<Media> GetMediaByKey(string v)
        {
            var media =  await Context.Media
                .Where(w => w.MediaKey == v)
                .FirstOrDefaultAsync();

            if (media == null)
            {
                throw new NotFoundException($"Media with key '{v}' was not found.");
            }

            return media;
        }

        
    }
}
