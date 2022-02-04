import Benchmark from "./Benchmark.interface";

export default interface ChromiumCompilation extends Benchmark {
	CompileTime: number;
}
