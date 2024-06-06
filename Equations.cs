using System;

public static class Equations
{
    public static double[] RemoveLeadingZeros(double[] coefficients)
    {
        int i = coefficients.Length - 1;
        while (i >= 0 && coefficients[i] == 0) i--;
        if (i < 0) return new double[] { 0 };
        return coefficients.Take(i + 1).ToArray();
    }

    public static IRootFindingStrategy ChooseStrategy(double[] coefficients)
    {
        switch (coefficients.Length)
        {
            case 1:
                throw new InvalidOperationException("Infinite number of roots.");
            case 2:
                return new LinearEquationStrategy();
            case 3:
                return new QuadraticEquationStrategy();
            default:
                throw new InvalidOperationException("Unknown equation type.");
        }
    }
}
