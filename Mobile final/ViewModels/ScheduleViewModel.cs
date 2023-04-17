using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile_final.Pages.popups;
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
        public ObservableCollection<SchedulerAppointment> Events { get; set; }

        [RelayCommand]
        public async void AddEventPopUp()
        {
            //var popup = new SchedulePopUpContent;
            //string result = await Application.Current.MainPage.DisplayPromptAsync("Make appointment", "");
            //display pop up that gets all the infomation then creates and adds an event to the Events 
            
            //Events.Add(n);
        }
    }

}
