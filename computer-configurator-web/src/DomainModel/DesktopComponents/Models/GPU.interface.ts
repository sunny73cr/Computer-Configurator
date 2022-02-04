import Part from "./Part.interface";

export interface GPU extends Part {
	InterfaceType: string;
	VramCapacity: number;
	MaxClockSpeed: number;
	DisplayConnectors: Array<GPUDisplayConnector>;
	MaxDisplayCount: number;
	SlotWidth: number;
	CardLength: number;
}

interface GPUDisplayConnector {
	Interface: string;
	Version: string;
	Count: number;
}
