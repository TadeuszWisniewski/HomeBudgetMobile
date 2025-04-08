using AppMobileOrders.ServiceReference;
using AppMobileOrders.ViewModels;
using Xamarin.Forms;

namespace AppMobileOrders.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ItemForView Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}