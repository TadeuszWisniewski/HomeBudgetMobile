using AutoMapper;
using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.User;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetMobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        // CREATE User
        //POST: /api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            // Map DTO to Domain Model
            var userDomainModel = mapper.Map<User>(createUserDto);

            userDomainModel = await userRepository.CreateAsync(userDomainModel);

            // Map Domain Model to DTO
            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        // GET Users
        // GET: /api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userDomainModels = await userRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<UserDto>>(userDomainModels));
        }

        // GET User
        // GET: /api/users/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userDomainModel = await userRepository.GetByIdAsync(id);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        // UPDATE User
        // PUT: /api/users/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            // Map DTO to Domain Model
            var userDomainModel = mapper.Map<User>(updateUserDto);

            userDomainModel = await userRepository.UpdateAsync(id, userDomainModel);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        // DELETE User
        // DELETE: /api/users/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var userDomainModel = await userRepository.DeleteAsync(id);

            if(userDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<UserDto>(userDomainModel));
        }
    }
}
