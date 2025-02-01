using AutoMapper;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.Goal;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetMobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGoalRepository goalRepository;

        public GoalController(IMapper mapper, IGoalRepository goalRepository)
        {
            this.mapper = mapper;
            this.goalRepository = goalRepository;
        }

        // GET Goals
        // GET: /api/Goals
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var goalsDomainModel = await goalRepository.GetAllAsync();

            // Map Domain model to DTO
            return Ok(mapper.Map<List<GoalDto>>(goalsDomainModel));
        }

        // GET Goals
        // GET: /api/Goals
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var goalDomainModel = await goalRepository.GetByIdAsync(id);

            if (goalDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain model to DTO
            return Ok(mapper.Map<GoalDto>(goalDomainModel));
        }

        // CREATE Goal
        // POST: /api/Goals
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGoalDto createGoalDto)
        {
            // Map DTO to Domain model
            var goalDomainModel = mapper.Map<Goal>(createGoalDto);

            goalDomainModel = await goalRepository.CreateAsync(goalDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<GoalDto>(goalDomainModel));
        }

        // UPDATE Goal
        // PUT: /api/Goals/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGoalDto updateGoalDto)
        {
            // Map DTO to Domain model
            var goalDomainModel = mapper.Map<Goal>(updateGoalDto);

            goalDomainModel = await goalRepository.UpdateAsync(id, goalDomainModel);

            if (goalDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain model to DTO
            return Ok(mapper.Map<GoalDto>(goalDomainModel));
        }

        // DELETE Goal
        // DELETE: /api/goals/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var goalDomainModel = await goalRepository.DeleteAsync(id);

            if (goalDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain model to DTO
            return Ok(mapper.Map<GoalDto>(goalDomainModel));
        }
    }
}
