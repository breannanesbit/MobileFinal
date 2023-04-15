using Azure;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using MediaAPI.services;
using Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MediaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : Controller
    {
        private readonly DatabaseService database;

        public AppointmentController(DatabaseService service)
        {

            database = service;
        }


        [HttpPost("uploadappointment/{username}/{starttime}/{endtime}")]
        public void UploadAppoinment(string username, DateTime starttime, DateTime endtime)
        {
            database.AddAppointment(username, starttime, endtime);
        }

        [HttpGet("getappointments")]
        public List<Appointment> GetAppointments()
        {
            return database.GetAllAppointments();
        }
        [HttpDelete("deleteappointment/{id}")]
        public void DeleteAppointments(int id)
        {
            database.DeleteAppointment(id);
        }
    }
}
