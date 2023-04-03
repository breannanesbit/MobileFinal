using Mobile_final.ViewModels;

namespace Mobile_final.Pages;

public partial class UploadPage : ContentPage
{
	public UploadPage(UploadFileViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;	
	}
}