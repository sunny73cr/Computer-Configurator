namespace ComputerConfigurator.Api.ChassisPowerSupplyFormFactorSupport
{
    public partial class ChassisPowerSupplyFormFactorSupport
    {
        public Guid ChassisUUID { get; set; }
        public Guid PowerSupplyFormFactorUUID { get; set; }
        public bool BracketRequired { get; set; }

        public virtual Chassis.Chassis Chassis { get; set; } = null!;
        public virtual PowerSupplyFormFactor.PowerSupplyFormFactor PowerSupplyFormFactor { get; set; } = null!;

        public ChassisPowerSupplyFormFactorSupport()
        {

        }

        public ChassisPowerSupplyFormFactorSupport(Guid chassisUUID, DTO.Create ChassisAudioPort)
        {
            ChassisUUID = chassisUUID;
            PowerSupplyFormFactorUUID = ChassisAudioPort.PowerSupplyFormFactorUUID;
            BracketRequired = ChassisAudioPort.BracketRequired;
        }

        public static void Edit(ChassisPowerSupplyFormFactorSupport chassisPowerSupplyFormFactorSupport, DTO.Edit edits)
        {
            if (chassisPowerSupplyFormFactorSupport.BracketRequired != edits.BracketRequired) chassisPowerSupplyFormFactorSupport.BracketRequired = edits.BracketRequired;
        }
    }
}
