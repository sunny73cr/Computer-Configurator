begin;
    \ir DDL/auth/table_account.sql;
    \ir DDL/auth/table_session.sql;
    \ir DDL/auth/table_account_session.sql;

    \ir DDL/part/table_part.sql;

    \ir DDL/cpu/types/type_cpusockettype.sql;
    \ir DDL/cpu/table_cpu.sql;

	\ir DDL/motherboard/types/type_fanheaderinterface.sql;
	\ir DDL/motherboard/types/type_motherboardformfactor.sql;
	\ir DDL/motherboard/types/type_nvmestorageconnectorlength.sql;
	\ir DDL/motherboard/types/type_pcielength.sql;
    \ir DDL/motherboard/types/type_pcieversion.sql;
	\ir DDL/motherboard/types/type_usbconnectorinterface.sql;
    \ir DDL/motherboard/types/type_usbconnectorversion.sql;
	
	\ir DDL/motherboard/table_motherboardsocket.sql;
	\ir DDL/motherboard/table_chipset.sql;
	\ir DDL/motherboard/table_fanheader.sql;
    \ir DDL/motherboard/table_lanport.sql;
	\ir DDL/motherboard/table_pcieconnector.sql;
	\ir DDL/motherboard/table_ramsocket.sql;
	\ir DDL/motherboard/table_ramspeedsupport.sql;
    \ir DDL/motherboard/table_usbconnector.sql;
	
    \ir DDL/motherboard/table_motherboard.sql;

	\ir DDL/motherboard/linktables/table_motherboard_fanheader.sql;
	\ir DDL/motherboard/linktables/table_motherboard_lanconnector.sql;
	\ir DDL/motherboard/linktables/table_motherboard_nvmestorageconnector.sql;
	\ir DDL/motherboard/linktables/table_motherboard_pcieconnector.sql;
	\ir DDL/motherboard/linktables/table_motherboard_ramspeedsupport.sql;
	\ir DDL/motherboard/linktables/table_motherboard_satastorageconnector.sql;
	\ir DDL/motherboard/linktables/table_motherboard_usbconnector.sql;
commit;
