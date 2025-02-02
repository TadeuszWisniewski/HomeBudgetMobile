namespace HomeBudgetMobile.API.Model.DTO.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
