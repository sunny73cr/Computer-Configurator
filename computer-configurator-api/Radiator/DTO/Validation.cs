namespace ComputerConfigurator.Api.Radiator.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create radiator)
        {
            _errors.AddRange(new Api.Part.DTO.Validation(radiator).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Width", radiator.WidthMM, 25, 80);
            DomainValidation.Numeric.ValueRange(_errors, "Tube Inner Diameter", radiator.TubeInnerDiameterMM, 1, 20);
            DomainValidation.Numeric.ValueRange(_errors, "Tube Outer Diameter", radiator.TubeOuterDiameterMM, 1, 40);
        }

        public Validation(DTO.Edit radiator)
        {
            _errors.AddRange(new Api.Part.DTO.Validation(radiator).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Width", radiator.WidthMM, 25, 80);
            DomainValidation.Numeric.ValueRange(_errors, "Tube Inner Diameter", radiator.TubeInnerDiameterMM, 1, 20);
            DomainValidation.Numeric.ValueRange(_errors, "Tube Outer Diameter", radiator.TubeOuterDiameterMM, 1, 40);
        }
    }
}
