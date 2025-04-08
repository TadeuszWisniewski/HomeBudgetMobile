using HomeBudgetMobile.APP.ViewModels;

namespace HomeBudgetMobile.APP.Views;

public partial class LogInPage : ContentPage
{
    private readonly LogInPageViewModel logInPageViewModel;

    public LogInPage(LogInPageViewModel logInPageViewModel)
	{
		InitializeComponent();
        BindingContext = logInPageViewModel;
        this.logInPageViewModel = logInPageViewModel;
    }

    //Robie tutaj bo nie mam Nav w view modelu
    //private async void NavToSignUp(object sender, EventArgs e)
    //{
    //    await Navigation.PushModalAsync(MainPage());
    //}
}