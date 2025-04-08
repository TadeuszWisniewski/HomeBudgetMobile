using AppMobileOrders.ServiceReference;

namespace AppMobileOrders.Services
{
    public abstract class ADataStore
    { 
        protected OrderService orderService;
        public ADataStore()
        {
            /*  //In case of using HTTPS on local - that's only for testing 
             *  //- you can use preprocessor method for checking if we are running in development.
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback = 
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

                var client = new HttpClient(handler);
             */
            orderService = new OrderService("http://localhost:5209", new System.Net.Http.HttpClient());
        }
    }
}
