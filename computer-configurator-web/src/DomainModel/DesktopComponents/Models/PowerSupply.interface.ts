import Part from "./Part.interface";

export interface PowerSupply extends Part {
	WattsOutput: number;
	FormFactor: string;
	EfficiencyRating: string;
	Modular: boolean;
	MeanTimeToFailure: number;
}
