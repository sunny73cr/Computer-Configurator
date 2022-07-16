using ComputerConfigurator.Domain;

namespace ComputerConfigurator.Domain.Parts.Fan;

public class Fan : Part.Details
{
   public static readonly int[] Diameters = new[]
{
       40,
       80,
       92,
       120,
       140,
       200
   };

   public static readonly string DelimitedDiameters = Array.ConvertAll(
       Diameters,
       element => element.ToString()
    ).Delimit();

   public int Diameter { get; set; }
   public int Width { get; set; }
   public bool PWMSupport { get; set; }
   public int MinimumRPM { get; set; }
   public int? MaximumRPM { get; set; }
   public float MinimumAirflow { get; set; }
   public float? MaximumAirflow { get; set; }
   public float MinimumStaticPressure { get; set; }
   public float? MaximumStaticPressure { get; set; }
   public float MinimumAcousticOutput { get; set; }
   public float? MaximumAcousticOutput { get; set; }
   public float Voltage { get; set; }
   public float MaxCurrent { get; set; }
   public int? MeanTimeToFailure { get; set; }

   public List<string> Validate()
   {
       List<string> errors = new();

       Part.Details.Validate(errors, this);

       Validation.Numeric.ValueOption(errors, "Fan diameter", Diameter, Diameters, DelimitedDiameters);

       Validation.Numeric.ValueRange(errors, "Fan width", Width, 15, 25);

       //pwmSupport - not validated.

       Validation.Numeric.ValueRange(errors, "Minimum fan RPM", MinimumRPM, 600, 5000);

       if (MaximumRPM != null)
       {
           Validation.Numeric.ValueRange(errors, "Maximum fan RPM", (int)MaximumRPM, 600, 5000);

           if (MaximumRPM < MinimumRPM)
           {
               errors.Add("Maximum fan RPM must be greater than the minimum RPM.");
           }
       }

       Validation.Numeric.ValueRange(errors, "Minimum airflow", MinimumAirflow, 1, 200);

       if (MaximumAirflow != null)
       {
           Validation.Numeric.ValueRange(errors, "Maximum airflow", (float)MaximumAirflow, 1, 200);

           if (MaximumAirflow < MinimumAirflow)
           {
               errors.Add("Maximum airflow must be greater than the minimum airflow.");
           }
       }

       Validation.Numeric.ValueRange(errors, "Minimum static pressure", MinimumStaticPressure, 1, 200);

       if (MaximumStaticPressure != null)
       {
           Validation.Numeric.ValueRange(errors, "Maximum static pressure", (float)MaximumStaticPressure, 1, 200);

           if (MaximumStaticPressure < MinimumStaticPressure)
           {
               errors.Add("Maximum static pressure must be greater than the minimum static pressure.");
           }
       }

       Validation.Numeric.ValueRange(errors, "Minimum acoustic output", MinimumAcousticOutput, 1, 200);

       if (MaximumAcousticOutput != null)
       {
           Validation.Numeric.ValueRange(errors, "Maximum acoustic output", (float)MaximumAcousticOutput, 1, 200);

           if (MaximumAcousticOutput < MinimumAcousticOutput)
           {
               errors.Add("Maximum acoustic output must be greater than the minimum acoustic output.");
           }
       }

       Validation.Numeric.ValueRange(errors, "Rated voltage", Voltage, 5, 36);

       Validation.Numeric.ValueRange(errors, "Maximum current draw", MaxCurrent, 1, 20);

       if (MeanTimeToFailure != null)
       {
           Validation.Numeric.ValueRange(errors, "Rated hours until failure", (int)MeanTimeToFailure, 1, 10000000);
       }

       return errors;
   }
}