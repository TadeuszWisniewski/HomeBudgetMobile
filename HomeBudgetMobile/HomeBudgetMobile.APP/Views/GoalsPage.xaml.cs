using HomeBudgetMobile.APP.ViewModels;

namespace HomeBudgetMobile.APP.Views;

public partial class GoalsPage : ContentPage
{
    private readonly GoalsViewModel goalsViewModel;

    public GoalsPage(GoalsViewModel goalsViewModel)
	{
		InitializeComponent();
		BindingContext = goalsViewModel;
        this.goalsViewModel = goalsViewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await goalsViewModel.GetGoalsList();
    }
}