//namespace ComputerConfigurator.Domain.Parts.CPUCooler;

//public class CPUCooler : Part.Details
//{
//    public List<string> SocketSupport { get; set; } = default!;
//    public int Height { get; set; }
//    public List<Fan.Fan> Fans { get; set; } = default!;

//    public List<string> Validate()
//    {
//        List<string> errors = new();

//        Part.Details.Validate(errors, this);

//        SocketSupport.ForEach(socket => Validation.String.LengthRange(errors, "Socket", socket, 1, 20));

//        Validation.Numeric.ValueRange(errors, "Height", Height, 1, 300);

//        return errors;
//    }
//}