using AppMobileOrders.ServiceReference;
using AppMobileOrders.ViewModels.ClientVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileOrders.Views.ClientV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewClientPage : ContentPage
    {
        public ClientForView Item { get; set; }
        public NewClientPage()
        {
            InitializeComponent();
            BindingContext = new NewClientViewModel();
        }
    }
}