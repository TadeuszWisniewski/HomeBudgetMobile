using AutoMapper;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.Income;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetMobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IIncomeRepository incomeRepository;

        public IncomeController(IMapper mapper, IIncomeRepository incomeRepository)
        {
            this.mapper = mapper;
            this.incomeRepository = incomeRepository;
        }

        // GET Incomes
        // GET: /api/incomes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incomeDomainModels = await incomeRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<IncomeDto>>(incomeDomainModels));
        }

        // GET Income
        // GET: /api/incomes
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var incomeDomainModel = await incomeRepository.GetByIdAsync(id);

            if (incomeDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<IncomeDto>(incomeDomainModel));
        }

        // POST Income
        // POST: /api/incomes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncomeDto createIncomeDto)
        {
            // Map DTO to Domain Model
            var incomeDomainModel = mapper.Map<Income>(createIncomeDto);

            incomeDomainModel = await incomeRepository.CreateAsync(incomeDomainModel);

            // Map Domain Model to DTO
            return Ok(mapper.Map<IncomeDto>(incomeDomainModel));
        }

        // UPDATE Income
        // PUT: /api/incomes/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIncomeDto updateIncomeDto)
        {
            // Map DTO to Domain Model
            var incomeDomainModel = mapper.Map<Income>(updateIncomeDto);

            incomeDomainModel = await incomeRepository.UpdateAsync(id, incomeDomainModel);

            if (incomeDomainModel == null)
            {
                return NotFound();  
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<IncomeDto>(incomeDomainModel));
        }

        // DELETE Income
        // DELETE: /api/incomes
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedDomainModel = await incomeRepository.DeleteByIdAsync(id);

            if (deletedDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<IncomeDto?>(deletedDomainModel));
        }
    }
}
