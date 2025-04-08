using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Model.DTO.User;
using HomeBudgetMobile.APP.Model;
using HomeBudgetMobile.APP.Services;
using HomeBudgetMobile.APP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.APP.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {

        private readonly HbmApiService hbmApiService;
        string message = string.Empty;

        public ObservableCollection<UserDto> Users { get; private set; } = new();

        public MainPageViewModel(HbmApiService hbmApiService)
        {
            Title = "Sign Up";
            this.hbmApiService = hbmApiService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string? nameValue;

        [ObservableProperty]
        string? emailValue;

        [ObservableProperty]
        string? passwordValue;

        [ObservableProperty]
        string? repeatedPasswordValue;

        [ObservableProperty]
        bool termsCheckboxValue;
        

        [RelayCommand]
        async Task GoToLogIn()
        {
            await Shell.Current.GoToAsync(nameof(LogInPage));
        }

        //[RelayCommand]
        //async Task GetUsersList()
        //{
        //    if (IsLoading) return;
        //    try
        //    {
        //        IsLoading = true;
        //        if (Users.Any()) Users.Clear();
        //        var users = new List<UserDto>();

        //        users = await hbmApiService.GetUsersAsync();

        //        foreach (var user in users) Users.Add(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Unable to get expense sorts: {ex.Message}");
        //        await ShowAlert("Failed to retrive list of expense sorts.");
        //    }
        //    finally
        //    {
        //        IsLoading = false;
        //        IsRefreshing = false;
        //    }
        //}

        [RelayCommand]
         async Task Submit()
         {
            if (IsLoading) return;


            if (string.IsNullOrEmpty(NameValue) || string.IsNullOrEmpty(PasswordValue) || string.IsNullOrEmpty(EmailValue) || !PasswordValue.Equals(RepeatedPasswordValue) || !TermsCheckboxValue)
            {
                await ShowAlert("Please insert valid data");
                return;
            }

            var existingUser = await hbmApiService.GetUserByEmailAsync(EmailValue);

            if (existingUser != null)
            {
                await ShowAlert("This Email is used by another user");
                await ClearForm();
                IsLoading = false;
                isRefreshing = false;
                return;
            }

            var user = new CreateUserDto
            {
                Name = NameValue,
                Email = EmailValue,
                Password = PasswordValue,
                Description = "",
                IsActive = true,
            };

            await hbmApiService.AddUserAsync(user);
            message = hbmApiService.StatusMessage;

            await ShowAlert(message);
            await ClearForm();

            IsLoading = false;
            isRefreshing = false;



            GoToLogIn();
         }

        [RelayCommand]
        async Task ClearForm()
        {
            NameValue = string.Empty;
            EmailValue = string.Empty;
            PasswordValue = string.Empty;
            RepeatedPasswordValue = string.Empty;
            TermsCheckboxValue = false;
        }

        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("Info", message, "Ok");
        }
    }
}
