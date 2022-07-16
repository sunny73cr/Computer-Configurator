namespace ComputerConfigurator.Domain.Benchmarks.Benchmark;

public abstract class Benchmark
{
    public int Id { get; set; }
    public string Author { get; set; } = string.Empty;

    public void Validate(List<string> errors)
    {
        Validation.String.LengthRange(errors, "Author", Author, 1, 50);
    }
}