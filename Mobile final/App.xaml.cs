using Mobile_final.Auth0;
using Mobile_final.Pages;
using Mobile_final.ViewModels;

namespace Mobile_final;

public partial class App : Application
{

	public App(LoginViewModel vm, Auth0Client client)
	{
		InitializeComponent();

		MainPage = new MainPage(vm, client);
	}
}
