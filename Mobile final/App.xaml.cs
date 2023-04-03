using Mobile_final.Pages;
using Mobile_final.ViewModels;

namespace Mobile_final;

public partial class App : Application
{
	public App(LoginViewModel vm)
	{
		InitializeComponent();

		MainPage = new MainPage(vm);
	}
}
