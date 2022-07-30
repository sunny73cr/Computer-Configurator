namespace ComputerConfigurator.Api.Account.DTO
{
    public class ChangePassword
    {
        public Guid AccountUUID { get; set; }
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
