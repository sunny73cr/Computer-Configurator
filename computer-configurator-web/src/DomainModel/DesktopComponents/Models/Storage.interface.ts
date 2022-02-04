import Part from "./Part.interface";

interface Storage extends Part {
	Interface: string;
	Capacity: number;
	FormFactor: string;
	ReadSpeed: number;
	WriteSpeed: number;
	ReadIOPS?: number;
	WriteIOPS?: number;
	CacheSize?: number;
	MeanTimeBetweenFailure?: number;
	TerabytesWritten?: number;
}

export interface SolidStateDrive extends Storage {}

export interface Nvme extends Storage {
	Length: number;
}

export interface HardDiskDrive extends Storage {
	SpindleRPM: number;
}
