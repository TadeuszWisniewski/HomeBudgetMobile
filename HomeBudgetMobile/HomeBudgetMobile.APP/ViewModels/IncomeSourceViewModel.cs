using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Model.DTO.IncomeSource;
using HomeBudgetMobile.APP.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HomeBudgetMobile.APP.ViewModels
{
    public partial class IncomeSourceViewModel: BaseViewModel
    {
        const string editButtonText = "Update";
        const string createButtonText = "Add";
        private readonly HbmApiService hbmApiService;
        string message = string.Empty;

        public ObservableCollection<IncomeSourceDto> IncomeSources { get; private set; } = new();

        public IncomeSourceViewModel(HbmApiService hbmApiService)
        {
            Title = "Income sources";
            addEditButtonText = createButtonText;
            this.hbmApiService = hbmApiService;
        }

        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        Guid incomeSourceId;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string? description;
        [ObservableProperty]
        string addEditButtonText;


        [RelayCommand]
        public async Task GetIncomeSourceList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (IncomeSources.Any()) IncomeSources.Clear();
                var incomeSources = new List<IncomeSourceDto>();

                incomeSources = await hbmApiService.GetIncomeSourcesAsync();

                foreach (var incomeSource in incomeSources) IncomeSources.Add(incomeSource);
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
        async Task SaveIncomeSource()
        {
            if (string.IsNullOrEmpty(Name))
            {
                await ShowAlert("Please insert valid data");
                return;
            }



            if (!IncomeSourceId.Equals(Guid.Empty))
            {
                var incomeSource = new UpdateIncomeSourceDto
                {
                    Name = Name,
                    Description = Description,
                };

                await hbmApiService.UpdateIncomeSource(IncomeSourceId, incomeSource);
                message = hbmApiService.StatusMessage;
            }
            else
            {
                var incomeSource = new CreateIncomeSourceDto
                {
                    Name = Name,
                    Description = Description,
                };

                await hbmApiService.AddIncomeSourceAsync(incomeSource);
                message = hbmApiService.StatusMessage;
            }

            await ShowAlert(message);
            await GetIncomeSourceList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteIncomeSource(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                await ShowAlert("Please try again");
                return;
            }

            await hbmApiService.DeleteIncomeSourceAsync(id);
            message = hbmApiService.StatusMessage;

            await ShowAlert(message);
            await GetIncomeSourceList();
        }

        [RelayCommand]
        async Task UpdateIncomeSource(Guid id)
        {
            AddEditButtonText = editButtonText;
            return;
        }

        [RelayCommand]
        async Task SetEditMode(Guid id)
        {
            AddEditButtonText = editButtonText;
            IncomeSourceId = id;
            IncomeSourceDto incomeSourceDto;

            incomeSourceDto = await hbmApiService.GetIncomeSourceAsync(IncomeSourceId);


            Name = incomeSourceDto.Name;
            Description = incomeSourceDto.Description;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            IncomeSourceId = Guid.Empty;
            Name = string.Empty;
            Description = string.Empty;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
