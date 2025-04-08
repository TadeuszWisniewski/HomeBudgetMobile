using AppMobileOrders.Views.ClientV;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppMobileOrders.ViewModels.Abstract;
using AppMobileOrders.ServiceReference;

namespace AppMobileOrders.ViewModels.ClientVM
{
    public class ClientViewModel : AItemsViewModel<ClientForView>
    {
        public ClientViewModel()
            :base("Clients")
        {
        }
        public override async Task GoToAddPage()
            => await Shell.Current.GoToAsync(nameof(NewClientPage));

        public override async Task GoToDetailsPage(ClientForView client)
            => await Shell.Current.GoToAsync($"{nameof(ClientDetailPage)}?{nameof(ClientDetailsViewModel.ItemId)}={client.IdClient}");
    }
}