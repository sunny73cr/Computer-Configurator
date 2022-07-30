begin;
    \ir DDL/parts/manufacturer/table_manufacturer.sql;

    \ir DDL/parts/lookuptables/table_audioport.sql;
	\ir DDL/parts/lookuptables/table_chassiszone.sql;
	\ir DDL/parts/lookuptables/table_cpusocket.sql;
	\ir DDL/parts/lookuptables/table_displayconnector.sql;
	\ir DDL/parts/lookuptables/table_eightyplusrating.sql;
	\ir DDL/parts/lookuptables/table_ethernetport.sql;
	\ir DDL/parts/lookuptables/table_fandiameter.sql;
	\ir DDL/parts/lookuptables/table_fanheader.sql;
	\ir DDL/parts/lookuptables/table_fanvoltage.sql;
	\ir DDL/parts/lookuptables/table_motherboardchipset.sql;
	\ir DDL/parts/lookuptables/table_motherboardformfactor.sql;
	\ir DDL/parts/lookuptables/table_mountedstorageformfactor.sql;
	\ir DDL/parts/lookuptables/table_nvmeformfactor.sql;
	\ir DDL/parts/lookuptables/table_nvmeinterface.sql;
	\ir DDL/parts/lookuptables/table_pciegeneration.sql;
	\ir DDL/parts/lookuptables/table_pcieconnector.sql;
	\ir DDL/parts/lookuptables/table_powersupplyformfactor.sql;
	\ir DDL/parts/lookuptables/table_radiatorsize.sql;
	\ir DDL/parts/lookuptables/table_ramsocket.sql;
	\ir DDL/parts/lookuptables/table_ramspeed.sql;
	\ir DDL/parts/lookuptables/table_satageneration.sql;
	\ir DDL/parts/lookuptables/table_usbport.sql;

	\ir DDL/parts/part/table_part.sql;

	\ir DDL/parts/chassis/table_chassis.sql;
	\ir DDL/parts/chassis/linktables/table_chassis_powersupplyformfactorsupport.sql;
	\ir DDL/parts/chassis/linktables/table_chassis_audioport.sql;
	\ir DDL/parts/chassis/linktables/table_chassis_usbport.sql;
	\ir DDL/parts/chassis/linktables/table_chassis_motherboardformfactorsupport.sql;
	\ir DDL/parts/chassis/linktables/table_chassis_filtersupport.sql;
	\ir DDL/parts/chassis/linktables/table_chassis_radiatorsupport.sql;
	\ir DDL/parts/chassis/linktables/table_chassis_fansupport.sql;

	\ir DDL/parts/powersupply/table_powersupply.sql;

	\ir DDL/parts/storage/table_storage.sql;
	\ir DDL/parts/storage/table_satahdd.sql;
	\ir DDL/parts/storage/table_satassd.sql;
	\ir DDL/parts/storage/table_nvmessd.sql;

	\ir DDL/parts/gpu/table_gpu.sql;
	\ir DDL/parts/gpu/linktables/table_gpu_displayconnector.sql;

	\ir DDL/parts/ram/table_ram.sql;

	\ir DDL/parts/motherboard/table_motherboard.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_fanheader.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_nvmeconnector.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_sataconnector.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_displayconnector.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_usbport.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_pcieconnector.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_ethernetport.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_ramspeed.sql;
	\ir DDL/parts/motherboard/linktables/table_motherboard_ramsocket.sql;

	\ir DDL/parts/radiator/table_radiator.sql;

	\ir DDL/parts/fan/table_fan.sql;

	\ir DDL/parts/cpucooler/table_cpucooler.sql;
	\ir DDL/parts/cpucooler/table_cpuclosedloopcooler.sql;
	\ir DDL/parts/cpucooler/table_cpuheatsink.sql;
	\ir DDL/parts/cpucooler/linktables/table_cpucooler_fan.sql;
	\ir DDL/parts/cpucooler/linktables/table_cpucooler_cpusocket_support.sql;

	\ir DDL/parts/cpu/table_cpu.sql;

    \ir DDL/system/lookuptables/table_raidmode.sql;
	\ir DDL/system/linktables/table_systemraid.sql;	
	\ir DDL/system/table_system.sql;
	\ir DDL/system/linktables/table_system_fan.sql;

	\ir DDL/auth/table_account.sql;
	\ir DDL/auth/table_session.sql;

    \ir DDL/systembenchmarks/lookuptables/table_benchmarkedresolution.sql;

	\ir DDL/systembenchmarks/systembenchmark/table_systembenchmark.sql;
	\ir DDL/systembenchmarks/videogame/table_videogame.sql;
	\ir DDL/systembenchmarks/pugetbench/table_pugetbench.sql;
	\ir DDL/systembenchmarks/cinebench/table_cinebench.sql;
	\ir DDL/systembenchmarks/chromiumcompilation/table_chromiumcompilation.sql;
commit;
