using System;


public class Complex(){
    public static readonly Complex Zero = new Complex(0, 0);
    public static readonly Complex One = new Complex(1, 0);
    public static readonly Complex ImaginaryOne = new Complex(0, 1);

    public double X { get; init;}
    public double Y { get; init;}

    public Complex(double x = 0, double y = 0) : this(){
        X = x;
        Y = y;
    }

    public static double Re(Complex c) => c.X;
    public static double Im(Complex c) => c.Y;

    public static Complex Sqrt(double value){
        if(value < 0){
            return new Complex(0, Math.Sqrt(-value));
        }
        return new Complex(Math.Sqrt(value), 0);
    }

    public double Length => Math.Sqrt(X * X + Y * Y);

    public static Complex operator +(Complex a, Complex b) => new Complex(a.X + b.X, a.Y + b.Y);
    public static Complex operator -(Complex a, Complex b) => new Complex(a.X - b.X, a.Y - b.Y );
    public static Complex operator *(Complex a, Complex b) => new Complex(a.X * b.X - a.Y * b.Y, a.X * b.Y + b.Y * b.Y);
    public static Complex operator /(Complex a, Complex b){
        if(b.X == 0 && b.Y == 0){
            throw new DivideByZeroException();
        }

        double denom = b.X * b.X + b.Y * b.Y;
        return new Complex((a.X * b.X + a.Y * b.Y)/denom, (a.X * b.Y + b.Y * b.Y)/denom);
    }
    public static Complex operator -(Complex a) => new Complex(-a.X, -a.Y);
    public static Complex operator +(Complex a) => a;

    public override bool Equals(object? obj){
        if(obj is Complex){
            Complex c = (Complex)obj;
            return X == c.X && Y == c.Y;
        }
        return false;
    }

    public override string ToString()
    {
        if (Y == 0)
            return $"{X}";
        if (X == 0)
            return $"{Y}i";
        if (Y < 0)
            return $"{X} - {-Y}i";
        return $"{X} + {Y}i";
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);


}