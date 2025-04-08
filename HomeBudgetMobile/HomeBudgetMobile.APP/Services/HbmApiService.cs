using HomeBudgetMobile.APP.Model.DTO.Expense;
using HomeBudgetMobile.APP.Model.DTO.ExpenseSort;
using HomeBudgetMobile.APP.Model.DTO.Goal;
using HomeBudgetMobile.APP.Model.DTO.Income;
using HomeBudgetMobile.APP.Model.DTO.IncomeSource;
using HomeBudgetMobile.APP.Model.DTO.Saving;
using HomeBudgetMobile.APP.Model.DTO.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.APP.Services
{
    public class HbmApiService
    {
        HttpClient _httpClient;
        public static string baseAddress = "http://localhost:5063/api";
        public string StatusMessage;

        public HbmApiService()
        {
            _httpClient = new() {/* BaseAddress = new Uri(baseAddress) */};
        }

        #region Saving
        public async Task<List<SavingDto>> GetSavingsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Savings");
                return JsonConvert.DeserializeObject<List<SavingDto>>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<SavingDto> GetSavingAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Savings/" + id);
                return JsonConvert.DeserializeObject<SavingDto>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<SavingDto?> AddSavingAsync(CreateSavingDto createSavingDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5063/api/Savings/", createSavingDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";

                return JsonConvert.DeserializeObject<SavingDto>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to add data.";
                return null;
            }
        }

        public async Task DeleteSavingAsync(Guid id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync("http://localhost:5063/api/Savings/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
        }

        public async Task UpdateSaving(Guid id, UpdateSavingDto updateSavingDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("http://localhost:5063/api/Savings/" + id, updateSavingDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
        }
        #endregion

        #region IncomeSource
        public async Task<List<IncomeSourceDto>> GetIncomeSourcesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/IncomeSource");
                return JsonConvert.DeserializeObject<List<IncomeSourceDto>>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<IncomeSourceDto> GetIncomeSourceAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/IncomeSource/" + id);
                return JsonConvert.DeserializeObject<IncomeSourceDto>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task AddIncomeSourceAsync(CreateIncomeSourceDto createIncomeSourceDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5063/api/IncomeSource/", createIncomeSourceDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to add data.";
            }
        }

        public async Task DeleteIncomeSourceAsync(Guid id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync("http://localhost:5063/api/IncomeSource/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
        }

        public async Task UpdateIncomeSource(Guid id, UpdateIncomeSourceDto updateIncomeSourceDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("http://localhost:5063/api/IncomeSource/" + id, updateIncomeSourceDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
        }
        #endregion

        #region Income
        public async Task<List<IncomeDto>> GetIncomesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Income");
                return JsonConvert.DeserializeObject<List<IncomeDto>>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<IncomeDto> GetIncomeAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Income/" + id);
                return JsonConvert.DeserializeObject<IncomeDto>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<IncomeDto?> AddIncomeAsync(CreateIncomeDto createIncomeDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5063/api/Income/", createIncomeDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";

                //var addingToUserIncomesList = await.

                return JsonConvert.DeserializeObject<IncomeDto>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to add data.";
                return null;
            }
        }

        public async Task DeleteIncomeAsync(Guid id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync("http://localhost:5063/api/Income/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
        }

        public async Task UpdateIncome(Guid id, UpdateIncomeDto updateIncomeDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("http://localhost:5063/api/Income/" + id, updateIncomeDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
        }
        #endregion

        #region Goal
        public async Task<List<GoalDto>> GetGoalsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Goal");
                return JsonConvert.DeserializeObject<List<GoalDto>>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<GoalDto> GetGoalAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Goal/" + id);
                return JsonConvert.DeserializeObject<GoalDto>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task AddGoalAsync(CreateGoalDto createGoalDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5063/api/Goal/", createGoalDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to add data.";
            }
        }

        public async Task DeleteGoalAsync(Guid id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync("http://localhost:5063/api/Goal/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
        }

        public async Task UpdateGoal(Guid id, UpdateGoalDto updateGoalDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("http://localhost:5063/api/Goal/" + id, updateGoalDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
        }
        #endregion

        #region Expense
        public async Task<List<ExpenseDto>> GetExpensesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Expenses");
                return JsonConvert.DeserializeObject<List<ExpenseDto>>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<ExpenseDto> GetExpenseAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Expenses/" + id);
                return JsonConvert.DeserializeObject<ExpenseDto>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<ExpenseDto?> AddExpenseAsync(CreateExpenseDto createExpenseDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5063/api/Expenses/", createExpenseDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";

                return JsonConvert.DeserializeObject<ExpenseDto>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to add data.";
                return null;
            }
        }

        public async Task DeleteExpenseAsync(Guid id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync("http://localhost:5063/api/Expenses/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
        }

        public async Task UpdateExpense(Guid id, UpdateExpenseDto updateExpenseDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("http://localhost:5063/api/Expenses/" + id, updateExpenseDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
        }
        #endregion

        #region User
        public async Task<List<UserDto>> GetUsersAsync()
        {
            try
            {
                //await SetAuthToken();
                var response = await _httpClient.GetStringAsync("/Users");
                return JsonConvert.DeserializeObject<List<UserDto>>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Users/" + id);
                return JsonConvert.DeserializeObject<UserDto>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/Users/" + email);
                return JsonConvert.DeserializeObject<UserDto>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data." + ex;
                return null;
            }
        }

        public async Task AddUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5063/api/Users/", createUserDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to add data.";
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync("http://localhost:5063/api/Users/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
        }

        public async Task UpdateUser(Guid id, Guid[] guids)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("http://localhost:5063/api/Users/" + id, guids);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
        }
        #endregion

        #region ExpenseSort
        public async Task<List<ExpenseSortDto>> GetExpenseSortsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/ExpenseSort");
                return JsonConvert.DeserializeObject<List<ExpenseSortDto>>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }


        public async Task<ExpenseSortDto> GetExpenseSortAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5063/api/ExpenseSort/" + id);
                return JsonConvert.DeserializeObject<ExpenseSortDto>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task AddExpenseSortAsync(CreateExpenseSortDto createExpenseSortDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5063/api/ExpenseSort/", createExpenseSortDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to add data.";
            }
        }

        public async Task DeleteExpenseSortAsync(Guid id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync("http://localhost:5063/api/ExpenseSort/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
        }

        public async Task UpdateExpenseSort(Guid id, UpdateExpenseSortDto updateExpenseSortDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("http://localhost:5063/api/ExpenseSort/" + id, updateExpenseSortDto);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
        }
        #endregion
    }
}
