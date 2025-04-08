using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Model.DTO.Income;
using HomeBudgetMobile.APP.Model.DTO.IncomeSource;
using HomeBudgetMobile.APP.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HomeBudgetMobile.APP.ViewModels
{
    public partial class IncomesViewModel: BaseViewModel
    {
        const string editButtonText = "Update";
        const string createButtonText = "Add";
        private readonly HbmApiService hbmApiService;
        string message = string.Empty;

        public ObservableCollection<IncomeDto> Incomes { get; private set; } = new();

        public ObservableCollection<IncomeSourceDto>? IncomeSource { get; private set; } = new();

        public IncomesViewModel(HbmApiService hbmApiService)
        {
            Title = "Incomes";
            addEditButtonText = createButtonText;
            this.hbmApiService = hbmApiService;
        }

        //[ObservableProperty]
        //Guid userId;
        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        string addEditButtonText;
        [ObservableProperty]
        Guid incomeId;
        [ObservableProperty]
        decimal amount;
        [ObservableProperty]
        char currency = 'w';
        [ObservableProperty]
        string? description;
        [ObservableProperty]
        bool isActive = true;
        [ObservableProperty]
        IncomeSourceDto selectedIncomeSource;
        [ObservableProperty]
        Guid incomeSourceId;

        public async Task GetPickerDataAsync()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (IncomeSource.Any()) IncomeSource.Clear();
                var incomeSources = new List<IncomeSourceDto>();
                incomeSources = await hbmApiService.GetIncomeSourcesAsync();

                foreach (var income in incomeSources) IncomeSource.Add(income);
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
        public async Task GetIncomesList()
        {
            if (IsLoading) return;
            try
            {
                //IsLoading = true;
                //if (Incomes.Any()) Incomes.Clear();
                //var incomes = new List<IncomeDto>();

                //incomes = await hbmApiService.GetIncomesAsync();

                IsLoading = true;
                if (Incomes.Any()) Incomes.Clear();
                var incomes = new List<IncomeDto>();

                var user = await hbmApiService.GetUserByEmailAsync(Email);

                incomes = user.Incomes;

                //var user = await hbmApiService.GetUserByEmailAsync(Email);

                //var incomesFromUser = user.Incomes;

                foreach (var income in incomes) Incomes.Add(income);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get incomes: {ex.Message}");
                await ShowAlert("Failed to retrive list of incomes.");
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
        async Task SaveIncomes()
        {
            if (Amount.Equals(string.Empty) || Currency.Equals('w') || SelectedIncomeSource == null || Amount == Decimal.Zero)
            {
                await ShowAlert("Please insert valid data");
                return;
            }

            if (!IncomeId.Equals(Guid.Empty))
            {
                var income = new UpdateIncomeDto
                {
                    Amount=Amount,
                    Currency=Currency,
                    Description=description,
                    IsActive=IsActive,
                    IncomeSourceId=SelectedIncomeSource.Id,
                };

                await hbmApiService.UpdateIncome(IncomeId, income);
                message = hbmApiService.StatusMessage;
            }
            else
            {
                var income = new CreateIncomeDto
                {
                    Amount = Amount,
                    Currency = Currency,
                    Description = description,
                    IsActive = IsActive,
                    IncomeSourceId = SelectedIncomeSource.Id,
                };

                var addedIncome = await hbmApiService.AddIncomeAsync(income);
                message = hbmApiService.StatusMessage;

                Guid[] guids = new Guid[3];

                guids[0] = addedIncome.Id;
                guids[1] = Guid.Empty;
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
            await GetIncomesList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteIncome(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                await ShowAlert("Please try again");
                return;
            }

            await hbmApiService.DeleteIncomeAsync(id);
            message = hbmApiService.StatusMessage;

            await ShowAlert(message);
            await GetIncomesList();
        }

        [RelayCommand]
        async Task UpdateIncome(Guid id)
        {
            AddEditButtonText = editButtonText;
            return;
        }

        [RelayCommand]
        async Task SetEditMode(Guid id)
        {
            AddEditButtonText = editButtonText;
            IncomeId = id;
            IncomeDto incomeDto;

            incomeDto = await hbmApiService.GetIncomeAsync(IncomeId);


            Amount = incomeDto.Amount;
            Currency = incomeDto.Currency;
            Description = incomeDto.Description;
            IsActive = incomeDto.IsActive;
            IncomeSourceId = incomeDto.IncomeSourceId;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            Amount = default;
            Currency = 'w';
            Description = default;
            IsActive =default;
            IncomeSourceId=Guid.Empty;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
