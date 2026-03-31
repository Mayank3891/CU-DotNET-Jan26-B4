namespace AccountsAPI.DTO
{
    public class CreateAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal InitialDeposit { get; set; }
    }
}
