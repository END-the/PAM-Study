using PAM_Study.ViewModels;
namespace PAM_Study.Views;

public partial class MonitoresView : ContentPage
{
	public MonitoresView()
	{
		BindingContext = new MonitoresViewModel();
		InitializeComponent();
	}
}