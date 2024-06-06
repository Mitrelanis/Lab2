using System;

public class QuadraticEquationStrategy : IRootFindingStrategy
{
    public Complex[] FindRoots(double[] coefficients)
    {
        if (coefficients.Length != 3)
            throw new ArgumentException("Invalid number of coefficients for a quadratic equation.");

        double a = coefficients[0];
        double b = coefficients[1];
        double c = coefficients[2];

        double discriminant = b * b - 4 * a * c;
        if (discriminant > 0)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            return new[] { new Complex(root1, 0), new Complex(root2, 0) };
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            return new[] { new Complex(root, 0) };
        }
        else
        {
            double realPart = -b / (2 * a);
            double imaginaryPart = Math.Sqrt(-discriminant) / (2 * a);
            return new[] { new Complex(realPart, imaginaryPart), new Complex(realPart, -imaginaryPart) };
        }
    }
}