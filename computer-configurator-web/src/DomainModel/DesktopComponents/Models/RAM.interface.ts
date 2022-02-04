import Part from "./Part.interface";

export interface RAM extends Part {
	Interface: string;
	Capacity: number;
	Count: number;
	ClockSpeed: number;
	Latency: RAMLatency;
}

interface RAMLatency {
	CAS: number;
	tRCD: number;
	tRP: number;
	tRAS: number;
}
