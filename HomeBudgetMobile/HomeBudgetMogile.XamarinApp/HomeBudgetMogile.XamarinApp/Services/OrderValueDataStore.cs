using System;
using System.Threading.Tasks;

namespace AppMobileOrders.Services
{
    public class OrderValueDataStore :  ADataStore
    {
        public OrderValueDataStore()
        : base()
        {
        }
        public async Task<double> OrderValueOfWorkerOfDay(int idWorker, DateTime data) 
            => await orderService.OrderValueOfWorkerOfDayAsync(idWorker, data);
        public async Task<double> OrderValueOfDay(DateTime data) 
            => await orderService.OrderValueOfDayAsync(data);
        public async Task<double> OrderValueOfWorker(int idWorker) 
            => await orderService.OrderValueOfWorkerAsync(idWorker);
    }
}