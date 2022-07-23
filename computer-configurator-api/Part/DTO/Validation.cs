namespace ComputerConfigurator.Api.Part.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create create)
        {
            DomainValidation.String.LengthRange(_errors, "Model", create.Model, 1, 50);

            DomainValidation.String.LengthRange(_errors, "Short description", create.ShortDescription, 1, 50);

            if (create.LongDescription != null)
                DomainValidation.String.LengthRange(_errors, "Long description", create.LongDescription, 1, 200);

            DomainValidation.Numeric.ValueRange(_errors, "Price", create.Price, 0M, 100000M);
        }

        public Validation(DTO.Edit edit)
        {
            DomainValidation.String.LengthRange(_errors, "Model", edit.Model, 1, 50);

            DomainValidation.String.LengthRange(_errors, "Short description", edit.ShortDescription, 1, 50);

            if (edit.LongDescription != null)
                DomainValidation.String.LengthRange(_errors, "Long description", edit.LongDescription, 1, 200);

            DomainValidation.Numeric.ValueRange(_errors, "Price", edit.Price, 0M, 100000M);
        }
    }
}
