﻿namespace ComputerConfigurator.Api.MountedStorageFormFactor.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public string Size { get; set; } = string.Empty;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
