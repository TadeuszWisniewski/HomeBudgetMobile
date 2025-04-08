using HomeBudgetMobile.APP.ViewModels;

namespace HomeBudgetMobile.APP.Views;

public partial class SummaryPage : ContentPage
{
    private readonly SummaryViewModel summaryViewModel;

    public SummaryPage(SummaryViewModel summaryViewModel)
	{
		InitializeComponent();
		BindingContext = summaryViewModel;
        this.summaryViewModel = summaryViewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await summaryViewModel.GetExpensesTotalValue();
        await summaryViewModel.GetIncomesTotalValue();
        await summaryViewModel.GetSavingsTotalValue();
    }
}