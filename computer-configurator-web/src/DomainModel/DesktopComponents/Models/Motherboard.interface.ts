import Part from "./Part.interface";

export interface Motherboard extends Part {
	FormFactor: string;
	CpuSocketType: string;
	Chipset: string;
	RamSocketType: string;
	RamSocketCount: number;
	RamMaxCapacity: number;
	RamSpeedSupport: Array<MotherboardRAMSpeedInformation>;
	WifiSupport: boolean;
	PcieSlots: Array<MotherboardPCIEConnector>;
	StorageSupport: Array<MotherboardStorageConnector>;
	LanConnections: Array<MotherboardLANConnector>;
	AudioConnections: Array<MotherboardAudioConnector>;
	UsbPorts: Array<MotherboardUSBConnector>;
	FanConnectors: Array<MotherboardFanConnector>;
}

interface MotherboardAudioConnector {
	Type: string;
	Count: number;
}

interface MotherboardRAMSpeedInformation {
	ClockSpeedSupport: number;
	IsOverClockProfile: boolean;
}

interface MotherboardPCIEConnector {
	PinLength: string;
	Count: number;
}

interface MotherboardStorageConnector {
	Interface: string;
	Count: number;
}

export interface NvmeStorageConnector extends MotherboardStorageConnector {
	FormFactorSupport: Array<string>;
}

interface MotherboardLANConnector {
	Bandwidth: number;
	Count: number;
}

interface MotherboardUSBConnector {
	Version: string;
	Interface: string;
	Count: number;
	Location: string;
}

interface MotherboardFanConnector {
	PinCount: number;
	Count: number;
}
