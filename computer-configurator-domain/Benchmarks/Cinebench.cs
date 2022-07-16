namespace ComputerConfigurator.Domain.Benchmarks.Cinebench;

public class Cinebench : Benchmark.Benchmark
{
    public int SingleThreadScore { get; set; }
    public int MultiThreadScore { get; set; }

    public List<string> Validate()
    {
        List<string> errors = new();

        base.Validate(errors);

        Validation.Numeric.ValueRange(errors, "Cinebench Single Thread score", SingleThreadScore, 1, 10000);
        Validation.Numeric.ValueRange(errors, "Cinebench Multi Thread score", MultiThreadScore, 1, 10000);

        return errors;
    }
}
