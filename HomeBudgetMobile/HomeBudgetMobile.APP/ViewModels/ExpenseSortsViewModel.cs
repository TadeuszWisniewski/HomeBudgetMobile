using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Model.DTO.ExpenseSort;
using HomeBudgetMobile.APP.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HomeBudgetMobile.APP.ViewModels
{
    public partial class ExpenseSortsViewModel: BaseViewModel
    {
        const string editButtonText = "Update";
        const string createButtonText = "Add";
        private readonly HbmApiService hbmApiService;
        string message = string.Empty;

        public ObservableCollection<ExpenseSortDto> ExpenseSorts { get; private set; } = new();

        public ExpenseSortsViewModel(HbmApiService hbmApiService)
        {
            Title = "Expense sorts";
            addEditButtonText = createButtonText;
            this.hbmApiService = hbmApiService;
        }

        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string? description;
        [ObservableProperty]
        bool isActive = true;
        [ObservableProperty]
        string addEditButtonText;
        [ObservableProperty]
        Guid expenseSortId = Guid.Empty;

        public async Task GetExpenses()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (ExpenseSorts.Any()) ExpenseSorts.Clear();
                var expenseSorts = new List<ExpenseSortDto>();

                expenseSorts = await hbmApiService.GetExpenseSortsAsync();

                foreach (var expenseSort in expenseSorts) ExpenseSorts.Add(expenseSort);
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
        public async Task GetExpenseSortsList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (ExpenseSorts.Any()) ExpenseSorts.Clear();
                var expenseSorts = new List<ExpenseSortDto>();

                expenseSorts = await hbmApiService.GetExpenseSortsAsync();
               
                foreach (var expenseSort in expenseSorts) ExpenseSorts.Add(expenseSort);
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

        //[RelayCommand]
        //async Task GetExpenseSortDetails(Guid id)
        //{
        //    if (id.Equals(Guid.Empty)) return;

        //    await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);
        //}

        [RelayCommand]
        async Task SaveExpenseSort()
        {
            if (string.IsNullOrEmpty(Name))
            {
                await ShowAlert("Please insert valid data");
                return;
            }

            

            if (!(expenseSortId.Equals(Guid.Empty)))
            {
                var expenseSort = new UpdateExpenseSortDto
                {
                    Name = Name,
                    Description = Description,
                    IsActive = IsActive,
                };

                await hbmApiService.UpdateExpenseSort(ExpenseSortId, expenseSort);
                message = hbmApiService.StatusMessage;
            }
            else
            {
                var expenseSort = new CreateExpenseSortDto
                {
                    Name = Name,
                    Description = Description,
                    IsActive = IsActive,
                };

                await hbmApiService.AddExpenseSortAsync(expenseSort);
                message = hbmApiService.StatusMessage;
            }

            await ShowAlert(message);
            await GetExpenseSortsList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteExpenseSort(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                await ShowAlert("Please try again");
                return;
            }

            await hbmApiService.DeleteExpenseSortAsync(id);
            message = hbmApiService.StatusMessage;

            await ShowAlert(message);
            await GetExpenseSortsList();
        }

        [RelayCommand]
        async Task UpdateExpenseSort(Guid id)
        {
            addEditButtonText = editButtonText;
            return;
        }

        [RelayCommand]
        async Task SetEditMode(Guid id)
        {
            addEditButtonText = editButtonText;
            ExpenseSortId = id;
            ExpenseSortDto expenseSortDto;

            expenseSortDto = await hbmApiService.GetExpenseSortAsync(ExpenseSortId);


            Name = expenseSortDto.Name;
            Description = expenseSortDto.Description;
            IsActive = expenseSortDto.IsActive;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            addEditButtonText = createButtonText;
            ExpenseSortId = Guid.Empty;
            Name = string.Empty;
            Description = string.Empty;
            IsActive = default;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
