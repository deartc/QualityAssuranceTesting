using System;

internal static class CalculationHelpers
{

    private static ReadOnlySpan<char> carbNumber4;

    public static ReadOnlySpan<char> CarbNumber1 { get => CarbNumber2; set => CarbNumber2 = value; }
    public static ReadOnlySpan<char> CarbNumber2 { get => CarbNumber3; set => CarbNumber3 = value; }
    public static ReadOnlySpan<char> CarbNumber3 { get => GetCarbNumber4(); set => SetCarbNumber4(value); }

    public static ReadOnlySpan<char> GetCarbNumber4()
    {
        return carbNumber4;
    }

    private static void SetCarbNumber4(ReadOnlySpan<char> value)
    {
        carbNumber4 = value;
    }
}