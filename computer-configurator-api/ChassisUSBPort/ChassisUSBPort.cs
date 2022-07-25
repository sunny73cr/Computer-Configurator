namespace ComputerConfigurator.Api.ChassisUSBPort
{
    public partial class ChassisUSBPort
    {
        public Guid ChassisUUID { get; set; }
        public Guid USBPortUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }
        public int Count { get; set; }

        public virtual Chassis.Chassis Chassis { get; set; } = null!;
        public virtual USBPort.USBPort USBPort {get; set;} = null!;
        public virtual ChassisZone.ChassisZone ChassisZone { get; set; } = null!;

        public ChassisUSBPort()
        {

        }

        public ChassisUSBPort(Guid chassisUUID, DTO.Create ChassisUSBPort)
        {
            ChassisUUID = chassisUUID;
            USBPortUUID = ChassisUSBPort.USBPortUUID;
            ChassisZoneUUID = ChassisUSBPort.ChassisZoneUUID;
            Count = ChassisUSBPort.Count;
        }
    }
}
