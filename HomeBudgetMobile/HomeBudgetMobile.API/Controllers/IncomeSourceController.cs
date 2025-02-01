using AutoMapper;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.IncomeSource;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetMobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeSourceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IIncomeSourceRepository incomeSourceRepository;

        public IncomeSourceController(IMapper mapper, IIncomeSourceRepository incomeSourceRepository)
        {
            this.mapper = mapper;
            this.incomeSourceRepository = incomeSourceRepository;
        }

        // GET IncomeSources
        // GET: /api/IncomeSources
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incomeSourcesDomainModels = await incomeSourceRepository.GetAllAsync();

            // Map Domain model to DTO
            return Ok(mapper.Map<List<IncomeSourceDto>>(incomeSourcesDomainModels));
        }

        // GET incomeSources by id
        // GET: /api/IncomeSources/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var incomeSourcesDomainModels = await incomeSourceRepository.GetByIdAsync(id);

            if (incomeSourcesDomainModels == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<IncomeSourceDto>(incomeSourcesDomainModels));
        }

        // UPDATE incomeSource
        // PUT: /api/IncomeSource/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIncomeSourceDto updateIncomeSourceDto)
        {
            var updatedIncomeSource = await incomeSourceRepository.UpdateAsync(id, mapper.Map<IncomeSource>(updateIncomeSourceDto));

            if (updatedIncomeSource == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<UpdateIncomeSourceDto>(updatedIncomeSource));
        }

        // CREATE incomeSource
        // POST: /api/IncomeSource
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncomeSourceDto createIncomeSourceDto) 
        {
            // Map DTO to Domain Model  
            var incomeSourceDomainModel = mapper.Map<IncomeSource>(createIncomeSourceDto);

            await incomeSourceRepository.CreateAsync(incomeSourceDomainModel);

            // Map Domain Model to DTO
            return Ok(mapper.Map<IncomeSourceDto>(incomeSourceDomainModel));
        }

        // DELETE incomeSource
        // DELETE: /api/IncomeSource
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var incomeSourceDomainModel = await incomeSourceRepository.DeleteAsync(id);

            if (incomeSourceDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<IncomeSourceDto>(incomeSourceDomainModel));
        }
    }
}
