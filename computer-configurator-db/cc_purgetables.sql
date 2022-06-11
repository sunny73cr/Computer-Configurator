drop table if exists account_session;
drop table if exists account;
drop table if exists session;

drop table if exists cpu;
drop type if exists cpusockettype;

drop table if exists chipset;
drop table if exists fanheader;
drop table if exists lanport;
drop table if exists motherboardsocket;
drop table if exists pcieconnector;
drop table if exists ramsocket;
drop table if exists ramspeedsupport;
drop table if exists usbconnector;

drop table if exists motherboard_fanheader;
drop table if exists motherboard_lanconnector;
drop table if exists motherboard_nvmestorageconnector;
drop table if exists motherboard_pcieconnector;
drop table if exists motherboard_ramspeedsupport;
drop table if exists motherboard_satastorageconnector;
drop table if exists motherboard_usbconnector;

drop table if exists motherboard;

drop type if exists fanheaderinterface;
drop type if exists motherboardformfactor;
drop type if exists nvmestorageconnectorlength;
drop type if exists pcielength;
drop type if exists pcieversion;
drop type if exists usbconnectorinterface;
drop type if exists usbconnectorversion;

drop table if exists part;