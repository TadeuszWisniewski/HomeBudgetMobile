using HomeBudgetMobile.APP.ViewModels;

namespace HomeBudgetMobile.APP.Views;

public partial class SavingsPage : ContentPage
{
    private readonly SavingsViewModel savingsViewModel;
    public SavingsPage(SavingsViewModel savingsViewModel)
	{
		InitializeComponent();
		BindingContext = savingsViewModel;
        this.savingsViewModel = savingsViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await savingsViewModel.GetPickerDataAsync();
        await savingsViewModel.GetSavingsList();
    }
}