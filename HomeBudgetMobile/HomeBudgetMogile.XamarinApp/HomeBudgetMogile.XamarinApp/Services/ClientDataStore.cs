using AppMobileOrders.Helpers;
using AppMobileOrders.ServiceReference;
using System.Linq;
using System.Threading.Tasks;

namespace AppMobileOrders.Services
{
    public class ClientDataStore : ListDataStore<ClientForView>
    {
        public ClientDataStore()
            : base()
            => items = orderService.ClientAllAsync().GetAwaiter().GetResult().ToList();
        public override ClientForView Find(ClientForView item)
            => items.Where((ClientForView arg) => arg.IdClient == item.IdClient).FirstOrDefault();
        public override ClientForView Find(int id)
            => items.FirstOrDefault(s => s.IdClient == id);
        public override async Task Refresh()
            => items = (await orderService.ClientAllAsync()).ToList();
        public override async Task<bool> DeleteItemFromService(ClientForView item)
            => await orderService.ClientDELETEAsync(item.IdClient).HandleRequest();
        public override async Task<bool> UpdateItemInService(ClientForView item)
            => await orderService.ClientPUTAsync(item.IdClient, item).HandleRequest();
        public override async Task<bool> AddItemToService(ClientForView item)
            => await orderService.ClientPOSTAsync(item).HandleRequest();
    }
}