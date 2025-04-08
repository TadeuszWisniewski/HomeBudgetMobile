using AppMobileOrders.Helpers;
using AppMobileOrders.ServiceReference;
using AppMobileOrders.Services;
using AppMobileOrders.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppMobileOrders.ViewModels.OrderVM
{
    public class NewOrderViewModel : ANewItemViewModel<OrderForView>
    {
        public NewOrderViewModel()
            : base("New order")
        {
            selectedWorker = new WorkerForView();
            selectedClient = new ClientForView();
            clients = DependencyService.Get<ClientDataStore>().items;
            workers = DependencyService.Get<WorkerDataStore>().items;
            DataOrder = DateTime.Now.Date;
            DeliveryDate = DateTime.Now.Date;
        }
        #region Fields
        private DateTime? dataOrder;
        private string notes;
        private DateTime? deliveryDate;
        private ClientForView selectedClient;
        private WorkerForView selectedWorker;
        private List<ClientForView> clients;
        private List<WorkerForView> workers;
        #endregion
        #region Properties
        public DateTime? DataOrder
        {
            get => dataOrder;
            set => SetProperty(ref dataOrder, value);
        }
        public string Notes
        {
            get => notes;
            set => SetProperty(ref notes, value);
        }
        public List<ClientForView> Clients
        {
            get
            {
                return clients;
            }
        }
        public ClientForView SelectedClient
        {
            get => selectedClient;
            set => SetProperty(ref selectedClient, value);
        }
        public List<WorkerForView> Workers
        {
            get
            {
                return workers;
            }
        }
        public WorkerForView SelectedWorker
        {
            get => selectedWorker;
            set => SetProperty(ref selectedWorker, value);
        }
        public DateTime? DeliveryDate
        {
            get => deliveryDate;
            set => SetProperty(ref deliveryDate, value);
        }
        #endregion
        public override OrderForView SetItem()
            => new OrderForView
            {
                IdClient = selectedClient.IdClient,
                IdWorker = selectedWorker.IdWorker,
            }.CopyProperties(this);

        public override bool ValidateSave()
        {
            return selectedClient.IdClient != 0 && selectedWorker.IdWorker != 0;
        }
    }
}
