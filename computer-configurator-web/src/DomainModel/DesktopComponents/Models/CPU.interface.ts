import Part from "./Part.interface";

export interface CPU extends Part {
	SocketType: string;
	CoreCount: number;
	ThreadCount: number;
	BaseClockSpeed: number;
	BoostClockSpeed: number;
}
