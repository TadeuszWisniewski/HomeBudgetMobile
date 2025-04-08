using AppMobileOrders.Helpers;
using AppMobileOrders.ServiceReference;
using AppMobileOrders.ViewModels.Abstract;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AppMobileOrders.ViewModels.ClientVM
{
    public class ClientUpdateViewModel : AItemUpdateViewModel<ClientForView>
    {
        public ClientUpdateViewModel()
            :base("Update client")
        {
        }
        #region Fields
        private int id;
        private string name;
        private string address;
        private string phoneNumber;
        #endregion
        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
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
        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                if (item == null)
                    return;
                Id = id;
                this.CopyProperties(item);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public override ClientForView SetItem()
            => new ClientForView()
            {
                IdClient = ItemId
            }.CopyProperties(this);

        public override bool ValidateSave()
            => ItemId > 0 && !string.IsNullOrWhiteSpace(Name);
    }
}
