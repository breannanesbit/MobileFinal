using Mobile_final.ViewModels;

namespace Mobile_final;

public partial class UploadPage : ContentPage
{
	public UploadPage(UploadFileViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;	
	}
}