using AppMobileOrders.ServiceReference;
using AppMobileOrders.Services;
using AppMobileOrders.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileOrders.ViewModels.OrderVM
{
    public class OrderValueViewModel : BaseViewModel
    {
        #region Fields
        public WorkerForView selectedWorker;
        private List<WorkerForView> workers; 
        public DateTime? date;
        private OrderValueDataStore orderValueDataStore; 
        private double orderValueOfWorkerOfDay;
        private double orderValueOfDay;
        private double orderValueOfWorker;
        #endregion
        public OrderValueViewModel()
            : base()
        {
            date = DateTime.Now.Date;
            selectedWorker = new WorkerForView();
            orderValueDataStore = DependencyService.Get<OrderValueDataStore>();
            workers = DependencyService.Get<WorkerDataStore>().items;
            OrderValueOfWorkerOfDayCommand = new Command(async () => await OnOrderValueOfWorkerOfDayAsync());
            OrderValueOfWorkerCommand = new Command(async () => await OnOrderValueOfWorkerAsync());
            OrderValueOfDayCommand = new Command(async () => await OnOrderValueOfDayAsync());
        }
        #region Properties
        public WorkerForView SelectedWorker
        {
            get => selectedWorker;
            set => SetProperty(ref selectedWorker, value);
        }
        public List<WorkerForView> Workers
        {
            get
            {
                return workers;
            }
        }
        public DateTime? Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public double OrderValueOfWorkerOfDay
        {
            get => orderValueOfWorkerOfDay;
            set => SetProperty(ref orderValueOfWorkerOfDay, value);
        }

        public double OrderValueOfDay
        {
            get => orderValueOfDay;
            set => SetProperty(ref orderValueOfDay, value);
        }

        public double OrderValueOfWorker
        {
            get => orderValueOfWorker;
            set => SetProperty(ref orderValueOfWorker, value);
        }
        #endregion
        #region Commands
        public Command OrderValueOfWorkerOfDayCommand { get; }
        public Command OrderValueOfDayCommand { get; }
        public Command OrderValueOfWorkerCommand { get; }
        public async Task OnOrderValueOfWorkerOfDayAsync()
        {
            OrderValueOfWorkerOfDay =  await orderValueDataStore.OrderValueOfWorkerOfDay(selectedWorker.IdWorker, (DateTime)date);
        }
        public async Task OnOrderValueOfDayAsync()
        {
            OrderValueOfDay = await orderValueDataStore.OrderValueOfDay((DateTime)date);
        }
        public async Task OnOrderValueOfWorkerAsync()
        {
            OrderValueOfWorker = await orderValueDataStore.OrderValueOfWorker(selectedWorker.IdWorker);
        }
        #endregion
    }
}
