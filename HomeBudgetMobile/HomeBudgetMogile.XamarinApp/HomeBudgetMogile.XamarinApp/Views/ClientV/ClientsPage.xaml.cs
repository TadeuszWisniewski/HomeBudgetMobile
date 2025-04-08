using AppMobileOrders.ViewModels.ClientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileOrders.Views.ClientV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsPage : ContentPage
    {
        private ClientViewModel _viewModel;
        public ClientsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ClientViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}