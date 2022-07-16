namespace ComputerConfigurator.Domain.Benchmarks.VideoGame;

public class VideoGame : Benchmark.Benchmark
{
    public int PixelWidth { get; set; }
    public int PixelHeight { get; set; }
    public string Name { get; set; } = string.Empty;
    public float FPSPointOnePercentLow { get; set; }
    public float FPSOnePercentLow { get; set; }
    public float FPSAverage { get; set; }

    public List<string> Validate()
    {
        List<string> errors = new();

        base.Validate(errors);

        Validation.Numeric.ValueRange(errors, "Pixel width", PixelWidth, 1280, 15630);
        Validation.Numeric.ValueRange(errors, "Pixel height", PixelHeight, 720, 8640);
        Validation.String.LengthRange(errors, "Video Game name", Name, 1, 100);

        Validation.Numeric.ValueRange(errors, "FPS 0.1% low", FPSPointOnePercentLow, 1, 1000);
        Validation.Numeric.ValueRange(errors, "FPS 1% low", FPSOnePercentLow, 1, 1000);
        Validation.Numeric.ValueRange(errors, "FPS Average", FPSAverage, 1, 1000);

        if (FPSPointOnePercentLow < FPSOnePercentLow)
        {
            errors.Add("FPS 0.1% low cannot be less than FPS 1% low.");
        }

        if (FPSOnePercentLow < FPSAverage)
        {
            errors.Add("FPS 1% low cannot be less than the average.");
        }

        return errors;
    }
}