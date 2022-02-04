import Part from "./Part.interface";

export interface CPUCooler extends Part {
	SocketSupport: Array<string>;
	CoolerHeight: number;
	CoolerFanName: string;
	FanCount: number;
}
