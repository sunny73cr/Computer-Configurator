namespace ComputerConfigurator.Domain.Benchmarks.PugetBench;

public class PugetBench : Benchmark.Benchmark
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public float OverallScore { get; set; }

    public List<string> Validate()
    {
        List<string> errors = new();

        base.Validate(errors);

        Validation.String.LengthRange(errors, "Name", Name, 1, 30);
        Validation.String.LengthRange(errors, "Version", Version, 1, 30);
        Validation.Numeric.ValueRange(errors, "Overall score", OverallScore, 1, 10000);

        return errors;
    }
}