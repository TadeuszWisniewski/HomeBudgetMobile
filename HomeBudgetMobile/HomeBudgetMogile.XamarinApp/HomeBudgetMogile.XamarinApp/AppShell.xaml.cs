using AppMobileOrders.Views;
using AppMobileOrders.Views.ClientV;
using AppMobileOrders.Views.OrderV;
using System;
using Xamarin.Forms;

namespace AppMobileOrders
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ClientDetailPage), typeof(ClientDetailPage));
            Routing.RegisterRoute(nameof(NewClientPage), typeof(NewClientPage));
            Routing.RegisterRoute(nameof(NewOrderPage), typeof(NewOrderPage));
            Routing.RegisterRoute(nameof(OrderValuePage), typeof(OrderValuePage ));
            Routing.RegisterRoute(nameof(ClientUpdatePage), typeof(ClientUpdatePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e) 
            => await Current.GoToAsync("//LoginPage");
    }
}
