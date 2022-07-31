namespace ComputerConfigurator.Api.Storage.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create storage)
        {
            _errors.AddRange(new Part.DTO.Validation(storage).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Capacity", storage.CapacityGBytes, 16, 40000);
            DomainValidation.Numeric.ValueRange(_errors, "Read bandwidth", storage.ReadBandwidth, 1, 14000);
            DomainValidation.Numeric.ValueRange(_errors, "Write bandwidth", storage.WriteBandwidth, 1, 14000);

            if (storage.ReadIOPS != null)
                DomainValidation.Numeric.ValueRange(_errors, "Read IOPS", (int)storage.ReadIOPS, 1, 2000000);

            if (storage.WriteIOPS != null)
                DomainValidation.Numeric.ValueRange(_errors, "Write IOPS", (int)storage.WriteIOPS, 1, 2000000);
            
            if (storage.MTBF != null)
                DomainValidation.Numeric.ValueRange(_errors, "Mean time between failures", (int)storage.MTBF, 1, 4000000);
            
            if (storage.MaxTBW != null)
                DomainValidation.Numeric.ValueRange(_errors, "Maximum terabytes written", (int)storage.MaxTBW, 1, 20000);
            
            if (storage.CacheSizeMBytes != null)
                DomainValidation.Numeric.ValueRange(_errors, "Cache size", (int)storage.CacheSizeMBytes, 1, 5000);
        }

        public Validation(DTO.Edit storage)
        {
            _errors.AddRange(new Part.DTO.Validation(storage).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Capacity", storage.CapacityGBytes, 16, 40000);
            DomainValidation.Numeric.ValueRange(_errors, "Read bandwidth", storage.ReadBandwidth, 1, 14000);
            DomainValidation.Numeric.ValueRange(_errors, "Write bandwidth", storage.WriteBandwidth, 1, 14000);

            if (storage.ReadIOPS != null)
                DomainValidation.Numeric.ValueRange(_errors, "Read IOPS", (int)storage.ReadIOPS, 1, 2000000);

            if (storage.WriteIOPS != null)
                DomainValidation.Numeric.ValueRange(_errors, "Write IOPS", (int)storage.WriteIOPS, 1, 2000000);

            if (storage.MTBF != null)
                DomainValidation.Numeric.ValueRange(_errors, "Mean time between failures", (int)storage.MTBF, 1, 4000000);

            if (storage.MaxTBW != null)
                DomainValidation.Numeric.ValueRange(_errors, "Maximum terabytes written", (int)storage.MaxTBW, 1, 20000);

            if (storage.CacheSizeMBytes != null)
                DomainValidation.Numeric.ValueRange(_errors, "Cache size", (int)storage.CacheSizeMBytes, 1, 5000);
        }
    }
}
