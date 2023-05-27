class Square : Shape
{
    public Square(string color, double side) : base(color)
    {
        _color = color;
        _side = side;
    }
    double _side;
    public override double GetArea() => _side * _side;
}