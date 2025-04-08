using AppMobileOrders.ViewModels.ClientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileOrders.Views.ClientV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDetailPage : ContentPage
    {
        public ClientDetailPage()
        {
            InitializeComponent();
            BindingContext = new ClientDetailsViewModel();
        }
    }
}