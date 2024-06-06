using System;

public class LinearEquationStrategy : IRootFindingStrategy
{
    public Complex[] FindRoots(double[] coefficients)
    {
        if (coefficients.Length != 2)
            throw new ArgumentException("Invalid number of coefficients for a linear equation.");

        double a = coefficients[0];
        double b = coefficients[1];

        if (a == 0)
            throw new InvalidOperationException("No roots exist (equation is degenerate).");

        return new[] { new Complex(-b / a, 0) };
    }
}