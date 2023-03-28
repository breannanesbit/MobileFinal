using Mobile_final.Auth0;
using Mobile_final.ViewModels;

namespace Mobile_final;


public partial class MainPage : ContentPage
{
	public MainPage(LoginViewModel model)
	{
        InitializeComponent();
        BindingContext = model;
    }

}
    