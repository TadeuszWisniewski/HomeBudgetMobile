using AppMobileOrders.ServiceReference;
using AppMobileOrders.ViewModels.Abstract;
using AppMobileOrders.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileOrders.ViewModels
{
    public class ItemsViewModel : AItemsViewModel<ItemForView>
    {
        public ItemsViewModel()
            : base("Browse items")
        {
        }
        public override async Task GoToAddPage()
            => await Shell.Current.GoToAsync(nameof(NewItemPage));
        public override async Task GoToDetailsPage(ItemForView item)
            => await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.IdItem}");
    }
}