using Mobile_final.ViewModels;

namespace Mobile_final;

public partial class MainPage : ContentPage
{
	public MainPage(UploadFileViewModel model)
	{

		InitializeComponent();
		BindingContext= model;
	}



	
}

