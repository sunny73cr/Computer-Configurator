namespace ComputerConfigurator.Api.ChassisMotherboardFormFactorSupport
{
    public partial class ChassisMotherboardFormFactorSupport
    {
        public Guid ChassisUUID { get; set; }
        public Guid MotherboardFormFactorUUID { get; set; }

        public virtual Chassis.Chassis Chassis { get; set; } = null!;
        public virtual MotherboardFormFactor.MotherboardFormFactor MotherboardFormFactor { get; set; } = null!;

        public ChassisMotherboardFormFactorSupport()
        {

        }

        public ChassisMotherboardFormFactorSupport(Guid chassisUUID, DTO.Create ChassisAudioPort)
        {
            ChassisUUID = chassisUUID;
            MotherboardFormFactorUUID = ChassisAudioPort.MotherboardFormFactorUUID;
        }
    }
}
