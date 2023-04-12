using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.ViewModels
{
    public class ScheduleViewModel: ObservableObject
    {
        public ObservableCollection<SchedulerAppointment> Events { get; set; }

        [RelayCommand]
        public void AddEventPopUp()
        {
            //display pop up that gets all the infomation then creates and adds an event to the Events 
        }
    }

    /// <summary>    
    /// Represents the custom data properties.    
    /// </summary>  
    //public class Meeting
    //{
    //    public DateTime From { get; set; }
    //    public DateTime To { get; set; }
    //    public bool IsAllDay { get; set; }
    //    public string EventName { get; set; }
    //    public TimeZoneInfo StartTimeZone { get; set; }
    //    public TimeZoneInfo EndTimeZone { get; set; }
    //    public Brush Background { get; set; }
    //}
}
