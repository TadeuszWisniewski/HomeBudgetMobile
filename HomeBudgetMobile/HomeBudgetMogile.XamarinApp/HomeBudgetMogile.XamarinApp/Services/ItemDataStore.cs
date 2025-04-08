using AppMobileOrders.Helpers;
using AppMobileOrders.ServiceReference;
using System.Linq;
using System.Threading.Tasks;

namespace AppMobileOrders.Services
{
    public class ItemDataStore : ListDataStore<ItemForView>
    {
        public ItemDataStore()
            : base()
            => items = orderService.ItemAllAsync().GetAwaiter().GetResult().ToList();
        public override async Task<bool> AddItemToService(ItemForView item)
            => await orderService.ItemPOSTAsync(item).HandleRequest();
        public override async Task<bool> DeleteItemFromService(ItemForView item)
            => await orderService.ItemDELETEAsync(item.IdItem).HandleRequest();
        public override ItemForView Find(ItemForView item)
            => items.Where((ItemForView arg) => arg.IdItem == item.IdItem).FirstOrDefault();
        public override ItemForView Find(int id)
            => items.FirstOrDefault(s => s.IdItem == id);
        public override async Task Refresh()
            => items = (await orderService.ItemAllAsync()).ToList();
        public override Task<bool> UpdateItemInService(ItemForView item)
            => orderService.ItemPUTAsync(item.IdItem, item).HandleRequest();
    }
}