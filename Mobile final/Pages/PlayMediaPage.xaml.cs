using Mobile_final.ViewModels;

namespace Mobile_final.Pages;

public partial class PlayMediaPage : ContentPage
{
	public PlayMediaPage(PlayMediaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		Shell.SetTabBarIsVisible(this, false);
	}
}