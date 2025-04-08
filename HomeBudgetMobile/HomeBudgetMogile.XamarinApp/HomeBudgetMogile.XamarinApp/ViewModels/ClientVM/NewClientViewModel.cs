using AppMobileOrders.ServiceReference;
using AppMobileOrders.ViewModels.Abstract;

namespace AppMobileOrders.ViewModels.ClientVM
{
    public class NewClientViewModel : ANewItemViewModel<ClientForView>
    {
        #region Fields
        private int idClient;
        private string name;
        private string address;
        private string phoneNumber;
        #endregion
        #region Properties
        public int IdClient
        {
            get => idClient;
            set => SetProperty(ref idClient, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }
        #endregion
        public NewClientViewModel()
            :base("Add new Client")
        {
        }
        public override bool ValidateSave() 
            => IdClient > 0 && !string.IsNullOrWhiteSpace(Name); 
        public override ClientForView SetItem()
            => new ClientForView()
            {
                IdClient = IdClient,
                Name = Name,
                Address = address,
                PhoneNumber = PhoneNumber
            };
    }
}
