using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace AppMobileOrders.Helpers
{
    public static class RequestHelper
    {
        public async static Task<bool> HandleRequest(this Task serviceMethod)
        {
            try
            {
                await serviceMethod;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
