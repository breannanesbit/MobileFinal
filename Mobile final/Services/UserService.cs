using Mobile_final.Auth0;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.Services
{
    public class UserService
    {
        private readonly HttpClient http;
        private readonly CurrentUser current;

        public UserService(HttpClient http, CurrentUser current)
        {
            this.http = http;
            this.current = current;
        }

        public async Task NewUserEntry(string firstname, string lastname, string username)
        {
            var user = new User()
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username
            };
            await http.PostAsJsonAsync<User>($"/api/user", user);
        }

        public Task<List<User>> GetAllUsers()
        {
            return http.GetFromJsonAsync<List<User>>("/api/user/all");
        }

        public async Task<User> GetCurrentUser()
        {
            var user = current.Username;
            var test = await http.GetFromJsonAsync<User>($"/api/user/{user}");
            return test;
        }

        public async Task<List<Media>> GetUserMedia()
        {
            var user = current.Username;
            var mediaList = await http.GetFromJsonAsync<List<Media>>($"/api/user/getusermedia/{user}");
            return mediaList;
        }

        internal async Task<Category> GetCategory(int categoryId)
        {
            var category = await http.GetFromJsonAsync<Category>($"/media/category/{categoryId}");

            return category;
        }

        internal async Task<List<Media>> GetMostRecentUploaded()
        {
            var mediaList = await http.GetFromJsonAsync<List<Media>>($"/api/user/getlatestmedia");
            return mediaList;
        }

        internal async Task<string> GetMediaCategory(Media media)
        {
            foreach(var medcat in media.MediaCategories)
            {
                if(medcat.CategoryId < 3)
                {
                    Category cat = await GetCategory(medcat.CategoryId);
                    return cat.Category1;
                }
            }
            return "";
        }
    }
}
