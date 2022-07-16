//namespace ComputerConfigurator.Domain.Parts.Dimensions;

///// <summary>
///// Units are expressed in millimeters, unless converted to inches via <see cref="DimensionsExtensions.ToInches(Dimensions)"/>.
///// </summary>
//public class Dimensions
//{
//    public float Length { get; set; }
//    public float Width { get; set; }
//    public float Height { get; set; }

//    public Dimensions(float length, float width, float height)
//    {
//        this.Length = length;
//        this.Width = width;
//        this.Height = height;
//    }

//    public void Validate(List<string> errors, string propertyName, Dimensions maximumDimensions)
//    {
//        Validation.Numeric.ValueRange(errors, $"{propertyName} length", Length, 0, maximumDimensions.Length);

//        Validation.Numeric.ValueRange(errors, $"{propertyName} width", Width, 0, maximumDimensions.Width);

//        Validation.Numeric.ValueRange(errors, $"{propertyName} height", Height, 0, maximumDimensions.Height);
//    }
//}