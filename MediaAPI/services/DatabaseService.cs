﻿using Microsoft.EntityFrameworkCore;
using Shared;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using MediaAPI.Data;

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


        public async Task<Category> GetCategory(string name)
        {
            return Context.Categories.Where(u => u.Category1 == name).FirstOrDefault();
        }

        /*public void AddMediaCategory(MediaCategory mediaCat)
        {
            Context.MediaCategories.Add(mediaCat);
            Context.SaveChangesAsync();
        }*/

        public IEnumerable<Media> GetMediaByUsername(string username)
        {
            List<Media> result = new List<Media>();
            var user = Context.Users.Where(u => u.Username == username).FirstOrDefault();
            var myList = Context.Media.Where(u => u.UserId == user.Id).ToList();
            return myList;
        }
        public void AddCategory(string cat)
        {
            Category category = new Category()
            {
                Category1 = cat

            };
            Context.Categories.Add(category);
            Context.SaveChangesAsync();
        }

        public async Task<List<Media>> GetLatestMediaAsync()
        {
            return await Context.Media.Include(m => m.Category).OrderByDescending(m => m.DateUpload).Take(15).ToListAsync();
        }

        public Category GetCategoryById(int categoryId)
        {
            return Context.Categories.Where(u => u.Id == categoryId).FirstOrDefault();
        }

        public async void AddAppointment(string username, DateTime start, DateTime end)
        {
            var user = await GetUserByUsername(username);
            Appointment appointment = new Appointment()
            {
                StartTime = start,
                EndTime = end,
                UserId = user.Id,
            };
            Context.Appointments.Add(appointment);
            await Context.SaveChangesAsync();
        }

        public List<Appointment> GetAllAppointments()
        {
            return Context.Appointments.ToList();
        }

        public void DeleteAppointment(int id)
        {
            var appointment = Context.Appointments.Where(a => a.Id == id).FirstOrDefault();
            if(appointment != null)
            {
                Context.Remove<Appointment>(appointment);
                Context.SaveChanges();
            }
        }
    }
}
