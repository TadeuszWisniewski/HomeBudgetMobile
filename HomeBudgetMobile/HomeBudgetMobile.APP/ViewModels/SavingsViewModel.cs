using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Model.DTO.Expense;
using HomeBudgetMobile.APP.Model.DTO.Goal;
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
    public partial class SavingsViewModel: BaseViewModel
    {
        const string editButtonText = "Update Expense";
        const string createButtonText = "Add Expense";
        private readonly HbmApiService hbmApiService;
        string message = string.Empty;

        public ObservableCollection<SavingDto>? Savings { get; private set; } = new();

        public ObservableCollection<GoalDto>? Goals { get; private set; } = new();

        public SavingsViewModel(HbmApiService hbmApiService)
        {
            Title = "Savings";
            addEditButtonText = createButtonText;
            this.hbmApiService = hbmApiService;
        }

        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        decimal amount;
        [ObservableProperty]
        char currency = 'w';
        [ObservableProperty]
        string? description;
        [ObservableProperty]
        Guid goalId;
        [ObservableProperty]
        string addEditButtonText;
        [ObservableProperty]
        Guid savingId;
        [ObservableProperty]
        bool isActive = true;
        [ObservableProperty]
        GoalDto selectedGoal;

        public async Task GetPickerDataAsync()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Goals.Any()) Goals.Clear();
                var goals = new List<GoalDto>();
                goals = await hbmApiService.GetGoalsAsync();

                foreach (var goal in goals) Goals.Add(goal);
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
        public async Task GetSavingsList()
        {
            if (IsLoading) return;
            await GetPickerDataAsync();
            try
            {
                IsLoading = true;
                if (Savings.Any()) Savings.Clear();
                var savings = new List<SavingDto>();

                var user = await hbmApiService.GetUserByEmailAsync(Email);

                savings = user.Savings;

                foreach (var saving in savings) Savings.Add(saving);
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
        async Task SaveSaving()
        {
            if (Amount.Equals(null) || Currency.Equals('w') || SelectedGoal == null || Amount == decimal.Zero)
            {
                await ShowAlert("Please insert valid data");
                return;
            }

            if (!SavingId.Equals(Guid.Empty))
            {

                var saving = new UpdateSavingDto
                {
                    Amount = Amount,
                    Currency = Currency,
                    Description = Description,
                    IsActive = IsActive,
                    GoalId = SelectedGoal.Id,
                };

                await hbmApiService.UpdateSaving(SavingId, saving);
                message = hbmApiService.StatusMessage;
            }
            else
            {
                var saving = new CreateSavingDto
                {
                    Amount = Amount,
                    Currency = Currency,
                    Description = Description,
                    IsActive = IsActive,
                    GoalId = SelectedGoal.Id,
                };
                var addedSaving = await hbmApiService.AddSavingAsync(saving);
                message = hbmApiService.StatusMessage;

                Guid[] guids = new Guid[3];

                guids[0] = Guid.Empty;
                guids[1] = Guid.Empty;
                guids[2] = addedSaving.Id;

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
            await GetSavingsList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteSaving(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                await ShowAlert("Please try again");
                return;
            }

            await hbmApiService.DeleteSavingAsync(id);
            message = hbmApiService.StatusMessage;

            await ShowAlert(message);
            await GetSavingsList();
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
            SavingId = id;
            SavingDto savingDto;

            savingDto = await hbmApiService.GetSavingAsync(SavingId);


            Amount = savingDto.Amount;
            Currency = savingDto.Currency;
            Description = savingDto.Description;
            IsActive = savingDto.IsActive;
            SelectedGoal = await hbmApiService.GetGoalAsync(savingDto.GoalId);
            GoalId = savingDto.GoalId;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            SavingId = Guid.Empty;
            Amount = default;
            Currency = default;
            Description = String.Empty;
            IsActive = default;
            GoalId = Guid.Empty;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
