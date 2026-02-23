namespace ShapesNFigures;

public class Shapes
{
    private string Color { get; set; } 

    public Shapes(string color)
    {
        this.Color = color;
    }

    public void SetColor(string color)
    {
        this.Color = color;
    }
    public string GetColor()
    {
        return this.Color;
    }

    public virtual double GetArea()
    {
        return 0;
    }
}

public class Circle : Shapes
{
    private double Radius { get; set; }
    public Circle(double radius,  string color) : base(color)
    {
        Radius = radius;
    }
    public void SetRadius(double radius)
    {
        this.Radius = radius;
    }
    public double GetRadius()
    {
        return this.Radius;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

public class Rectangle : Shapes
{
    private double LongSide { get; set; }
    private double ShortSide { get; set; }
    public Rectangle(double longSide, double shortSide, string color) : base(color)
    {
        this.LongSide = longSide;
        this.ShortSide = shortSide;
    }
    public void SetSides(double? longSide = null, double? shortSide = null)
    {
        double actualLongSide = longSide ?? this.LongSide;
        double actualShortSide = shortSide ?? this.ShortSide;
        this.LongSide = actualLongSide;
        this.ShortSide = actualShortSide;
    }

    public double GetLongSide()
    {
        return this.LongSide;
    }
    public double GetShortSide()
    {
        return this.ShortSide;
    }
    public override double GetArea()
    {
        return this.LongSide * this.ShortSide;
    }
}

