﻿namespace ComputerConfigurator.Api.USBPort.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public string Interface { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
