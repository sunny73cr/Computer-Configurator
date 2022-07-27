namespace ComputerConfigurator.Api.GPU.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create gpu)
        {
            DomainValidation.Numeric.ValueRange(_errors, "VRAM", gpu.VRAMMBytes, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Base Clock Speed", gpu.BaseClockSpeed, 0, 0);

            if (gpu.BoostClockSpeed != null)
                DomainValidation.Numeric.ValueRange(_errors, "Boost Clock Speed", (int)gpu.BoostClockSpeed, 0, 0);

            DomainValidation.Numeric.ValueRange(_errors, "Max Display Count", gpu.MaxDisplayCount, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Length", gpu.LengthMM, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Width", gpu.WidthMM, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Height", gpu.HeightMM, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Slot width", gpu.SlotWidth, 0, 0);
        }

        public Validation(DTO.Edit gpu)
        {
            DomainValidation.Numeric.ValueRange(_errors, "VRAM", gpu.VRAMMBytes, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Base Clock Speed", gpu.BaseClockSpeed, 0, 0);

            if (gpu.BoostClockSpeed != null)
                DomainValidation.Numeric.ValueRange(_errors, "Boost Clock Speed", (int)gpu.BoostClockSpeed, 0, 0);

            DomainValidation.Numeric.ValueRange(_errors, "Max Display Count", gpu.MaxDisplayCount, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Length", gpu.LengthMM, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Width", gpu.WidthMM, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Height", gpu.HeightMM, 0, 0);
            DomainValidation.Numeric.ValueRange(_errors, "Slot width", gpu.SlotWidth, 0, 0);
        }
    }
}
