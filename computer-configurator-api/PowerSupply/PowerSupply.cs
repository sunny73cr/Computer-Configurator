namespace ComputerConfigurator.Api.PowerSupply
{
    public class PowerSupply : Part.Part
    {
        public int MaximumOutputWatts { get; set; }
        public Guid PowerSupplyFormFactorUUID { get; set; }
        public int LengthMM { get; set; }
        public bool ModularCables { get; set; }
        public int? MTBF { get; set; }
        public Guid EightyPlusRatingUUID { get; set; }

        public virtual Part.Part Part { get; set; } = null!;
        public virtual EightyPlusRating.EightyPlusRating EightyPlusRating { get; set; } = null!;
        public virtual PowerSupplyFormFactor.PowerSupplyFormFactor PowerSupplyFormFactor { get; set; } = null!;

        public PowerSupply()
        {

        }

        public PowerSupply(DTO.Create powerSupply) : base(powerSupply)
        {
            MaximumOutputWatts = powerSupply.MaximumOutputWatts;
            PowerSupplyFormFactorUUID = powerSupply.PowerSupplyFormFactorUUID;
            LengthMM = powerSupply.LengthMM;
            ModularCables = powerSupply.ModularCables;
            MTBF = powerSupply.MTBF;
            EightyPlusRatingUUID = powerSupply.EightyPlusRatingUUID;
        }

        public static void Edit(PowerSupply powerSupply, DTO.Edit edits)
        {
            Api.Part.Part.Edit(powerSupply, edits);

            if (powerSupply.MaximumOutputWatts != edits.MaximumOutputWatts) powerSupply.MaximumOutputWatts = edits.MaximumOutputWatts;
            if (powerSupply.PowerSupplyFormFactorUUID != edits.PowerSupplyFormFactorUUID) powerSupply.PowerSupplyFormFactorUUID = edits.PowerSupplyFormFactorUUID;
            if (powerSupply.LengthMM != edits.LengthMM) powerSupply.LengthMM = edits.LengthMM;
            if (powerSupply.ModularCables != edits.ModularCables) powerSupply.ModularCables = edits.ModularCables;
            if (powerSupply.MTBF != edits.MTBF) powerSupply.MTBF = edits.MTBF;
            if (powerSupply.EightyPlusRatingUUID != edits.EightyPlusRatingUUID) powerSupply.EightyPlusRatingUUID = edits.EightyPlusRatingUUID;
        }
    }
}
