import Part from "./Part.interface";

export interface Chassis extends Part {
	Length: number;
	Width: number;
	Height: number;
	ChassisFanSupport: Array<ChassisFanSupport>;
	ChassisRadiatorSupport: Array<ChassisRadiatorSupport>;
	MaxGpuLength: number;
	MaxPsuLength: number;
	MaxCpuCoolerHeight: number;
	expansionSlotCount: number;
	OddBayCount: number;
	HddBayCount: number;
	SsdBayCount: number;
	PsuFormFactor: string;
	ChassisUSBSupport: Array<ChassisUSBSupport>;
	ChassisAudioConnectors: Array<ChassisAudioConnector>;
	RemoveableFilters: Array<ChassisFilterSupport>;
	ChassisMotherboardSupport: Array<string>;
}

interface ChassisFanSupport {
	ChassisFanSupportLocation: string;
	ChassisFanSupportDiameterAndCount: { [key: string]: number };
}

interface ChassisRadiatorSupport {
	ChassisRadiatorSupportLocation: string;
	ChassisRadiatorSupportRadiatorSize: Array<number>;
}

interface ChassisUSBSupport {
	ChassisUSBSupportType: string;
	ChassisUSBSupportInterface: string;
	ChassisUSBSupportCount: number;
}

interface ChassisAudioConnector {
	ChassisAudioConnectorInterface: string;
	ChassisAudioConnectorCount: number;
}

interface ChassisFilterSupport {
	ChassisFilterLocation: string;
	IsChassisFilterRemoveable: boolean;
}
