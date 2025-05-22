using SplashKitSDK;

public abstract class ShapeTool
{
    protected double _x, _y;
    protected Color _color;

    public ShapeTool(double x, double y, Color color)
    {
        _x = x;
        _y = y;
        _color = color;
    }

    public abstract void Draw();
}

public class CircleTool : ShapeTool
{
    private double _radius;

    public CircleTool(double x, double y, double radius, Color color) : base(x, y, color)
    {
        _radius = radius;
    }

    public override void Draw()
    {
        SplashKit.FillCircle(_color, _x, _y, _radius);
    }
}

public class RectangleTool : ShapeTool
{
    private double _width, _height;

    public RectangleTool(double x, double y, double width, double height, Color color) : base(x, y, color)
    {
        _width = width;
        _height = height;
    }

    public override void Draw()
    {
        SplashKit.FillRectangle(_color, _x, _y, _width, _height);
    }
}