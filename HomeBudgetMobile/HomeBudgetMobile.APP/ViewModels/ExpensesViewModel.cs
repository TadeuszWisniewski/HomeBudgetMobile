using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Model.DTO.Expense;
using HomeBudgetMobile.APP.Model.DTO.ExpenseSort;
using HomeBudgetMobile.APP.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;

namespace HomeBudgetMobile.APP.ViewModels
{
    public partial class ExpensesViewModel: BaseViewModel
    {
        const string editButtonText = "Update Expense";
        const string createButtonText = "Add Expense";
        private readonly HbmApiService hbmApiService;
        string message = string.Empty;

        public ObservableCollection<ExpenseDto>? Expenses { get; private set; } = new();
       
        public ObservableCollection<ExpenseSortDto>? ExpenseSorts { get; private set; } = new();

        public ExpensesViewModel(HbmApiService hbmApiService)
        {
            Title = "Expenses";
            addEditButtonText = createButtonText;
            this.hbmApiService = hbmApiService;
            //expenseSorts = DependencyService.Get<HbmApiService>().GetExpenseSortsAsync().GetAwaiter().GetResult().ToList();
            //selectedExpenseSort = new ExpenseSortDto();
        }

        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        decimal amount;
        [ObservableProperty]
        string amountValue;
        [ObservableProperty]
        char currency = 'w';
        [ObservableProperty]
        string? description;
        [ObservableProperty]
        Guid expenseSortId;
        [ObservableProperty]
        string addEditButtonText;
        [ObservableProperty]
        Guid expenseId;
        [ObservableProperty]
        bool isActive = true;
        [ObservableProperty]
        ExpenseSortDto selectedExpenseSort;

        public async Task GetPickerDataAsync()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (ExpenseSorts.Any()) ExpenseSorts.Clear();
                var expenseSorts = new List<ExpenseSortDto>();
                expenseSorts = await hbmApiService.GetExpenseSortsAsync();

                foreach (var expense in expenseSorts) ExpenseSorts.Add(expense);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get expense sorts: {ex.Message}");
                await ShowAlert("Failed to retrive list of expense sorts.");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async Task GetExpensesList()
        {
            if (IsLoading) return;
            await GetPickerDataAsync();
            try
            {
                IsLoading = true;
                if (Expenses.Any()) Expenses.Clear();
                var expenses = new List<ExpenseDto>();

                var user = await hbmApiService.GetUserByEmailAsync(Email);

                expenses = user.Expenses;

                foreach (var expense in expenses) Expenses.Add(expense);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get expenses: {ex.Message}");
                await ShowAlert("Failed to retrive list of expenses.");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        //[RelayCommand]
        //async Task GetExpenseDetails(Guid id)
        //{
        //    if (id == Guid.Empty) return;

        //    await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);
        //}

        [RelayCommand]
        async Task SaveExpense()
        {
            if (Amount == null || Currency.Equals('w') || SelectedExpenseSort == null || Currency.Equals(null) || Amount == decimal.Zero)
            {
                await ShowAlert("Please insert valid data");
                return;
            }

            if (!ExpenseId.Equals(Guid.Empty))
            {

                var expense = new UpdateExpenseDto
                {
                    Amount = Amount,
                    Currency = Currency,
                    Description = Description,
                    IsActive = IsActive,
                    ExpenseSortId = SelectedExpenseSort.Id,
                };

                await hbmApiService.UpdateExpense(ExpenseId, expense);
                message = hbmApiService.StatusMessage;
            }
            else
            {
                var expense = new CreateExpenseDto
                {
                    Amount = Amount,
                    Currency = Currency,
                    Description = Description,
                    IsActive = IsActive,
                    ExpenseSortId = SelectedExpenseSort.Id,
                };
                var addedExpense = await hbmApiService.AddExpenseAsync(expense);
                message = hbmApiService.StatusMessage;

                Guid[] guids = new Guid[3];

                guids[0] = Guid.Empty;
                guids[1] = addedExpense.Id;
                guids[2] = Guid.Empty;

                var userForApi = await hbmApiService.GetUserByEmailAsync(Email);
                Guid guidForApi = userForApi.Id;

                try
                {
                    await hbmApiService.UpdateUser(guidForApi, guids);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unable to update: {ex.Message}");
                }

            }
            await ShowAlert(message);
            await GetExpensesList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteExpense(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                await ShowAlert("Please try again");
                return;
            }

            await hbmApiService.DeleteExpenseAsync(id);
            message = hbmApiService.StatusMessage;

            await ShowAlert(message);
            await GetExpensesList();
        }

        [RelayCommand]
        async Task UpdateExpense(Guid id)
        {
            AddEditButtonText = editButtonText;
            return;
        }

        [RelayCommand]
        async Task SetEditMode(Guid id)
        {
            AddEditButtonText = editButtonText;
            ExpenseId = id;
            ExpenseDto expenseDto;

            expenseDto = await hbmApiService.GetExpenseAsync(ExpenseId);


            Amount =expenseDto.Amount;
            Currency = expenseDto.Currency;
            Description = expenseDto.Description;
            IsActive = expenseDto.IsActive;
            SelectedExpenseSort = await hbmApiService.GetExpenseSortAsync(expenseDto.ExpenseSortId);
            ExpenseSortId = expenseDto.ExpenseSortId;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            ExpenseId = Guid.Empty;
            Amount = default;
            Currency = 'w';
            Description = String.Empty;
            IsActive= default;
            ExpenseSortId = Guid.Empty;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
