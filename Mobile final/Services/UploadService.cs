using Microsoft.Maui.Storage;
using Mobile_final.Auth0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.Services
{
    public class UploadService
    {
        private readonly CurrentUser user;
        private readonly HttpClient http;

        public UploadService(CurrentUser user, HttpClient http)
        {
            this.user = user;
            this.http = http;
        }

        public async Task UploadNewFile(string type, string fileName, MultipartFormDataContent convertedForm)
        {
            var username = user.Username;
            var test = await http.PostAsJsonAsync<MultipartFormDataContent>($"/media/uploadfile/{type}/{username}/{fileName}", convertedForm);
            
        }
    }
}
