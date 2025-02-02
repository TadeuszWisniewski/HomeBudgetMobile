using AutoMapper;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.Saving;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetMobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISavingRepository savingRepository;

        public SavingsController(IMapper mapper, ISavingRepository savingRepository)
        {
            this.mapper = mapper;
            this.savingRepository = savingRepository;
        }

        // CREATE Saving
        // POST: /api/savings
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSavingDto createSavingDto)
        {
            // Map DTO to Domain Model
            var savingDomainModel = mapper.Map<Saving>(createSavingDto);

            savingDomainModel = await savingRepository.CreateAsync(savingDomainModel);

            // Map Domain Model to DTO
            return Ok(mapper.Map<SavingDto>(savingDomainModel));
        }

        // GET Savings
        // GET: /api/savings
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var savingDomainModels = await savingRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<SavingDto>>(savingDomainModels));
        }

        // GET Saving
        // GET: /api/sagings/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var savingDomiainModel = await savingRepository.GetByIdAsync(id);

            if (savingDomiainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<SavingDto>(savingDomiainModel));
        }

        // UPDATE saving
        // PUT: /api/savings/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSavingDto updateSavingDto)
        {
            // Map DTO to Domain Model
            var savingDomainModel = mapper.Map<Saving>(updateSavingDto);

            savingDomainModel = await savingRepository.UpdateAsync(id, savingDomainModel);

            if (savingDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<SavingDto>(savingDomainModel));
        }

        // DELETE Saving
        // DELETE: /api/savings/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var savingDomainModel = await savingRepository.DeleteAsync(id);

            if(savingDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<SavingDto>(savingDomainModel));
        }
    }
}
