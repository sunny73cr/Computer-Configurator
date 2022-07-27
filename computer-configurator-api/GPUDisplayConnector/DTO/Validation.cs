﻿namespace ComputerConfigurator.Api.GPUDisplayConnector.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create gpuDisplayConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", gpuDisplayConnector.Count, 1, 6);
        }

        public Validation(DTO.Edit gpuDisplayConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", gpuDisplayConnector.Count, 1, 6);
        }
    }
}
