class Rectangle : Shape
{
    public Rectangle(string color, double length, double width) : base(color)
    {
        _color = color;
        _length = length;
        _width = width;
    }
    double _length;
    double _width;
    public override double GetArea() => (_length * _width) / 2;
}