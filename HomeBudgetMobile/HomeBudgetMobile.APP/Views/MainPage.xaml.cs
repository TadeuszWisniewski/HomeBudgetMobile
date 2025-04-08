using HomeBudgetMobile.APP.Model;
using HomeBudgetMobile.APP.ViewModels;
using HomeBudgetMobile.APP.Views;

namespace HomeBudgetMobile.APP
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
            this.mainPageViewModel = mainPageViewModel;
        }

        ////Robie tutaj bo nie mam Nav w view modelu
        //private async void NavToLogIn(object sender, EventArgs e)
        //{
        //    ItemModel item = new ItemModel
        //    {
        //        ItemName = "fer",
        //        ItemDescription = "Description",
        //    };

        //    //await Navigation.PushAsync(new LogInPage());
        //    await Shell.Current.GoToAsync($"{nameof(LogInPage)}?count={count}", new Dictionary<string, object>
        //    {
        //        ["Car"] = item
        //    });
        //}
    }

}
