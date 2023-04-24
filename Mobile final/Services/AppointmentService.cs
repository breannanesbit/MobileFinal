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

        public AppointmentService(HttpClient http)
        {
            this.http = http;
       
        }
        public async Task CreateAppointment(Appointment appoint)
        {
            await http.PostAsJsonAsync<Appointment>($"/appointment/v1/AddAppointment", appoint);
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
           return await http.GetFromJsonAsync<List<Appointment>>($"/appointment/v1/getappointments");
        }
    }
}
