using AppMobileOrders.ServiceReference;
using AppMobileOrders.ViewModels.OrderVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileOrders.Views.OrderV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderPage : ContentPage
    {
        public OrderForView Item { get; set; }

        public NewOrderPage()
        {
            InitializeComponent();
            BindingContext = new NewOrderViewModel();
        }
    }
}