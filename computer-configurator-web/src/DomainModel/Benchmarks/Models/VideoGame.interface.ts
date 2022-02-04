import Benchmark from "./Benchmark.interface";

export default interface VideoGame extends Benchmark {
	PixelWidth: number;
	PixelHeight: number;
	VideoGameName: string;
	FpsPointOnePercentLow: number;
	FpsOnePercentLow: number;
	FpsAverage: number;
}
