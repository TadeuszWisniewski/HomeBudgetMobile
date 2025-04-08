using AppMobileOrders.ViewModels.OrderVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileOrders.Views.OrderV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderValuePage : ContentPage
    {
        public OrderValuePage()
        {
            InitializeComponent();
            BindingContext = new OrderValueViewModel();
        }
    }
}