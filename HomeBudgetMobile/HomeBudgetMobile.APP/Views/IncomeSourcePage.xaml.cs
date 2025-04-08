using HomeBudgetMobile.APP.Model.DTO.IncomeSource;
using HomeBudgetMobile.APP.ViewModels;

namespace HomeBudgetMobile.APP.Views;

public partial class IncomeSourcePage : ContentPage
{
    private readonly IncomeSourceViewModel incomeSourceViewModel;

    public IncomeSourcePage(IncomeSourceViewModel incomeSourceViewModel)
	{
		InitializeComponent();
        BindingContext = incomeSourceViewModel;
        this.incomeSourceViewModel = incomeSourceViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await incomeSourceViewModel.GetIncomeSourceList();
    }
}