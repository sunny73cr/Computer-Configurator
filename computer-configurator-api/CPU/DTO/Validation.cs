namespace ComputerConfigurator.Api.CPU.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create create)
        {
            _errors.AddRange(new Part.DTO.Validation(create).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Core Count", create.CoreCount, 1, 512);

            DomainValidation.Numeric.ValueRange(_errors, "Thread Count", create.ThreadCount, create.CoreCount, 512);

            DomainValidation.Numeric.ValueRange(_errors, "Base Clock Speed", create.BaseClockSpeed, 1, 512);

            if (create.BoostClockSpeed != null)
                DomainValidation.Numeric.ValueRange(_errors, "Boost Clock Speed", (int)create.BoostClockSpeed, create.BaseClockSpeed, 512);
        }

        public Validation(DTO.Edit edit)
        {
            _errors.AddRange(new Part.DTO.Validation(edit).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Core Count", edit.CoreCount, 1, 512);

            DomainValidation.Numeric.ValueRange(_errors, "Thread Count", edit.ThreadCount, edit.CoreCount, 512);

            DomainValidation.Numeric.ValueRange(_errors, "Base Clock Speed", edit.BaseClockSpeed, 1, 512);

            if (edit.BoostClockSpeed != null)
                DomainValidation.Numeric.ValueRange(_errors, "Boost Clock Speed", (int)edit.BoostClockSpeed, edit.BaseClockSpeed, 512);
        }
    }
}