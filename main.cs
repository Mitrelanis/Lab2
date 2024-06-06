using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the coefficients of the polynomial separated by spaces (from highest degree to constant term):");

        double[] coefficients = null;
        while (true)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            coefficients = new double[parts.Length];

            bool validInput = true;
            for (int i = 0; i < parts.Length; i++)
            {
                if (!double.TryParse(parts[i], out coefficients[i]))
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers separated by spaces.");
                    validInput = false;
                    break;
                }
            }
            if (validInput) break;
        }

        try
        {
            PolynomialEquation equation = new PolynomialEquation(coefficients);
            Complex[] roots = equation.FindRoots();
            Console.WriteLine("Roots of the polynomial:");
            foreach (Complex root in roots)
            {
                Console.WriteLine(root);
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
