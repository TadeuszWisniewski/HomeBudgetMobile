using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeBudgetMobile.APP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.APP.ViewModels
{
    [QueryProperty(nameof(Email), "email")]
    public partial class BaseViewModel: ObservableObject
    {
        public BaseViewModel() { }

        //[ObservableProperty]
        ////[NotifyCanExecuteChangedFor(nameof(IsNotBusy))]
        //private bool isBusy;

        ////public bool IsNotBusy => !IsBusy;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        protected string email;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        bool isLoading;

        public bool IsNotLoading => !isLoading;

        [RelayCommand]
        async Task GoToHome()
        {
            await Shell.Current.GoToAsync($"{nameof(SummaryPage)}?email={Email}");
        }

        [RelayCommand]
        async Task LogOut()
        {
            await Shell.Current.GoToAsync($"{nameof(LogInPage)}?email=''");
        }

    }
}
