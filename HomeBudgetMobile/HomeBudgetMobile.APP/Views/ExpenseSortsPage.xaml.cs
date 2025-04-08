using HomeBudgetMobile.APP.ViewModels;

namespace HomeBudgetMobile.APP.Views;

public partial class ExpenseSortsPage : ContentPage
{
    private readonly ExpenseSortsViewModel expenseSortsViewModel;

    public ExpenseSortsPage(ExpenseSortsViewModel expenseSortsViewModel)
	{
		InitializeComponent();
        BindingContext = expenseSortsViewModel;
        this.expenseSortsViewModel = expenseSortsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await expenseSortsViewModel.GetExpenses();
    }
}