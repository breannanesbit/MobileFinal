using Mobile_final.ViewModels;

namespace Mobile_final;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}