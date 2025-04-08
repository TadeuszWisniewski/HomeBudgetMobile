using HomeBudgetMobile.APP.ViewModels;

namespace HomeBudgetMobile.APP.Views;

public partial class IncomesPage : ContentPage
{
    private readonly IncomesViewModel incomesViewModel;

    public IncomesPage(IncomesViewModel incomesViewModel)
	{
		InitializeComponent();
		BindingContext = incomesViewModel;
        this.incomesViewModel = incomesViewModel;
    }

    protected override async void OnAppearing()
    {
        await incomesViewModel.GetPickerDataAsync();
        await incomesViewModel.GetIncomesList();
    }
}