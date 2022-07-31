namespace ComputerConfigurator.Api.PowerSupply.DTO
{
    public class Details : Part.DTO.Details
    {
        public int MaximumOutputWatts { get; set; }
        public PowerSupplyFormFactor.DTO.Details PowerSupplyFormFactor { get; set; }
        public int LengthMM { get; set; }
        public bool ModularCables { get; set; }
        public int? MTBF { get; set; }
        public EightyPlusRating.DTO.Details EightyPlusRating { get; set; }

        public Details(PowerSupply powerSupply) : base(powerSupply)
        {
            MaximumOutputWatts = powerSupply.MaximumOutputWatts;
            PowerSupplyFormFactor = new PowerSupplyFormFactor.DTO.Details(powerSupply.PowerSupplyFormFactor);
            LengthMM = powerSupply.LengthMM;
            ModularCables = powerSupply.ModularCables;
            MTBF = powerSupply.MTBF;
            EightyPlusRating = new EightyPlusRating.DTO.Details(powerSupply.EightyPlusRating);
        }
    }
}
