using AppMobileOrders.Helpers;
using AppMobileOrders.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileOrders.Services
{
    public class OrderDataStore : ListDataStore<OrderForView>
    {
        public OrderDataStore()
            : base()
            => items = orderService.OrderAllAsync().GetAwaiter().GetResult().ToList();
        public override OrderForView Find(OrderForView item)
            => items.Where((OrderForView arg) => arg.IdOrder == item.IdOrder).FirstOrDefault();
        public override OrderForView Find(int id)
            => items.FirstOrDefault(s => s.IdOrder == id);
        public override async Task Refresh()
            => items = (await orderService.OrderAllAsync()).ToList();
        public override async Task<bool> DeleteItemFromService(OrderForView item)
            => await orderService.OrderDELETEAsync(item.IdOrder).HandleRequest();
        public override async Task<bool> UpdateItemInService(OrderForView item)
            => await orderService.OrderPUTAsync(item.IdOrder, item).HandleRequest();
        public override async Task<bool> AddItemToService(OrderForView item)
            => await orderService.OrderPOSTAsync(item).HandleRequest();
    }
}