using AutoMapper;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.Expense;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetMobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IExpenseRepository expenseRepository;

        public ExpensesController(IMapper mapper, IExpenseRepository expenseRepository)
        {
            this.mapper = mapper;
            this.expenseRepository = expenseRepository;
        }

        // GET Expenses
        // GET: /api/expenses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expeseDomainModels = await expenseRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<ExpenseDto>>(expeseDomainModels));
        }

        // GET Expense
        // GET: /api/expenses/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var existingExpense = await expenseRepository.GetByIdAsync(id);

            if (existingExpense == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ExpenseDto>(existingExpense));
        }

        // CREATE Expense
        // POST: /api/expenses
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseDto createExpenseDto)
        {
            // Map DTO to Domain Model
            var expenseDomainModel = mapper.Map<Expense>(createExpenseDto);

            expenseDomainModel = await expenseRepository.CreateAsync(expenseDomainModel);

            // Map Domain Model to DTO
            return Ok(mapper.Map<ExpenseDto>(expenseDomainModel));
        }

        // UPDATE Expense
        // PUT: /api/expenses/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]  UpdateExpenseDto updateExpenseDto)
        {
            // Map DTO to Domain Model
            var expenseDomainModel = mapper.Map<Expense>(updateExpenseDto);

            expenseDomainModel = await expenseRepository.UpdateAsync(id, expenseDomainModel);

            if (expenseDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<ExpenseDto>(expenseDomainModel));
        }

        // DELETE Expense
        // DELETE: /api/expenses/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var expenseDomainModel = await expenseRepository.DeleteAsync(id);

            if (expenseDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<ExpenseDto>(expenseDomainModel));
        }
    }
}
