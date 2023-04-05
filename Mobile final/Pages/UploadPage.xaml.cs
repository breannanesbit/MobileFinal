using Mobile_final.ViewModels;

namespace Mobile_final.Pages;

public partial class UploadPage : ContentPage
{
	UploadFileViewModel vm;
	public UploadPage(UploadFileViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
		this.vm = vm;
	}

	void OnRadioSelected(object sender, CheckedChangedEventArgs e)
	{
		vm.MediaOptionSelected = true;
    }
}