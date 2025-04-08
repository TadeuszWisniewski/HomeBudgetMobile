using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Model.DTO.Expense;
using HomeBudgetMobile.APP.Model.DTO.Income;
using HomeBudgetMobile.APP.Model.DTO.Saving;
using HomeBudgetMobile.APP.Services;
using HomeBudgetMobile.APP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.APP.ViewModels
{
    public partial class SummaryViewModel: BaseViewModel
    {
        private readonly HbmApiService hbmApiService;

        public ObservableCollection<ExpenseDto> Expenses { get; private set; } = new();
        public ObservableCollection<IncomeDto> Incomes { get; private set; } = new();
        public ObservableCollection<SavingDto> Savings { get; private set; } = new();

        public SummaryViewModel(HbmApiService hbmApiService)
        {
            this.hbmApiService = hbmApiService;
        }

        //[ObservableProperty]
        //Guid idUser;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string incomesValue;

        [ObservableProperty]
        string expensesValue;

        [ObservableProperty]
        string savingsValue;

        [ObservableProperty]
        string goalsValue;

        //[RelayCommand]
        public async Task GetExpensesTotalValue()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Expenses.Any()) Expenses.Clear();
                var expenses = new List<ExpenseDto>();

                var user = await hbmApiService.GetUserByEmailAsync(Email);

                expenses = user.Expenses;


                foreach (var expense in expenses) Expenses.Add(expense);

                ExpensesValue = Expenses.Sum(x => x.Amount).ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get expenses: {ex.Message}");
                await ShowAlert("Failed to retrive expenses");
            }
            finally
            {
                IsLoading = false;
                isRefreshing = false;
            }
        }
        public async Task GetIncomesTotalValue()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Incomes.Any()) Incomes.Clear();
                var incomes = new List<IncomeDto>();

                var user = await hbmApiService.GetUserByEmailAsync(Email);

                incomes = user.Incomes;


                foreach (var income in incomes) Incomes.Add(income);

                IncomesValue = Incomes.Sum(x => x.Amount).ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get expenses: {ex.Message}");
                await ShowAlert("Failed to retrive expenses");
            }
            finally
            {
                IsLoading = false;
                isRefreshing = false;
            }
        }

        public async Task GetSavingsTotalValue()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Savings.Any()) Savings.Clear();
                var savings = new List<SavingDto>();

                var user = await hbmApiService.GetUserByEmailAsync(Email);

                savings = user.Savings;


                foreach (var saving in savings) Savings.Add(saving);

                SavingsValue = Savings.Sum(x => x.Amount).ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get expenses: {ex.Message}");
                await ShowAlert("Failed to retrive expenses");
            }
            finally
            {
                IsLoading = false;
                isRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToIncomes()
        {
            await Shell.Current.GoToAsync($"{nameof(IncomesPage)}?email={Email}");
        }

        [RelayCommand]
        async Task GoToIncomeSources()
        {
            await Shell.Current.GoToAsync($"{nameof(IncomeSourcePage)}?email={Email}");
        }

        [RelayCommand]
        async Task GoToExpenses()
        {
            await Shell.Current.GoToAsync($"{nameof(ExpensesPage)}?email={Email}");
        }

        [RelayCommand]
        async Task GoToExpenseSorts()
        {
            await Shell.Current.GoToAsync($"{nameof(ExpenseSortsPage)}?email={Email}");
        }

        [RelayCommand]
        async Task GoToSavings()
        {
            await Shell.Current.GoToAsync($"{nameof(SavingsPage)}?email={Email}");
        }

        [RelayCommand]
        async void GoToGoals()
        {
            await Shell.Current.GoToAsync($"{nameof(GoalsPage)}?email={Email}");
        }

        [RelayCommand]
        void ResetAll()
        {
            return;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
