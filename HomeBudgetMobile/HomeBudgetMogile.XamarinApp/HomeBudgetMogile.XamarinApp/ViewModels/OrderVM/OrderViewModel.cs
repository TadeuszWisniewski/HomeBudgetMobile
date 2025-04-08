using AppMobileOrders.ServiceReference;
using AppMobileOrders.ViewModels.Abstract;
using AppMobileOrders.Views.OrderV;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileOrders.ViewModels.OrderVM
{
    internal class OrderViewModel : AItemsViewModel<OrderForView>
    {
        public OrderViewModel()
            : base("Orders")
        {
        }
        public override async Task GoToAddPage()
            => await Shell.Current.GoToAsync(nameof(NewOrderPage));

        public override Task GoToDetailsPage(OrderForView item) 
            => throw new NotImplementedException();

        // public override async Task GoToDetailsPage(order client)
        //    =>  await Shell.Current.GoToAsync($"{nameof(ClientDetailPage)}?{nameof(ClientDetailsViewModel.ItemId)}={client.IdClient}");
    }
}
