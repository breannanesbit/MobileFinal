using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Pages.popups;
using Mobile_final.Services;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.ViewModels
{
    public partial class ScheduleViewModel : ObservableObject
    {
        private readonly AppointmentService appointmentService;
        private readonly UserService userService;

        public ObservableCollection<SchedulerAppointment> Events { get; set; }
        public ScheduleViewModel(AppointmentService appointmentService, UserService userService)
        {
            this.appointmentService = appointmentService;
            this.userService = userService;
        }

        [RelayCommand]
        public async void AddEventPopUp()
        {
            var popupVm = new SchedulePopUpViewModel(appointmentService, userService);
            var popup = new SchedulePopUpContent(popupVm);

            //await Page.ShowPopupAsync(popup);
            //string result = await Application.Current.MainPage.DisplayPromptAsync("Make appointment", "");
            //display pop up that gets all the infomation then creates and adds an event to the Events 
            
            //Events.Add(n);
        }
    }

}
