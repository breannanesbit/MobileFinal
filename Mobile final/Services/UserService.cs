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

        public Task<User> GetCurrentUser()
        {
            var user = current.Username;
            var test = http.GetFromJsonAsync<User>($"/api/user/current/{user}");
            return test;
        }

        public Task<List<Media>> GetUserMedia()
        {
            var user = current.Username;
            return http.GetFromJsonAsync<List<Media>>($"getusermedia/{user}");
        }
    }
}
