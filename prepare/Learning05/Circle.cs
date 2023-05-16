class Circle : Shape
{
    public Circle(string color, double radius) : base(color)
    {
        _color = color;
        _radius = radius;
    }

    double _radius;
    public override double GetArea() => Math.PI * (_radius * _radius);
}