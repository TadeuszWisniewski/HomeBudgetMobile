namespace HomeBudgetMobile.API.Model.DTO.User
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public List<Guid> Incomes { get; } = [];
        public List<Guid> Savings { get; } = [];
        public List<Guid> Expenses { get; } = [];
    }
}
