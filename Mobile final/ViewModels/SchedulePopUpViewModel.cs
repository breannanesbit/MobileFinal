using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.ViewModels
{
    public partial class SchedulePopUpViewModel: ObservableObject
    {
        public Popup popup { get; set; }
        private readonly IUserService uService;

        public SchedulePopUpViewModel( IUserService uService)
        {
            this.uService = uService;
        }

        [ObservableProperty]
        private DateTime date;

        [ObservableProperty]
        private TimeSpan timeStart;

        [ObservableProperty]
        private TimeSpan timeEnd;

        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private DateTime dateNow = DateTime.Now;


        [RelayCommand]
        public async void MakeAppointment()
        {
            var dtStart = Date + TimeStart;
            var dtEnd = Date + TimeEnd;

            var user = uService.GetCurrentUser();

            var appoint = new Appointment()
            {
                Description = Description,
                StartTime = dtStart,
                EndTime = dtEnd,
                UserId = user.Id,
            };

            await uService.CreateAppointment(appoint);
            popup.Close();  

        }

    }
}
