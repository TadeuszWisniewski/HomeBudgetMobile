using AppMobileOrders.Helpers;
using AppMobileOrders.ServiceReference;
using System.Linq;
using System.Threading.Tasks;

namespace AppMobileOrders.Services
{
    public class WorkerDataStore : ListDataStore<WorkerForView>
    {
        public WorkerDataStore()
            : base()
            => items = orderService.WorkerAllAsync().GetAwaiter().GetResult().ToList();
        public override WorkerForView Find(WorkerForView item)
            => items.Where((WorkerForView arg) => arg.IdWorker == item.IdWorker).FirstOrDefault();
        public override WorkerForView Find(int id)
            => items.FirstOrDefault(s => s.IdWorker == id);
        public override async Task Refresh()
            => items = (await orderService.WorkerAllAsync()).ToList();
        public override async Task<bool> DeleteItemFromService(WorkerForView item)
            => await orderService.WorkerDELETEAsync(item.IdWorker).HandleRequest();
        public override async Task<bool> UpdateItemInService(WorkerForView item)
            => await orderService.WorkerPUTAsync(item.IdWorker, item).HandleRequest();
        public override async Task<bool> AddItemToService(WorkerForView item)
            => await orderService.WorkerPOSTAsync(item).HandleRequest();
    }
}