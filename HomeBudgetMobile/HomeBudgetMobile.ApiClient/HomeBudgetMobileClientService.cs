using HomeBudgetMobile.ApiClient.Models;
using HomeBudgetMobile.APP.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.ApiClient
{
    public class HomeBudgetMobileClientService
    {
        private readonly HttpClient _httpClient;
        public HomeBudgetMobileClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }

        public async Task<List<ExpenseSort>?> GetExpenseSorts()
        {
            return await _httpClient.GetFromJsonAsync<List<ExpenseSort>?>("/api/ExpenseSort");
        }

        public async Task<ExpenseSort?> GetExpenseSortById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ExpenseSort?>($"/api/ExpenseSort/{id}");
        }

        public async Task CreateExpenseSort(ExpenseSort expenseSort)
        {
            await _httpClient.PostAsJsonAsync("/api/ExpenseSort", expenseSort);
        }
        //tutaj!!!!!!!!!
        public async Task CreateUser(User user)
        {
            await _httpClient.PostAsJsonAsync("/api/Users", user);
        }

        public async Task UpdateExpenseSort(ExpenseSort expenseSort)
        {
            await _httpClient.PutAsJsonAsync("/api/ExpenseSort", expenseSort);
        }

        public async Task DeleteExpenseSort(Guid id)
        {
            await _httpClient.DeleteAsync($"/api/ExpenseSort/{id}");
        }
    }
}
