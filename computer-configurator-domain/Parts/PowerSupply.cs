//namespace ComputerConfigurator.Domain.Parts.PowerSupply;

//public class PowerSupply : Part.Details
//{
//    public int TotalWattage { get; set; }
//    public string FormFactor { get; set; } = default!;
//    public List<EfficiencyAtUtilisation> EfficiencyAtUtilisation { get; set; } = default!;
//    public bool ModularCables { get; set; }
//    public int? MeanTimeToFailure { get; set; }

//    public List<string> Validate()
//    {
//        List<string> errors = new();

//        //Part.Part.Validate(errors, this);

//        Validation.Numeric.ValueRange(errors, "Total wattage", TotalWattage, 150, 3000);

//        Validation.String.LengthRange(errors, "Form factor", FormFactor, 1, 20);

//        EfficiencyAtUtilisation.ForEach(efficiencyAtUtilisation => efficiencyAtUtilisation.Validate(errors));

//        //modular cables - not validated.

//        if (MeanTimeToFailure != null)
//        {
//            Validation.Numeric.ValueRange(errors, "Mean time to failure", (int)MeanTimeToFailure, 1, 9999999);
//        }

//        return errors;
//    }
//}

//public class EfficiencyAtUtilisation
//{
//    public PowerSupply PowerSupply { get; set; } = default!;
//    public float PercentEfficiency { get; set; }
//    public float PercentUtilisation { get; set; }

//    public void Validate(List<string> errors)
//    {
//        Validation.Numeric.ValueRange(errors, "Percent efficiency", PercentEfficiency, 0, 100);

//        Validation.Numeric.ValueRange(errors, "Percent utilization", PercentUtilisation, 0, 100);
//    }
//}