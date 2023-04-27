using Mobile_final.Auth0;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Mobile_final.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient http1;
        private readonly HttpClient http2;
        private readonly CurrentUser current;


        public UserService(HttpClient http1,
            HttpClient http2)
        {
            this.http1 = http1;
            this.http2 = http2;
        }



        public string Username { get; set; }
        public string AuthenticationID { get; set; }

        public async Task NewUserEntry(string firstname, string lastname, string username)
        {
            var user = new User()
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username
            };
            await http1.PostAsJsonAsync<User>($"/api/v1/user", user);
        }

        public Task<List<User>> GetAllUsers()
        {
            return http1.GetFromJsonAsync<List<User>>("/api/user/v1/all");
        }

        public async Task<User> GetCurrentUser()
        {
            //var user = current.Username;
            var test = await http1.GetFromJsonAsync<User>($"/api/user/v1/{Username}");
            return test;
        }

        public async Task<List<Media>> GetUserMedia()
        {
            //var user = current.Username;
            var mediaList = await http1.GetFromJsonAsync<List<Media>>($"/api/user/v1/getusermedia/{Username}");
            return mediaList;
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            var category = await http1.GetFromJsonAsync<Category>($"/Media/v1/category/{categoryId}");

            return category;
        }

        public async Task<List<Media>> GetMostRecentUploaded()
        {
            var mediaList = await http1.GetFromJsonAsync<List<Media>>($"Media/v1/getlatestmedia");
            return mediaList;

            /*var count = 30;
            var mediaList = await http2.GetFromJsonAsync<List<Media>>($"v2/getlatestmedia/{count}");
            return mediaList;*/
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

            var test = await http1.PostAsJsonAsync<Comment>($"/comment/v1/submitcomment", c);
        }

        public async Task<List<Comment>> GetAllCommentsForMediaElement(int id)
        {
            //var test1 = await http1.GetFromJsonAsync<List<Comment>>($"v1/allcomments");
            return await http2.GetFromJsonAsync<List<Comment>>($"/comment/v2/allcomments/{id}");
        }

        public async Task<Media> GetMediaByKey(string mediaKey)
        {
            return await http1.GetFromJsonAsync<Media>($"/Media/v1/getmediabykey/{mediaKey}");
        }

        public async Task CreateAppointment(Appointment appoint)
        {
            await http1.PostAsJsonAsync<Appointment>($"/appointment/v1/AddAppointment", appoint);
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await http1.GetFromJsonAsync<List<Appointment>>($"/appointment/v1/getappointments");
        }

        public async Task UploadNewFile(string type, string fileName, MultipartFormDataContent convertedForm)
        {
            var test = await http1.PostAsync($"/media/v1/uploadfile/{type}/{Username}/{fileName}", convertedForm);
            //var test2 = await http2.PostAsync($"/media/v2/uploadfile/{type}/{Username}/{fileName}", convertedForm);


        }

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetAuthID(string authID)
        {
            AuthenticationID = authID;
        }
    }
}
