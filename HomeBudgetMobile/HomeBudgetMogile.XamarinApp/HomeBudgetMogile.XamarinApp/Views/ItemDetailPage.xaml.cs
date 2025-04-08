using AppMobileOrders.ViewModels;
using Xamarin.Forms;

namespace AppMobileOrders.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}