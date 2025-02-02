namespace HomeBudgetMobile.API.Model.DTO.User
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
