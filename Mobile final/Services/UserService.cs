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
            await http.PostAsJsonAsync<User>($"/api/v1/user", user);
        }

        public Task<List<User>> GetAllUsers()
        {
            return http.GetFromJsonAsync<List<User>>("/api/user/v1/all");
        }

        public async Task<User> GetCurrentUser()
        {
            var user = current.Username;
            var test = await http.GetFromJsonAsync<User>($"/api/user/v1/{user}");
            return test;
        }

        public async Task<List<Media>> GetUserMedia()
        {
            var user = current.Username;
            var mediaList = await http.GetFromJsonAsync<List<Media>>($"/api/user/v1/getusermedia/{user}");
            return mediaList;
        }

        internal async Task<Category> GetCategory(int categoryId)
        {
            var category = await http.GetFromJsonAsync<Category>($"/Media/v1/category/{categoryId}");

            return category;
        }

        internal async Task<List<Media>> GetMostRecentUploaded()
        {
            var mediaList = await http.GetFromJsonAsync<List<Media>>($"Media/v1/getlatestmedia");
            return mediaList;
        }


        public async Task SubmitComment(int id, string comment)
        {
            var user = GetCurrentUser();

            var c = new Comment()
            { 
                Comment1 = comment,
                MediaId = id,
                UserId = user.Id
            };

            var test = await http.PostAsJsonAsync<Comment>($"/comment/v2/submitcomment", c);
        }

        public async Task<Media> GetMediaByKey(string mediaKey)
        {
           return await http.GetFromJsonAsync<Media>($"/Media/v1/getmediabykey/{mediaKey}");
        }
    }
}
