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

       
    }
}
