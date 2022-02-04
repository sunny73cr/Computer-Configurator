import Benchmark from "./Benchmark.interface";

export default interface Cinebench extends Benchmark {
	SingleThreadedScore: number;
	MultiThreadedScore: number;
}
