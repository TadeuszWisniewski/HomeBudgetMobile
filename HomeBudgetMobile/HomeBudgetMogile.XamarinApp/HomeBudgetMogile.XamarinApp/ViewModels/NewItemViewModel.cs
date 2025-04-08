using AppMobileOrders.ViewModels.Abstract;
using AppMobileOrders.ServiceReference;

namespace AppMobileOrders.ViewModels
{
    public class NewItemViewModel : ANewItemViewModel<ItemForView>
    {
        private string name;
        private string description;

        public NewItemViewModel()
            :base("Add new item")
        {
        }

        public override bool ValidateSave() 
            => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(description);
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
        public override ItemForView SetItem()
            => new ItemForView()
            {
                IdItem = 0,
                Name = Name,
                Description = Description
            };
    }
}
