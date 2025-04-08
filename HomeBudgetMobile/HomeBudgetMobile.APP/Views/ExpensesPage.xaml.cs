using HomeBudgetMobile.APP.Model.DTO.ExpenseSort;
using HomeBudgetMobile.APP.Services;
using HomeBudgetMobile.APP.ViewModels;

namespace HomeBudgetMobile.APP.Views;

public partial class ExpensesPage : ContentPage
{
    private readonly ExpensesViewModel expensesViewModel;

    public ExpensesPage(ExpensesViewModel expensesViewModel)
	{
		InitializeComponent();
		BindingContext = expensesViewModel;
        this.expensesViewModel = expensesViewModel;
    }

    protected override async void OnAppearing()
    {
        await expensesViewModel.GetPickerDataAsync();
        await expensesViewModel.GetExpensesList();
    }
}