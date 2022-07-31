namespace ComputerConfigurator.Api.Account.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create create)
        {
            DomainValidation.String.LengthRange(_errors, "Email", create.Email, 1, 128);
            DomainValidation.String.LengthRange(_errors, "Name", create.Name, 1, 30);
            DomainValidation.String.LengthRange(_errors, "Password", create.Password, 8, 255);
        }

        public Validation(DTO.Edit edit)
        {
            DomainValidation.String.LengthRange(_errors, "Email", edit.Email, 1, 128);
            DomainValidation.String.LengthRange(_errors, "Name", edit.Name, 1, 30);
        }

        public Validation(DTO.ChangePassword changePassword)
        {
            DomainValidation.String.LengthRange(_errors, "New Password", changePassword.NewPassword, 8, 255);
        }
    }
}
