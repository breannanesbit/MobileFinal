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

        public UserService(HttpClient http)
        {
            this.http = http;
        }

        public async void NewUserEntry(string firstname, string lastname, string username)
        {
            var user = new User()
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username
            };
            await http.PostAsJsonAsync<User>($"/api/user", user);
        }

    }
}
