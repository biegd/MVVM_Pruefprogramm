namespace MVVM_Pruefprogramm.Models;

public abstract class TestStep
{
    public string Name { get; }

    protected TestStep(string name)
    {
        Name = name;
    }

    public abstract string Execute();
}

public class MeasureVoltageStep : TestStep
{
    public MeasureVoltageStep() : base("Measure Voltage") { }

    public override string Execute()
    {
        double simulatedVoltage = 3.0 + new Random().NextDouble() * 2.0;
        return $"[Voltage] {simulatedVoltage:F3} V";
    }
}

public class MeasureCurrentStep : TestStep
{
    public MeasureCurrentStep() : base("Measure Current") { }

    public override string Execute()
    {
        double simulatedCurrent = 0.5 + new Random().NextDouble() * 0.3;
        return $"[Current] {simulatedCurrent:F3} A";
    }
}
