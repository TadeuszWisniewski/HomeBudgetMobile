using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Services;
using HomeBudgetMobile.APP.Views;
using System.Diagnostics;

namespace HomeBudgetMobile.APP.ViewModels
{
    public partial class LogInPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        Guid idUser;
        [ObservableProperty]
        string? emailValue;
        [ObservableProperty]
        string? passwordValue;
        private readonly HbmApiService hbmApiService;

        public LogInPageViewModel(HbmApiService hbmApiService)
        {
            this.hbmApiService = hbmApiService;
        }

        [RelayCommand]
        async Task LogIn()
        {
            if (IsLoading) return;

            if (string.IsNullOrEmpty(EmailValue) || string.IsNullOrEmpty(PasswordValue))
            {
                await ShowAlert("Please try again");
                await ClearForm();
                IsLoading = false;
                isRefreshing = false;
                return;
            }

            var existingUser = await hbmApiService.GetUserByEmailAsync(EmailValue);

            if (existingUser == null)
            {
                await ShowAlert("Given email addres does not exist");
                await ClearForm();
                IsLoading = false;
                isRefreshing = false;
                return;
            }

            if(existingUser.Password != PasswordValue)
            {
                await ShowAlert("Password incorrect");
                await ClearForm();
                IsLoading = false;
                isRefreshing = false;
                return;
            }

            await ShowAlert("Logged in succesfully");

            //IsLoading = false;
            //isRefreshing = false;
            Email = existingUser.Email;
            try
            {
                await Shell.Current.GoToAsync($"{nameof(SummaryPage)}?email={Email}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to LogIn: {ex.Message}");
                await ShowAlert("Failed to Log in");
            }
            finally
            {
                await ClearForm();
                IsLoading = false;
                IsRefreshing = false;
            }


            //await Shell.Current.GoToAsync($"{nameof(SummaryPage)}?email={EmailValue}");
        }

        [RelayCommand]
        async Task GoToSignUp()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            catch (Exception ex) 
            {
                Debug.WriteLine($"Unable to execute command: {ex.Message}");
                await ShowAlert("Failed to navigate to SignUp");
            }
        }

        [RelayCommand]
        async Task ClearForm()
        {
            EmailValue = string.Empty;
            PasswordValue = string.Empty;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
