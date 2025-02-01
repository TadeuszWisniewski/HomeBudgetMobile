using AutoMapper;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.ExpenseSort;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetMobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseSortController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IExpenseSortRepository expenseSortRepository;

        public ExpenseSortController(IMapper mapper, IExpenseSortRepository expenseSortRepository)
        {
            this.mapper = mapper;
            this.expenseSortRepository = expenseSortRepository;
        }

        // GET ExpenseSorts
        // GET: /api/ExpenseSorts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenseSortDomainModels = await expenseSortRepository.GetAllAsync();

            // Map Domain model to DTO
            return Ok(mapper.Map<List<ExpenseSortDto>>(expenseSortDomainModels));
        }

        // GET ExpenseSort
        // GET: /api/ExpenseSorts/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var expenseSortDomainModel = await expenseSortRepository.GetByIdAsync(id);

            if (expenseSortDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain model to DTO
            return Ok(mapper.Map<ExpenseSortDto>(expenseSortDomainModel));
        }

        // CREATE ExpenseSort
        // POST: /api/ExpenseSorts
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseSortDto createExpenseSortDto)
        {
            // Map DTO to Domain model 
            var expenseSortDomainModel = mapper.Map<ExpenseSort>(createExpenseSortDto);

            expenseSortDomainModel = await expenseSortRepository.CreateAsync(expenseSortDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<ExpenseSortDto>(expenseSortDomainModel));
        }

        // UPDATE ExpenseSort
        // PUT: /api/ExpenseSorts
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateExpenseSortDto updateExpenseSortDto)
        {
            // Map DTO to Domain model 
            var expenseSortDomainModel = mapper.Map<ExpenseSort>(updateExpenseSortDto);

            expenseSortDomainModel = await expenseSortRepository.UpdateAsync(id, expenseSortDomainModel);

            if(expenseSortDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain model to DTO
            return Ok(mapper.Map<ExpenseSortDto>(expenseSortDomainModel));
        }

        // DELETE ExpenseSort
        // DELETE: /api/ExpenseSorts
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var expenseSortDomainModel = await expenseSortRepository.DeleteAsync(id);

            if (expenseSortDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain model to DTO
            return Ok(mapper.Map<ExpenseSortDto>(expenseSortDomainModel));
        }
    }
}
