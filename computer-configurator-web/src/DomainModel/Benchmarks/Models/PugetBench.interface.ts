import Benchmark from "./Benchmark.interface";

export default interface PugetBench extends Benchmark {
	BenchmarkName: string;
	BenchmarkVersion: string;
	OverallScore: number;
}
