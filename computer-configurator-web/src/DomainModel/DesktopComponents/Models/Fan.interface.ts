import Part from "./Part.interface";

export interface Fan extends Part {
	FanDiameter: number;
	FanWidth: number;
	PwmSupport: boolean;
	RotationalSpeed: number;
	Airflow: number;
	StaticPressure: number;
	AcousticOutput: number;
	Voltage: number;
	MaxCurrent: number;
	FanMeanTimeToFailure: number;
}
