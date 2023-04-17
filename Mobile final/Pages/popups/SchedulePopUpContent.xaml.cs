using CommunityToolkit.Maui.Views;
using Mobile_final.ViewModels;

namespace Mobile_final.Pages.popups;

public partial class SchedulePopUpContent : Popup
{
	public SchedulePopUpContent(SchedulePopUpViewModel vm)
	{
		BindingContext = vm;
		vm.popup = this;
		InitializeComponent();
	}
}