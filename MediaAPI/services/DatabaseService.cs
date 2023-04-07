﻿using Microsoft.EntityFrameworkCore;
using Shared;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

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
        public async Task<User> GetUserByUsername(string v)
        {
            var user = await Context.Users.Where(x => x.Username == v).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
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
            Media media = await Context.Media
                .Where(w => w.MediaKey == v)
                .FirstOrDefaultAsync();

            if (media == null)
            {
                throw new NotFoundException($"Media with key '{v}' was not found.");
            }

            return media;
        }


        public async Task<Category> GetCategory(string name)//test it
        {
            return Context.Categories.Where(u => u.Category1 == name).FirstOrDefault();
        }

        public async Task AddMedia(Media newMedia)//test it
        {
            Context.Media.Add(newMedia);
            await Context.SaveChangesAsync();
        }
        public void AddMediaCategory(MediaCategory mediaCat)//test it
        {
            Context.MediaCategories.Add(mediaCat);
        }

        public IEnumerable<Media> GetMediaByUsername(string username)
        {
           List<Media> result = new List<Media>();
            var user = Context.Users.Where(u => u.Username == username).FirstOrDefault();
            var myList = Context.Media.Where(u=> u.UserId == user.Id).ToList();
            return myList;
        }
    }
}
