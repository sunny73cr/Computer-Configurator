namespace ComputerConfigurator.Domain.Benchmarks.ChromiumCompilation;

public class ChromiumCompilation : Benchmark.Benchmark
{
    public float SecondsToCompile { get; set; }

    public List<string> Validate()
    {
        List<string> errors = new();

        base.Validate(errors);

        Validation.Numeric.ValueRange(errors, "Chromium compile time", SecondsToCompile, 1, 1000);

        return errors;
    }
}