namespace ComputerConfigurator.Api.MountedStorageFormFactor.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create MountedStorageFormFactor)
        {
            DomainValidation.String.LengthRange(_errors, "Size", MountedStorageFormFactor.Size, 1, 15);
        }

        public Validation(Edit MountedStorageFormFactor)
        {
            DomainValidation.String.LengthRange(_errors, "Size", MountedStorageFormFactor.Size, 1, 15);
        }
    }
}
