using AppMobileOrders.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeBudgetMogile.XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ItemDataStore>();
            DependencyService.Register<ClientDataStore>();
            DependencyService.Register<WorkerDataStore>();
            DependencyService.Register<OrderDataStore>();
            DependencyService.Register<OrderValueDataStore>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
