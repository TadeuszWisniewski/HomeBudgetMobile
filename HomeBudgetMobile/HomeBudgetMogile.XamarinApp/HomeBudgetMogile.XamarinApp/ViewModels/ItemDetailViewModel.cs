using System;
using System.Diagnostics;
using AppMobileOrders.ViewModels.Abstract;
using System.Threading.Tasks;
using AppMobileOrders.ServiceReference;

namespace AppMobileOrders.ViewModels
{
    public class ItemDetailViewModel : AItemDetailsViewModel<ItemForView>
    {
        private string name;
        private string description;

        public ItemDetailViewModel() 
            : base("Item details")
        {
        }

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public override async Task LoadItem(int id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(id);
                Id = item.IdItem;
                Name = item.Name;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        protected override Task GoToUpdatePage()
        {
            throw new NotImplementedException();
        }
    }
}
