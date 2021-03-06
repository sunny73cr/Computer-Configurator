CREATE TABLE system (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    AuthorAccountUUID uuid NOT NULL,
    TimestampCreated timestamptz NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
    CPUUUID uuid NOT NULL,
    CPUCount integer NOT NULL,
    CPUCoolerUUID uuid NOT NULL,
    MotherboardUUID uuid NOT NULL,
    RAMUUID uuid NOT NULL,
    RAMCount integer NOT NULL,
    GPUUUID uuid NOT NULL,
    GPUCount integer NOT NULL,
    StorageUUID uuid NOT NULL,
    SystemRAIDUUID uuid NOT NULL,
    PowerSupplyUUID uuid NOT NULL,
    ChassisUUID uuid NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (CPUUUID) REFERENCES cpu(UUID),
    CONSTRAINT system_cpucount_range CHECK (CPUCount > 0 AND CPUCount <= 4),
    FOREIGN KEY (CPUCoolerUUID) REFERENCES cpucooler(UUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (RAMUUID) REFERENCES ram(UUID),
    CONSTRAINT system_ramcount_range CHECK (RAMCount > 0 AND RAMCount <= 32),
    FOREIGN KEY (GPUUUID) REFERENCES gpu(UUID),
    CONSTRAINT system_gpucount_range CHECK (GPUCount > 0 AND GPUCount <= 8),
    FOREIGN KEY (StorageUUID) REFERENCES storage(UUID),
    FOREIGN KEY (SystemRAIDUUID) REFERENCES systemraid(UUID),
    FOREIGN KEY (PowerSupplyUUID) REFERENCES powersupply(UUID),
    FOREIGN KEY (ChassisUUID) REFERENCES chassis(UUID)
);