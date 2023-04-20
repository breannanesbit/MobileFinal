using Mobile_final.ViewModels;

namespace Mobile_final.Pages;

public partial class SchedulePage : ContentPage
{
	public SchedulePage(ScheduleViewModel vm)
	{
		BindingContext= vm;
		vm.Page = this;
		InitializeComponent();
	}
}