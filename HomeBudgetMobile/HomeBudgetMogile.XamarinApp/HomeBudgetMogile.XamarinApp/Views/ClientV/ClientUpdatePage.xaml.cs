using AppMobileOrders.ViewModels.ClientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileOrders.Views.ClientV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientUpdatePage : ContentPage
    {
        public ClientUpdatePage()
        {
            InitializeComponent();
            BindingContext = new ClientUpdateViewModel();
        }
    }
}