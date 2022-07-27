namespace ComputerConfigurator.Api.Fan.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create fan)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Width", fan.WidthMM, 15, 25);
            DomainValidation.Numeric.ValueRange(_errors, "Minimum RPM", fan.MinRPM, 400, 30000);
            DomainValidation.Numeric.ValueRange(_errors, "Maximum RPM", fan.MaxRPM , fan.MinRPM, 40000);
            DomainValidation.Numeric.ValueRange(_errors, "Min Airflow", fan.MinAirflow, 1, 400);
            DomainValidation.Numeric.ValueRange(_errors, "Max Airflow", fan.MaxAirflow, fan.MinAirflow, 600);
            DomainValidation.Numeric.ValueRange(_errors, "Minimum Static Pressure", fan.MinStaticPressure, 1, 250);
            DomainValidation.Numeric.ValueRange(_errors, "Maximum Static Pressure", fan.MaxStaticPressure, fan.MinStaticPressure, 500);
            DomainValidation.Numeric.ValueRange(_errors, "Minimum Acoustic Output", fan.MinAcousticOutput, 1, 80);
            DomainValidation.Numeric.ValueRange(_errors, "Maximum Acoustic Output", fan.MaxAcousticOutput, fan.MinAcousticOutput, 100);
            DomainValidation.Numeric.ValueRange(_errors, "Max Current", fan.MaxCurrent, 1, 10);
            DomainValidation.Numeric.ValueRange(_errors, "MTBF Hours", fan.MTBFHours, 1, 2000000);
        }

        public Validation(DTO.Edit fan)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Width", fan.WidthMM, 15, 25);
            DomainValidation.Numeric.ValueRange(_errors, "Minimum RPM", fan.MinRPM, 400, 30000);
            DomainValidation.Numeric.ValueRange(_errors, "Maximum RPM", fan.MaxRPM, fan.MinRPM, 40000);
            DomainValidation.Numeric.ValueRange(_errors, "Min Airflow", fan.MinAirflow, 1, 400);
            DomainValidation.Numeric.ValueRange(_errors, "Max Airflow", fan.MaxAirflow, fan.MinAirflow, 600);
            DomainValidation.Numeric.ValueRange(_errors, "Minimum Static Pressure", fan.MinStaticPressure, 1, 250);
            DomainValidation.Numeric.ValueRange(_errors, "Maximum Static Pressure", fan.MaxStaticPressure, fan.MinStaticPressure, 500);
            DomainValidation.Numeric.ValueRange(_errors, "Minimum Acoustic Output", fan.MinAcousticOutput, 1, 80);
            DomainValidation.Numeric.ValueRange(_errors, "Maximum Acoustic Output", fan.MaxAcousticOutput, fan.MinAcousticOutput, 100);
            DomainValidation.Numeric.ValueRange(_errors, "Max Current", fan.MaxCurrent, 1, 10);
            DomainValidation.Numeric.ValueRange(_errors, "MTBF Hours", fan.MTBFHours, 1, 2000000);
        }
    }
}
