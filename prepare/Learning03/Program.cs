using System;

class Program
{
    static void Main(string[] args)
    {        
        Fraction f = new Fraction();
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());

        f = new Fraction(5);
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());

        f = new Fraction(3,4);
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());
        
        f = new Fraction(1,3);
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());
    }
}