using Mobile_final.ViewModels;

namespace Mobile_final.Pages;

public partial class UploadPage : ContentPage
{
	UploadFileViewModel vm;
	public UploadPage(UploadFileViewModel vm)
	{
		BindingContext= vm;
        vm.Page = this;
        this.vm = vm;
		InitializeComponent();
	}

	void OnRadioSelected(object sender, CheckedChangedEventArgs e)
	{
		vm.MediaOptionSelected = true;
    }
}