using Mobile_final.ViewModels;

namespace Mobile_final;

public partial class SchedulePage : ContentPage
{
	public SchedulePage(ScheduleViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}