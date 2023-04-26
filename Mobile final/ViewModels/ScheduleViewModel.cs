using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Pages.popups;
using Mobile_final.Services;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.ViewModels
{
    public partial class ScheduleViewModel : ObservableObject
    {
        private readonly AppointmentService appointmentService;
        private readonly UserService userService;
        public ContentPage Page { get; set; } = new();

        [ObservableProperty]
        private ObservableCollection<SchedulerAppointment> events;
        public ScheduleViewModel(AppointmentService appointmentService, UserService userService)
        {
            this.appointmentService = appointmentService;
            this.userService = userService;
        }

        [RelayCommand]
        public async void Start()
        {
            Color pinkypurple = Color.FromHex("ECC8F5");
            var solidBrush = new SolidColorBrush(pinkypurple);
            Events = new();
            var appointmentList = await userService.GetAllAppointments();
            foreach (var appointment in appointmentList)
            {

                var sa = new SchedulerAppointment()
                {
                    StartTime = appointment.StartTime,
                    EndTime = appointment.EndTime,
                    Subject = appointment.Description,
                    Id = appointment.UserId,
                    Background = pinkypurple,
                    IsAllDay = false,
                };

                Events.Add(sa);
            }
        }

        
        [RelayCommand]
        public async void AddEventPopUp()
        {
            var VMpopup = new SchedulePopUpViewModel(userService);
            var popup = new SchedulePopUpContent(VMpopup);
            await Page.ShowPopupAsync(popup);
            //string result = await Application.Current.MainPage.DisplayPromptAsync("Make appointment", "");
            //display pop up that gets all the infomation then creates and adds an event to the Events 
            
            //Events.Add(n);
        }
    }

}
