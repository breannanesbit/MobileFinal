using Mobile_final.ViewModels;

namespace Mobile_final;

public partial class HomeMediaPage : ContentPage
{
	public HomeMediaPage(HomeMediaViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}