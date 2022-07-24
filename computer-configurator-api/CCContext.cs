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

            new CPUSocket.CPUSocketConfiguration().Configure(modelBuilder.Entity<CPUSocket.CPUSocket>());

            #endregion

            #region Auth

            new Account.AccountConfiguration().Configure(modelBuilder.Entity<Account.Account>());

            new Session.SessionConfiguration().Configure(modelBuilder.Entity<Session.Session>());

            #endregion

            #region Parts

            new CPU.CPUConfiguration().Configure(modelBuilder.Entity<CPU.CPU>());

            new Part.PartConfiguration().Configure(modelBuilder.Entity<Part.Part>());

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
