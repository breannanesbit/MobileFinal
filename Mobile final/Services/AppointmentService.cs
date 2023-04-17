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
    public class AppointmentService
    {
        private readonly HttpClient http;
        private readonly CurrentUser current;

        public AppointmentService(HttpClient http, CurrentUser current)
        {
            this.http = http;
            this.current = current;
        }
        public async Task CreateAppointment(Appointment appoint)
        {
            await http.PostAsJsonAsync<Appointment>($"/appointment/AddAppointment", appoint);
        }
    }
}
