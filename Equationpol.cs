public class PolynomialEquation : IPolynomialEquation{
    private readonly double[] _coefficients;
    private readonly IRootFindingStrategy _solutionStrategy;

    public PolynomialEquation(double[] coefficients)
    {
        this._coefficients = Equations.RemoveLeadingZeros(coefficients);
        this._solutionStrategy = Equations.ChooseStrategy(this._coefficients);
    }

    public int Dimension => _coefficients.Length;

    public double[] Coefficients => (double[])_coefficients.Clone();

    public Complex[] FindRoots()
    {
        if (_solutionStrategy == null)
            throw new InvalidOperationException("Unknown equation type.");
        return _solutionStrategy.FindRoots(_coefficients);
    }
}