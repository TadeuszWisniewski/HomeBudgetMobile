using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Model.DTO.Goal;
using HomeBudgetMobile.APP.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
//using static Android.Util.EventLogTags;
//using static Java.Util.Jar.Attributes;

namespace HomeBudgetMobile.APP.ViewModels
{
    public partial class GoalsViewModel: BaseViewModel
    {
        const string editButtonText = "Update";
        const string createButtonText = "Add";
        private readonly HbmApiService hbmApiService;
        string message = string.Empty;

        public ObservableCollection<GoalDto> Goals { get; private set; } = new();

        public GoalsViewModel(HbmApiService hbmApiService)
        {
            Title = "Goals";
            addEditButtonText = createButtonText;
            this.hbmApiService = hbmApiService;
        }

        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        Guid id;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        decimal neededAmount;
        [ObservableProperty]
        char currency = 'w';
        [ObservableProperty]
        DateOnly startDate = default;
        [ObservableProperty]
        DateOnly endDate = default;
        [ObservableProperty]
        string? description;
        [ObservableProperty]
        bool isActive = true;
        [ObservableProperty]
        string addEditButtonText;

        [RelayCommand]
        public async Task GetGoalsList()
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
                Debug.WriteLine($"Unable to get goals: {ex.Message}");
                await ShowAlert("Failed to retrive list of goals.");
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
        async Task SaveGoal()
        {
            if (string.IsNullOrEmpty(Name) || Currency.Equals('w') || NeededAmount == null || NeededAmount == decimal.Zero)
            {
                await ShowAlert("Please insert valid data");
                return;
            }



            if (!Id.Equals(Guid.Empty))
            {
                var goal = new UpdateGoalDto
                {
                    Name = Name,
                    NeededAmount = NeededAmount,
                    Currency = Currency,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Description = Description,
                    IsAcive = IsActive,
                };

                await hbmApiService.UpdateGoal(Id, goal);
                message = hbmApiService.StatusMessage;
            }
            else
            {
                var goal = new CreateGoalDto
                {
                    Name = Name,
                    NeededAmount = NeededAmount,
                    Currency = Currency,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Description = Description,
                    IsAcive = IsActive,
                };

                await hbmApiService.AddGoalAsync(goal);
                message = hbmApiService.StatusMessage;
            }

            await ShowAlert(message);
            await GetGoalsList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteGoal(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                await ShowAlert("Please try again");
                return;
            }

            await hbmApiService.DeleteGoalAsync(id);
            message = hbmApiService.StatusMessage;

            await ShowAlert(message);
            await GetGoalsList();
        }

        [RelayCommand]
        async Task UpdateGoal(Guid id)
        {
            AddEditButtonText = editButtonText;
            return;
        }

        [RelayCommand]
        async Task SetEditMode(Guid id)
        {
            AddEditButtonText = editButtonText;
            Id = id;
            GoalDto goalDto;

            goalDto = await hbmApiService.GetGoalAsync(Id);


            Name = goalDto.Name;
            NeededAmount = goalDto.NeededAmount;
            Currency = goalDto.Currency;
            StartDate = goalDto.StartDate;
            EndDate = goalDto.EndDate;
            Description = goalDto.Description;
            IsActive = goalDto.IsAcive;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            Name = string.Empty;
            NeededAmount = default;
            Currency = 'w';
            StartDate = default;
            EndDate = default;
            Description = default;
            IsActive = default;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
