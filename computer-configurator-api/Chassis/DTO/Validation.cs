namespace ComputerConfigurator.Api.Chassis.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create chassis)
        {
            _errors.AddRange(new Part.DTO.Validation(chassis).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Length", chassis.LengthMM, 1, 1000);
            DomainValidation.Numeric.ValueRange(_errors, "Width", chassis.WidthMM, 1, 1000);
            DomainValidation.Numeric.ValueRange(_errors, "Height", chassis.HeightMM, 1, 1000);
            DomainValidation.Numeric.ValueRange(_errors, "GPU Length", chassis.MaxGPULengthMM, 100, 350);
            DomainValidation.Numeric.ValueRange(_errors, "PSU Length", chassis.MaxPSULengthMM, 100, 240);
            DomainValidation.Numeric.ValueRange(_errors, "CPU Cooler Height", chassis.MaxCPUCoolerHeightMM, 30, 210);
            DomainValidation.Numeric.ValueRange(_errors, "PCIE Slot Count", chassis.PCIESlotCount, 1, 10);
        }

        public Validation(DTO.Edit chassis)
        {
            _errors.AddRange(new Part.DTO.Validation(chassis).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Length", chassis.LengthMM, 1, 1000);
            DomainValidation.Numeric.ValueRange(_errors, "Width", chassis.WidthMM, 1, 1000);
            DomainValidation.Numeric.ValueRange(_errors, "Height", chassis.HeightMM, 1, 1000);
            DomainValidation.Numeric.ValueRange(_errors, "GPU Length", chassis.MaxGPULengthMM, 100, 350);
            DomainValidation.Numeric.ValueRange(_errors, "PSU Length", chassis.MaxPSULengthMM, 100, 240);
            DomainValidation.Numeric.ValueRange(_errors, "CPU Cooler Height", chassis.MaxCPUCoolerHeightMM, 30, 210);
            DomainValidation.Numeric.ValueRange(_errors, "PCIE Slot Count", chassis.PCIESlotCount, 1, 10);
        }
    }
}
