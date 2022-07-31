namespace ComputerConfigurator.Api.PowerSupply.DTO
{
    public class Edit : Part.DTO.Edit
    {
        public int MaximumOutputWatts { get; set; }
        public Guid PowerSupplyFormFactorUUID { get; set; }
        public int LengthMM { get; set; }
        public bool ModularCables { get; set; }
        public int? MTBF { get; set; }
        public Guid EightyPlusRatingUUID { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
