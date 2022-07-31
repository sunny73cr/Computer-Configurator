using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api
{
    public partial class CCContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CCContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CCContext(DbContextOptions<CCContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        #region LookupTables

        public virtual DbSet<Manufacturer.Manufacturer> Manufacturer { get; set; } = null!;
        public virtual DbSet<AudioPort.AudioPort> AudioPort { get; set; } = null!;
        public virtual DbSet<BenchmarkedResolution.BenchmarkedResolution> BenchmarkedResolution { get; set; } = null!;
        public virtual DbSet<ChassisZone.ChassisZone> ChassisZone { get; set; } = null!;
        public virtual DbSet<CPUSocket.CPUSocket> CPUSocket { get; set; } = null!;
        public virtual DbSet<DisplayConnector.DisplayConnector> DisplayConnector { get; set; } = null!;
        public virtual DbSet<EightyPlusRating.EightyPlusRating> EightyPlusRating { get; set; } = null!;
        public virtual DbSet<EthernetPort.EthernetPort> EthernetPort { get; set; } = null!;
        public virtual DbSet<FanDiameter.FanDiameter> FanDiameter { get; set; } = null!;
        public virtual DbSet<FanHeader.FanHeader> FanHeader { get; set; } = null!;
        public virtual DbSet<FanVoltage.FanVoltage> FanVoltage { get; set; } = null!;
        public virtual DbSet<MotherboardChipset.MotherboardChipset> MotherboardChipset { get; set; } = null!;
        public virtual DbSet<MotherboardFormFactor.MotherboardFormFactor> MotherboardFormFactor { get; set; } = null!;
        public virtual DbSet<MountedStorageFormFactor.MountedStorageFormFactor> MountedStorageFormFactor { get; set; } = null!;
        public virtual DbSet<NVMEFormFactor.NVMEFormFactor> NVMEFormFactor { get; set; } = null!;
        public virtual DbSet<NVMEInterface.NVMEInterface> NVMEInterface { get; set; } = null!;
        public virtual DbSet<PCIEGeneration.PCIEGeneration> PCIEGeneration { get; set; } = null!;
        public virtual DbSet<PCIEConnector.PCIEConnector> PCIEConnector { get; set; } = null!;
        public virtual DbSet<PowerSupplyFormFactor.PowerSupplyFormFactor> PowerSupplyFormFactor { get; set; } = null!;
        public virtual DbSet<RadiatorSize.RadiatorSize> RadiatorSize { get; set; } = null!;
        public virtual DbSet<RAIDMode.RAIDMode> RAIDMode { get; set; } = null!;
        public virtual DbSet<RAMSocket.RAMSocket> RAMSocket { get; set; } = null!;
        public virtual DbSet<RAMSpeed.RAMSpeed> RAMSpeed { get; set; } = null!;
        public virtual DbSet<SATAGeneration.SATAGeneration> SATAGeneration { get; set; } = null!;
        public virtual DbSet<USBPort.USBPort> USBPort { get; set; } = null!;

        #endregion

        #region Auth

        public virtual DbSet<Account.Account> Account { get; set; } = null!;
        public virtual DbSet<Session.Session> Session { get; set; } = null!;

        #endregion

        #region Parts

        public virtual DbSet<Part.Part> Part { get; set; } = null!;
        public virtual DbSet<CPU.CPU> CPU { get; set; } = null!;

        public virtual DbSet<Chassis.Chassis> Chassis { get; set; } = null!;
        public virtual DbSet<ChassisAudioPort.ChassisAudioPort> ChassisAudioPort { get; set; } = null!;
        public virtual DbSet<ChassisFanSupport.ChassisFanSupport> ChassisFanSupport { get; set; } = null!;
        public virtual DbSet<ChassisFilterSupport.ChassisFilterSupport> ChassisFilterSupport { get; set; } = null!;
        public virtual DbSet<ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport> ChassisMotherboardFormFactorSupport { get; set; } = null!;
        public virtual DbSet<ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport> ChassisPowerSupplyFormFactorSupport { get; set; } = null!;
        public virtual DbSet<ChassisRadiatorSupport.ChassisRadiatorSupport> ChassisRadiatorSupport { get; set; } = null!;
        public virtual DbSet<ChassisUSBPort.ChassisUSBPort> ChassisUSBPort { get; set; } = null!;

        public virtual DbSet<CPUCooler.CPUCooler> CPUCooler { get; set; } = null!;
        public virtual DbSet<CPUCoolerFan.CPUCoolerFan> CPUCoolerFan { get; set; } = null!;
        public virtual DbSet<CPUCoolerCPUSocketSupport.CPUCoolerCPUSocketSupport> CPUCoolerCPUSocketSupport { get; set; } = null!;
        public virtual DbSet<CPUHeatsink.CPUHeatsink> CPUHeatsink { get; set; } = null!;
        public virtual DbSet<CPUClosedLoopCooler.CPUClosedLoopCooler> CPUClosedLoopCooler { get; set; } = null!;

        public virtual DbSet<Fan.Fan> Fan { get; set; } = null!;

        public virtual DbSet<GPU.GPU> GPU { get; set; } = null!;
        public virtual DbSet<GPUDisplayConnector.GPUDisplayConnector> GPUDisplayConnector { get; set; } = null!;

        public virtual DbSet<Motherboard.Motherboard> Motherboard { get; set; } = null!;
        public virtual DbSet<MotherboardDisplayConnector.MotherboardDisplayConnector> MotherboardDisplayConnector { get; set; } = null!;
        public virtual DbSet<MotherboardEthernetPort.MotherboardEthernetPort> MotherboardEthernetPort { get; set; } = null!;
        public virtual DbSet<MotherboardFanHeader.MotherboardFanHeader> MotherboardFanHeader { get; set; } = null!;
        public virtual DbSet<MotherboardNVMEConnector.MotherboardNVMEConnector> MotherboardNVMEConnector { get; set; } = null!;
        public virtual DbSet<MotherboardPCIEConnector.MotherboardPCIEConnector> MotherboardPCIEConnector { get; set; } = null!;
        public virtual DbSet<MotherboardRAMSocket.MotherboardRAMSocket> MotherboardRAMSocket { get; set; } = null!;
        public virtual DbSet<MotherboardRAMSpeed.MotherboardRAMSpeed> MotherboardRAMSpeed { get; set; } = null!;
        public virtual DbSet<MotherboardSATAConnector.MotherboardSATAConnector> MotherboardSATAConnector { get; set; } = null!;
        public virtual DbSet<MotherboardUSBPort.MotherboardUSBPort> MotherboardUSBPort { get; set; } = null!;

        public virtual DbSet<Storage.Storage> Storage { get; set; } = null!;
        public virtual DbSet<SATAHDD.SATAHDD> SATAHDD { get; set; } = null!;
        public virtual DbSet<SATASSD.SATASSD> SATASSD { get; set; } = null!;
        public virtual DbSet<NVMESSD.NVMESSD> NVMESSD { get; set; } = null!;

        public virtual DbSet<RAM.RAM> RAM { get; set; } = null!;

        public virtual DbSet<Radiator.Radiator> Radiator { get; set; } = null!;

        public virtual DbSet<PowerSupply.PowerSupply> PowerSupply { get; set; } = null!;
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration["DbConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region LookupTables

            new Manufacturer.ManufacturerConfiguration().Configure(modelBuilder.Entity<Manufacturer.Manufacturer>());
            
            new AudioPort.AudioPortConfiguration().Configure(modelBuilder.Entity<AudioPort.AudioPort>());
            
            new BenchmarkedResolution.BenchmarkedResolutionConfiguration().Configure(modelBuilder.Entity<BenchmarkedResolution.BenchmarkedResolution>());
            
            new ChassisZone.ChassisZoneConfiguration().Configure(modelBuilder.Entity<ChassisZone.ChassisZone>());
            
            new CPUSocket.CPUSocketConfiguration().Configure(modelBuilder.Entity<CPUSocket.CPUSocket>());
            
            new DisplayConnector.DisplayConnectorConfiguration().Configure(modelBuilder.Entity<DisplayConnector.DisplayConnector>());
            
            new EightyPlusRating.EightyPlusRatingConfiguration().Configure(modelBuilder.Entity<EightyPlusRating.EightyPlusRating>());
            
            new EthernetPort.EthernetPortConfiguration().Configure(modelBuilder.Entity<EthernetPort.EthernetPort>());
            
            new FanDiameter.FanDiameterConfiguration().Configure(modelBuilder.Entity<FanDiameter.FanDiameter>());
            new FanHeader.FanHeaderConfiguration().Configure(modelBuilder.Entity<FanHeader.FanHeader>());
            new FanVoltage.FanVoltageConfiguration().Configure(modelBuilder.Entity<FanVoltage.FanVoltage>());
            
            new MotherboardChipset.MotherboardChipsetConfiguration().Configure(modelBuilder.Entity<MotherboardChipset.MotherboardChipset>());
            new MotherboardFormFactor.MotherboardFormFactorConfiguration().Configure(modelBuilder.Entity<MotherboardFormFactor.MotherboardFormFactor>());

            new MountedStorageFormFactor.MountedStorageFormFactorConfiguration().Configure(modelBuilder.Entity<MountedStorageFormFactor.MountedStorageFormFactor>());
            
            new NVMEFormFactor.NVMEFormFactorConfiguration().Configure(modelBuilder.Entity<NVMEFormFactor.NVMEFormFactor>());
            new NVMEInterface.NVMEInterfaceConfiguration().Configure(modelBuilder.Entity<NVMEInterface.NVMEInterface>());
            
            new PCIEGeneration.PCIEGenerationConfiguration().Configure(modelBuilder.Entity<PCIEGeneration.PCIEGeneration>());
            new PCIEConnector.PCIEConnectorConfiguration().Configure(modelBuilder.Entity<PCIEConnector.PCIEConnector>());
            
            new PowerSupplyFormFactor.PowerSupplyFormFactorConfiguration().Configure(modelBuilder.Entity<PowerSupplyFormFactor.PowerSupplyFormFactor>());
            
            new RadiatorSize.RadiatorSizeConfiguration().Configure(modelBuilder.Entity<RadiatorSize.RadiatorSize>());
            
            new RAIDMode.RAIDModeConfiguration().Configure(modelBuilder.Entity<RAIDMode.RAIDMode>());
            
            new RAMSocket.RAMSocketConfiguration().Configure(modelBuilder.Entity<RAMSocket.RAMSocket>());
            new RAMSpeed.RAMSpeedConfiguration().Configure(modelBuilder.Entity<RAMSpeed.RAMSpeed>());
            
            new SATAGeneration.SATAGenerationConfiguration().Configure(modelBuilder.Entity<SATAGeneration.SATAGeneration>());
           
            new USBPort.USBPortConfiguration().Configure(modelBuilder.Entity<USBPort.USBPort>());

            #endregion

            #region Auth

            new Account.AccountConfiguration().Configure(modelBuilder.Entity<Account.Account>());

            new Session.SessionConfiguration().Configure(modelBuilder.Entity<Session.Session>());

            #endregion

            #region Parts

            new Part.PartConfiguration().Configure(modelBuilder.Entity<Part.Part>());

            new CPU.CPUConfiguration().Configure(modelBuilder.Entity<CPU.CPU>());

            new Chassis.ChassisConfiguration().Configure(modelBuilder.Entity<Chassis.Chassis>());
            new ChassisAudioPort.ChassisAudioPortConfiguration().Configure(modelBuilder.Entity<ChassisAudioPort.ChassisAudioPort>());
            new ChassisFanSupport.ChassisFanSupportConfiguration().Configure(modelBuilder.Entity<ChassisFanSupport.ChassisFanSupport>());
            new ChassisFilterSupport.ChassisFilterSupportConfiguration().Configure(modelBuilder.Entity<ChassisFilterSupport.ChassisFilterSupport>());
            new ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupportConfiguration().Configure(modelBuilder.Entity<ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport>());
            new ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupportConfiguration().Configure(modelBuilder.Entity<ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport>());
            new ChassisRadiatorSupport.ChassisRadiatorSupportConfiguration().Configure(modelBuilder.Entity<ChassisRadiatorSupport.ChassisRadiatorSupport>());
            new ChassisUSBPort.ChassisUSBPortConfiguration().Configure(modelBuilder.Entity<ChassisUSBPort.ChassisUSBPort>());

            new CPUCooler.CPUCoolerConfiguration().Configure(modelBuilder.Entity<CPUCooler.CPUCooler>());
            new CPUCoolerFan.CPUCoolerFanConfiguration().Configure(modelBuilder.Entity<CPUCoolerFan.CPUCoolerFan>());
            new CPUCoolerCPUSocketSupport.CPUCoolerCPUSocketSupportConfiguration().Configure(modelBuilder.Entity<CPUCoolerCPUSocketSupport.CPUCoolerCPUSocketSupport>());
            new CPUHeatsink.CPUHeatsinkConfiguration().Configure(modelBuilder.Entity<CPUHeatsink.CPUHeatsink>());
            new CPUClosedLoopCooler.CPUClosedLoopCoolerConfiguration().Configure(modelBuilder.Entity<CPUClosedLoopCooler.CPUClosedLoopCooler>());

            new Fan.FanConfiguration().Configure(modelBuilder.Entity<Fan.Fan>());

            new GPU.GPUConfiguration().Configure(modelBuilder.Entity<GPU.GPU>());
            new GPUDisplayConnector.GPUDisplayConnectorConfiguration().Configure(modelBuilder.Entity<GPUDisplayConnector.GPUDisplayConnector>());

            new Motherboard.MotherboardConfiguration().Configure(modelBuilder.Entity<Motherboard.Motherboard>());
            new MotherboardDisplayConnector.MotherboardDisplayConnectorConfiguration().Configure(modelBuilder.Entity<MotherboardDisplayConnector.MotherboardDisplayConnector>());
            new MotherboardEthernetPort.MotherboardEthernetPortConfiguration().Configure(modelBuilder.Entity<MotherboardEthernetPort.MotherboardEthernetPort>());
            new MotherboardFanHeader.MotherboardFanHeaderConfiguration().Configure(modelBuilder.Entity<MotherboardFanHeader.MotherboardFanHeader>());
            new MotherboardNVMEConnector.MotherboardNVMEConnectorConfiguration().Configure(modelBuilder.Entity<MotherboardNVMEConnector.MotherboardNVMEConnector>());
            new MotherboardPCIEConnector.MotherboardPCIEConnectorConfiguration().Configure(modelBuilder.Entity<MotherboardPCIEConnector.MotherboardPCIEConnector>());
            new MotherboardRAMSocket.MotherboardRAMSocketConfiguration().Configure(modelBuilder.Entity<MotherboardRAMSocket.MotherboardRAMSocket>());
            new MotherboardRAMSpeed.MotherboardRAMSpeedConfiguration().Configure(modelBuilder.Entity<MotherboardRAMSpeed.MotherboardRAMSpeed>());
            new MotherboardSATAConnector.MotherboardSATAConnectorConfiguration().Configure(modelBuilder.Entity<MotherboardSATAConnector.MotherboardSATAConnector>());
            new MotherboardUSBPort.MotherboardUSBPortConfiguration().Configure(modelBuilder.Entity<MotherboardUSBPort.MotherboardUSBPort>());

            new Storage.StorageConfiguration().Configure(modelBuilder.Entity<Storage.Storage>());
            new SATAHDD.SATAHDDConfiguration().Configure(modelBuilder.Entity<SATAHDD.SATAHDD>());
            new SATASSD.SATASSDConfiguration().Configure(modelBuilder.Entity<SATASSD.SATASSD>());
            new NVMESSD.NVMESSDConfiguration().Configure(modelBuilder.Entity<NVMESSD.NVMESSD>());

            new RAM.RAMConfiguration().Configure(modelBuilder.Entity<RAM.RAM>());

            new Radiator.RadiatorConfiguration().Configure(modelBuilder.Entity<Radiator.Radiator>());

            new PowerSupply.PowerSupplyConfiguration().Configure(modelBuilder.Entity<PowerSupply.PowerSupply>());
            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
